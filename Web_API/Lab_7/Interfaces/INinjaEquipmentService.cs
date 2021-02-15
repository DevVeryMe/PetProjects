using System.Collections.Generic;
using System.Threading.Tasks;
using Lab_7.Dtos;

namespace Lab_7.Interfaces
{
    public interface INinjaEquipmentService
    {
        /// <summary>
        /// Creates a new NinjaEquipment.
        /// </summary>
        /// <param name="createItemDto">Data to create a new NinjaEquipmentDto.</param>
        /// <returns>NinjaEquipmentDto DTO that represents the new entry that was added to database.</returns>
        Task<NinjaEquipmentDto> CreateAsync(NinjaEquipmentDto createItemDto);

        /// <summary>
        /// Gets all NinjaEquipment.
        /// </summary>
        /// <returns>Ninja DTOs that represent the database entries.</returns>
        Task<IList<NinjaEquipmentDto>> GetAllAsync();

        /// <summary>
        /// Updates NinjaEquipment.
        /// </summary>
        /// <param name="updateItemDto">Updated NinjaEquipmentDto data with existing NinjaEquipmentDto id.</param>
        /// <returns>NinjaEquipmentDto DTO that represents the updated database entry.</returns>
        Task<NinjaEquipmentDto> UpdateAsync(NinjaEquipmentDto updateItemDto);

        /// <summary>
        /// Gets NinjaEquipment by id.
        /// </summary>
        /// <param name="id">NinjaEquipmentDto id.</param>
        /// <returns>NinjaEquipmentDto DTO that represents the database entry.</returns>
        Task<NinjaEquipmentDto> GetByIdAsync(int id);

        /// <summary>
        /// Deletes NinjaEquipment.
        /// </summary>
        /// <param name="id">NinjaEquipmentDto id.</param>
        Task DeleteByIdAsync(int id);
    }
}
