using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RaceDayAPI.Data;
using RaceDayAPI.Models;
using RaceDayAPI.Services;

namespace RaceDayAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IBlobStorageService _blobService;

        public EventsController(ApplicationDbContext context, IBlobStorageService blobService)
        {
            _context = context;
            _blobService = blobService;
        }

        [HttpGet]
        async public Task<IActionResult> GetEvents([FromQuery] string? search)
        {
            var query = _context.Events.Include(e => e.Categories).AsQueryable();
            if (!string.IsNullOrEmpty(search))
                query = query.Where(e => e.Name.Contains(search) || e.Location.Contains(search));

            return Ok(await query.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEvent(int id)
        {
            var ev = await _context.Events.Include(e => e.Categories).FirstOrDefaultAsync(e => e.Id == id);
            if (ev == null) return NotFound();
            return Ok(ev);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEvent([FromForm] EventDto dto, IFormFile? bannerImage)
        {
            string imageUrl = bannerImage != null ? await _blobService.UploadFileAsync(bannerImage) : string.Empty;

            var ev = new Event
            {
                Name = dto.Name,
                Description = dto.Description,
                Date = dto.Date,
                Location = dto.Location,
                Distance = dto.Distance,
                EventType = dto.EventType,
                BannerImageUrl = imageUrl,
                OrganiserId = dto.OrganiserId
            };

            _context.Events.Add(ev);
            await _context.SaveChangesAsync();
            return Ok(ev);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            var ev = await _context.Events.FindAsync(id);
            if (ev == null) return NotFound();
            _context.Events.Remove(ev);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }

    public class EventDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string Location { get; set; } = string.Empty;
        public double Distance { get; set; }
        public string EventType { get; set; } = string.Empty;
        public int OrganiserId { get; set; }
    }
}
