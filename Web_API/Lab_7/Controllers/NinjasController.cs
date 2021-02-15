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
    [Route("api/ninjas")]
    [ApiController]
    public class NinjasController : ControllerBase
    {
        private readonly IMapper _mapper;

        private readonly INinjaService _ninjaService;

        public NinjasController(IMapper mapper, INinjaService ninjaService)
        {
            _mapper = mapper;
            _ninjaService = ninjaService;
        }

        /// <summary>
        /// Gets a ninja with the given id.
        /// </summary>
        /// <param name="id">Ninja id.</param>
        /// <returns>Ninja view model that
        /// represents database entry.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(NinjaViewModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByIdAsync(
            [Range(1, int.MaxValue, ErrorMessage = "Id less than 1")]
            [FromRoute] int id)
        {
            var ninjaDto = await _ninjaService.GetByIdAsync(id);

            var ninjaViewModel = _mapper.Map<NinjaViewModel>(ninjaDto);

            return Ok(ninjaViewModel);
        }

        /// <summary>
        /// Gets all ninja.
        /// </summary>
        /// <returns>List of ninja view models that
        /// represent database entries.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IList<NinjaViewModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAsync()
        {
            var ninjaDtos = await _ninjaService.GetAllAsync();

            var ninjaViewModels = _mapper.Map<List<NinjaViewModel>>(ninjaDtos);

            return Ok(ninjaViewModels);
        }

        /// <summary>
        /// Creates a new ninja.
        /// </summary>
        /// <param name="createNinjaViewModel">Data to create ninja.</param>
        /// <returns>Ninja view model that
        /// represents the new entry that was added to database.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(NinjaViewModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateAsync([FromBody] CreateNinjaViewModel createNinjaViewModel)
        {
            var ninjaDto = _mapper.Map<NinjaDto>(createNinjaViewModel);

            var createdNinjaDto = await _ninjaService.CreateAsync(ninjaDto);

            var ninjaViewModel = _mapper.Map<NinjaViewModel>(createdNinjaDto);

            return Ok(ninjaViewModel);
        }

        /// <summary>
        /// Updates ninja.
        /// </summary>
        /// <param name="updateNinjaViewModel">New ninja data with existing ninja equipment id.</param>
        /// <returns>Ninja view model
        /// that represents the updated database entry.</returns>
        [HttpPut]
        [ProducesResponseType(typeof(NinjaViewModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateAsync([FromBody] NinjaViewModel updateNinjaViewModel)
        {
            var ninjaDto = _mapper.Map<NinjaDto>(updateNinjaViewModel);

            var updatedNinjaDto = await _ninjaService.UpdateAsync(ninjaDto);

            var ninjaViewModel = _mapper.Map<NinjaViewModel>(updatedNinjaDto);

            return Ok(ninjaViewModel);
        }

        /// <summary>
        /// Deletes ninja.
        /// </summary>
        /// <param name="id">Ninja id.</param>
        /// <returns>No content (HTTP code 204).</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteByIdAsync(
            [Range(1, int.MaxValue, ErrorMessage = "Id less than 1")]
            [FromRoute] int id)
        {
            await _ninjaService.DeleteByIdAsync(id);

            return NoContent();
        }
    }
}
