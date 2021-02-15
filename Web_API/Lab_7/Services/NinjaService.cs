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
    /// <inheritdoc cref="INinjaService"/>
    public class NinjaService : INinjaService
    {
        private readonly NinjaDbContext _tripFlipDbContext;

        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes database context and automapper.
        /// </summary>
        /// <param name="tripFlipDbContext">TripFlipDbContext instance.</param>
        /// <param name="mapper">IMapper instance.</param>
        public NinjaService(NinjaDbContext tripFlipDbContext,
            IMapper mapper)
        {
            _tripFlipDbContext = tripFlipDbContext;
            _mapper = mapper;
        }

        public async Task<NinjaDto> CreateAsync(NinjaDto createItemDto)
        {
            var ninjaEntity = _mapper.Map<NinjaEntity>(createItemDto);

            await _tripFlipDbContext.Ninjas.AddAsync(ninjaEntity);
            await _tripFlipDbContext.SaveChangesAsync();

            var ninjaDto = _mapper.Map<NinjaDto>(ninjaEntity);

            return ninjaDto;
        }

        public async Task<IList<NinjaDto>> GetAllAsync()
        {
            var ninjaEquipmentList = await _tripFlipDbContext
                .Ninjas
                .AsNoTracking()
                .ToListAsync();

            var ninjaDtoList = _mapper.Map<List<NinjaDto>>(ninjaEquipmentList);

            return ninjaDtoList;
        }

        public async Task<NinjaDto> UpdateAsync(NinjaDto updateItemDto)
        {
            var ninjaEntity = await _tripFlipDbContext.Ninjas.FindAsync(updateItemDto.Id);

            if (ninjaEntity is null)
            {
                throw new Exception("Ninja not found.");
            }

            ninjaEntity.Name = updateItemDto.Name;
            ninjaEntity.Rank = updateItemDto.Rank;
            ninjaEntity.HealthPoints = updateItemDto.HealthPoints;
            ninjaEntity.HitPower = updateItemDto.HitPower;

            await _tripFlipDbContext.SaveChangesAsync();
            var ninjaDto = _mapper.Map<NinjaDto>(ninjaEntity);

            return ninjaDto;
        }

        public async Task<NinjaDto> GetByIdAsync(int id)
        {
            var ninjaEntity = await _tripFlipDbContext.Ninjas
                .AsNoTracking()
                .SingleOrDefaultAsync(ninja => ninja.Id == id);

            if (ninjaEntity is null)
            {
                throw new Exception("Ninja not found.");
            }

            var ninjaDto = _mapper.Map<NinjaDto>(ninjaEntity);

            return ninjaDto;
        }

        public async Task DeleteByIdAsync(int id)
        {
            var ninjaEntity = await _tripFlipDbContext.Ninjas
                .FirstOrDefaultAsync(ninja => ninja.Id == id);

            if (ninjaEntity is null)
            {
                throw new Exception("Ninja not found.");
            }

            _tripFlipDbContext.Remove(ninjaEntity);

            await _tripFlipDbContext.SaveChangesAsync();
        }
    }
}
