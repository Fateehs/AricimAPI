using Application.DTOs.Hive;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class HiveService : IHiveService
    {
        private readonly AppDbContext _context;

        public HiveService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<HiveSummaryDto> GetSummaryAsync(Guid userId)
        {
            var userHives = _context.Hives.Where(h => h.UserId == userId);

            var totalHives = await userHives.CountAsync();
            var activeHives = await userHives.CountAsync(h => h.Status == "Active");
            var passiveHives = await userHives.CountAsync(h => h.Status == "Passive");

            var totalHoney = await userHives.SumAsync(h => h.HoneyAmount ?? 0);

            return new HiveSummaryDto
            {
                TotalHives = totalHives,
                ActiveHives = activeHives,
                PassiveHives = passiveHives,
                TotalHoney = totalHoney
            };
        }

        public async Task<List<HiveDto>> GetAllAsync()
        {
            return await _context.Hives
                .Select(h => new HiveDto
                {
                    Id = h.Id,
                    Name = h.Name,
                    Type = h.Type,
                    CreatedAt = h.CreatedAt,
                    Status = h.Status,
                    UserId = h.UserId
                })
                .ToListAsync();
        }

        public async Task<HiveDto?> GetByIdAsync(Guid id)
        {
            var hive = await _context.Hives.FindAsync(id);
            if (hive == null) return null;

            return new HiveDto
            {
                Id = hive.Id,
                Name = hive.Name,
                Type = hive.Type,
                CreatedAt = hive.CreatedAt,
                Status = hive.Status,
                UserId = hive.UserId
            };
        }

        public async Task<HiveDto> CreateAsync(CreateHiveRequest request)
        {
            var hive = new Hive
            {
                Name = request.Name,
                Type = request.Type,
                Status = request.Status,
                UserId = request.UserId,
                CreatedAt = DateTime.UtcNow
            };

            _context.Hives.Add(hive);
            await _context.SaveChangesAsync();

            return new HiveDto
            {
                Id = hive.Id,
                Name = hive.Name,
                Type = hive.Type,
                CreatedAt = hive.CreatedAt,
                Status = hive.Status,
                UserId = hive.UserId
            };
        }

        public async Task<HiveDto?> UpdateAsync(Guid id, UpdateHiveRequest request)
        {
            var hive = await _context.Hives.FindAsync(id);
            if (hive == null) return null;

            hive.Name = request.Name;
            hive.Type = request.Type;
            hive.Status = request.Status;

            await _context.SaveChangesAsync();

            return new HiveDto
            {
                Id = hive.Id,
                Name = hive.Name,
                Type = hive.Type,
                CreatedAt = hive.CreatedAt,
                Status = hive.Status,
                UserId = hive.UserId
            };
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var hive = await _context.Hives.FindAsync(id);
            if (hive == null) return false;

            _context.Hives.Remove(hive);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
