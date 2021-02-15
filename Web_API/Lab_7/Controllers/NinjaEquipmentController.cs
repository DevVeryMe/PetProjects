using AutoMapper;
using Lab_7.Dtos;
using Lab_7.Interfaces;
using Lab_7.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Lab_7.Controllers
{
    [Route("api/ninja-equipment")]
    [ApiController]
    public class NinjaEquipmentController : ControllerBase
    {
        private readonly IMapper _mapper;

        private readonly INinjaEquipmentService _ninjaEquipmentService;

        public NinjaEquipmentController(IMapper mapper, INinjaEquipmentService ninjaEquipmentService)
        {
            _mapper = mapper;
            _ninjaEquipmentService = ninjaEquipmentService;
        }

        /// <summary>
        /// Gets a ninja equipment with the given id.
        /// </summary>
        /// <param name="id">Ninja equipment id.</param>
        /// <returns>Ninja equipment view model that
        /// represents database entry.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(NinjaEquipmentViewModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByIdAsync(
            [Range(1, int.MaxValue, ErrorMessage = "Id less than 1")]
            [FromRoute] int id)
        {
            var ninjaEquipmentDto = await _ninjaEquipmentService.GetByIdAsync(id);

            var ninjaEquipmentViewModel = _mapper.Map<NinjaEquipmentViewModel>(ninjaEquipmentDto);

            return Ok(ninjaEquipmentViewModel);
        }

        /// <summary>
        /// Gets all ninja equipment.
        /// </summary>
        /// <returns>List of ninja equipment view models that
        /// represent database entries.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IList<NinjaEquipmentViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAsync()
        {
            var ninjaEquipmentDtos = await _ninjaEquipmentService.GetAllAsync();

            var ninjaEquipmentViewModels = _mapper.Map<List<NinjaEquipmentViewModel>>(ninjaEquipmentDtos);

            return Ok(ninjaEquipmentViewModels);
        }

        /// <summary>
        /// Creates a new ninja equipment.
        /// </summary>
        /// <param name="createNinjaEquipmentViewModel">Data to create ninja equipment.</param>
        /// <returns>Ninja equipment view model that
        /// represents the new entry that was added to database.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(NinjaEquipmentViewModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateAsync([FromBody] CreateNinjaEquipmentViewModel createNinjaEquipmentViewModel)
        {
            var ninjaEquipmentDto = _mapper.Map<NinjaEquipmentDto>(createNinjaEquipmentViewModel);

            var createdEquipmentDto = await _ninjaEquipmentService.CreateAsync(ninjaEquipmentDto);

            var ninjaEquipmentViewModel = _mapper.Map<NinjaEquipmentViewModel>(createdEquipmentDto);

            return Ok(ninjaEquipmentViewModel);
        }

        /// <summary>
        /// Updates ninja equipment.
        /// </summary>
        /// <param name="updateNinjaEquipmentViewModel">New ninja equipment data with existing ninja equipment id.</param>
        /// <returns>Ninja equipment view model
        /// that represents the updated database entry.</returns>
        [HttpPut]
        [ProducesResponseType(typeof(NinjaEquipmentViewModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateAsync([FromBody] NinjaEquipmentViewModel updateNinjaEquipmentViewModel)
        {
            var ninjaEquipmentDto = _mapper.Map<NinjaEquipmentDto>(updateNinjaEquipmentViewModel);

            var updatedEquipmentDto = await _ninjaEquipmentService.UpdateAsync(ninjaEquipmentDto);

            var ninjaEquipmentViewModel = _mapper.Map<NinjaEquipmentViewModel>(updatedEquipmentDto);

            return Ok(ninjaEquipmentViewModel);
        }

        /// <summary>
        /// Deletes ninja equipment.
        /// </summary>
        /// <param name="id">Ninja equipment id.</param>
        /// <returns>No content (HTTP code 204).</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteByIdAsync(
            [Range(1, int.MaxValue, ErrorMessage = "Id less than 1")]
            [FromRoute] int id)
        {
            await _ninjaEquipmentService.DeleteByIdAsync(id);

            return NoContent();
        }
    }
}
