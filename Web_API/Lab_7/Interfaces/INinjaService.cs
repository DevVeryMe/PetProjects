using System.Collections.Generic;
using System.Threading.Tasks;
using Lab_7.Dtos;

namespace Lab_7.Interfaces
{
    public interface INinjaService
    {
        /// <summary>
        /// Creates a new Ninja.
        /// </summary>
        /// <param name="createItemDto">Data to create a new Ninja.</param>
        /// <returns>Ninja DTO that represents the new entry that was added to database.</returns>
        Task<NinjaDto> CreateAsync(NinjaDto createItemDto);

        /// <summary>
        /// Gets all Ninjas.
        /// </summary>
        /// <returns>Ninja DTOs that represent the database entries.</returns>
        Task<IList<NinjaDto>> GetAllAsync();

        /// <summary>
        /// Updates Ninja.
        /// </summary>
        /// <param name="updateItemDto">Updated Ninja data with existing Ninja id.</param>
        /// <returns>Ninja DTO that represents the updated database entry.</returns>
        Task<NinjaDto> UpdateAsync(NinjaDto updateItemDto);

        /// <summary>
        /// Gets Ninja by id.
        /// </summary>
        /// <param name="id">Ninja id.</param>
        /// <returns>Ninja DTO that represents the database entry.</returns>
        Task<NinjaDto> GetByIdAsync(int id);

        /// <summary>
        /// Deletes Ninja.
        /// </summary>
        /// <param name="id">Ninja id.</param>
        Task DeleteByIdAsync(int id);
    }
}
