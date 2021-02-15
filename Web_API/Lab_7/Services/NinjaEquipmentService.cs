using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Lab_7.DbContext;
using Lab_7.Dtos;
using Lab_7.Entities;
using Lab_7.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Lab_7.Services
{
    /// <inheritdoc cref="INinjaEquipmentService"/>
    public class NinjaEquipmentService : INinjaEquipmentService
    {
        private readonly NinjaDbContext _tripFlipDbContext;

        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes database context and automapper.
        /// </summary>
        /// <param name="tripFlipDbContext">TripFlipDbContext instance.</param>
        /// <param name="mapper">IMapper instance.</param>
        public NinjaEquipmentService(NinjaDbContext tripFlipDbContext,
            IMapper mapper)
        {
            _tripFlipDbContext = tripFlipDbContext;
            _mapper = mapper;
        }

        public async Task<NinjaEquipmentDto> CreateAsync(NinjaEquipmentDto createItemDto)
        {
            var ninjaEquipmentEntity = _mapper.Map<NinjaEquipmentEntity>(createItemDto);

            await _tripFlipDbContext.NinjaItems.AddAsync(ninjaEquipmentEntity);
            await _tripFlipDbContext.SaveChangesAsync();

            var ninjaEquipmentDto = _mapper.Map<NinjaEquipmentDto>(ninjaEquipmentEntity);

            return ninjaEquipmentDto;
        }

        public async Task<IList<NinjaEquipmentDto>> GetAllAsync()
        {
            var ninjaEquipmentList = await _tripFlipDbContext
                .NinjaItems
                .AsNoTracking()
                .ToListAsync();

            var ninjaEquipmentDtoList = _mapper.Map<List<NinjaEquipmentDto>>(ninjaEquipmentList);

            return ninjaEquipmentDtoList;
        }

        public async Task<NinjaEquipmentDto> UpdateAsync(NinjaEquipmentDto updateItemDto)
        {
            var ninjaEquipmentEntity = await _tripFlipDbContext.NinjaItems.FindAsync(updateItemDto.Id);

            if (ninjaEquipmentEntity is null)
            {
                throw new Exception("Ninja equipment not found.");
            }

            ninjaEquipmentEntity.Title = updateItemDto.Title;
            ninjaEquipmentEntity.Power = updateItemDto.Power;
            ninjaEquipmentEntity.Level = updateItemDto.Level;
            ninjaEquipmentEntity.Price = updateItemDto.Price;

            await _tripFlipDbContext.SaveChangesAsync();
            var ninjaEquipmentDto = _mapper.Map<NinjaEquipmentDto>(ninjaEquipmentEntity);

            return ninjaEquipmentDto;
        }

        public async Task<NinjaEquipmentDto> GetByIdAsync(int id)
        {
            var ninjaEquipmentEntity = await _tripFlipDbContext.NinjaItems
                .AsNoTracking()
                .SingleOrDefaultAsync(equipmentEntity => equipmentEntity.Id == id);

            if (ninjaEquipmentEntity is null)
            {
                throw new Exception("Ninja equipment not found.");
            }

            var ninjaEquipmentDto = _mapper.Map<NinjaEquipmentDto>(ninjaEquipmentEntity);

            return ninjaEquipmentDto;
        }

        public async Task DeleteByIdAsync(int id)
        {
            var ninjaEquipmentEntity = await _tripFlipDbContext.NinjaItems
                .FirstOrDefaultAsync(equipmentEntity => equipmentEntity.Id == id);

            if (ninjaEquipmentEntity is null)
            {
                throw new Exception("Ninja equipment not found.");
            }

            _tripFlipDbContext.Remove(ninjaEquipmentEntity);

            await _tripFlipDbContext.SaveChangesAsync();
        }
    }
}
