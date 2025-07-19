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
                UserId = hive.UserId,

                LastInspection = hive.LastInspection,
                NextInspection = hive.NextInspection,
                QueenBirthDate = hive.QueenBirthDate,
                QueenStatus = hive.QueenStatus,
                Breed = hive.Breed,
                IsMarked = hive.IsMarked,
                RequeeningDate = hive.RequeeningDate,
                CombCondition = hive.CombCondition,
                FrameCount = hive.FrameCount,
                HoneyAmount = hive.HoneyAmount,
                HarvestedHoney = hive.HarvestedHoney,
                FeedingStatus = hive.FeedingStatus,
                DiseaseSymptoms = hive.DiseaseSymptoms,
                BeeBehavior = hive.BeeBehavior,
                Pests = hive.Pests,
                Notes = hive.Notes
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

            hive.LastInspection = request.LastInspection;
            hive.NextInspection = request.NextInspection;
            hive.QueenBirthDate = request.QueenBirthDate;
            hive.QueenStatus = request.QueenStatus;
            hive.Breed = request.Breed;
            hive.IsMarked = request.IsMarked;
            hive.RequeeningDate = request.RequeeningDate;
            hive.CombCondition = request.CombCondition;
            hive.FrameCount = request.FrameCount;
            hive.HoneyAmount = request.HoneyAmount;
            hive.HarvestedHoney = request.HarvestedHoney;
            hive.FeedingStatus = request.FeedingStatus;
            hive.DiseaseSymptoms = request.DiseaseSymptoms;
            hive.BeeBehavior = request.BeeBehavior;
            hive.Pests = request.Pests;
            hive.Notes = request.Notes;

            await _context.SaveChangesAsync();

            return new HiveDto
            {
                Id = hive.Id,
                Name = hive.Name,
                Type = hive.Type,
                CreatedAt = hive.CreatedAt,
                Status = hive.Status,
                UserId = hive.UserId,

                LastInspection = hive.LastInspection,
                NextInspection = hive.NextInspection,
                QueenBirthDate = hive.QueenBirthDate,
                QueenStatus = hive.QueenStatus,
                Breed = hive.Breed,
                IsMarked = hive.IsMarked,
                RequeeningDate = hive.RequeeningDate,
                CombCondition = hive.CombCondition,
                FrameCount = hive.FrameCount,
                HoneyAmount = hive.HoneyAmount,
                HarvestedHoney = hive.HarvestedHoney,
                FeedingStatus = hive.FeedingStatus,
                DiseaseSymptoms = hive.DiseaseSymptoms,
                BeeBehavior = hive.BeeBehavior,
                Pests = hive.Pests,
                Notes = hive.Notes
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
