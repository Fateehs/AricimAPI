using Application.DTOs.Hive;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace AricimAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HivesController : ControllerBase
    {
        private readonly IHiveService _hiveService;

        public HivesController(IHiveService hiveService)
        {
            _hiveService = hiveService;
        }

        [HttpGet("summary")]
        public async Task<ActionResult<HiveSummaryDto>> GetSummary()
        {
            // Kullanıcı ID'sini claim'den alabiliriz veya query parametresiyle gönderebilirsin
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null) return Unauthorized();

            var userId = Guid.Parse(userIdClaim.Value);

            var summary = await _hiveService.GetSummaryAsync(userId);
            return Ok(summary);
        }

        // GET: api/hive
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var hives = await _hiveService.GetAllAsync();
            return Ok(hives);
        }

        // GET: api/hive/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var hive = await _hiveService.GetByIdAsync(id);
            if (hive == null) return NotFound();
            return Ok(hive);
        }

        // POST: api/hive
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateHiveRequest request)
        {
            var created = await _hiveService.CreateAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        // PUT: api/hive/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateHiveRequest request)
        {
            var updated = await _hiveService.UpdateAsync(id, request);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        // DELETE: api/hive/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var success = await _hiveService.DeleteAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
