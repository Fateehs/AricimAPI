using Application.DTOs.Hive;

namespace Application.Interfaces
{
    public interface IHiveService
    {
        Task<List<HiveDto>> GetAllAsync();
        Task<HiveDto?> GetByIdAsync(Guid id);
        Task<HiveSummaryDto> GetSummaryAsync(Guid userId);
        Task<HiveDto> CreateAsync(CreateHiveRequest request);
        Task<HiveDto?> UpdateAsync(Guid id, UpdateHiveRequest request);
        Task<bool> DeleteAsync(Guid id);
    }
}
