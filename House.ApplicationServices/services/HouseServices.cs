using House.Core.Domain;
using House.Core.Dtos;
using House.Core.ServiceInterface;
using House.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace House.ApplicationServices.services
{
    public class HouseServices : IHouseServices
    {
        private readonly HouseDbContext _context;

        public HouseServices
            (
            HouseDbContext context
            )
        {
            _context = context;
        }

        public async Task<HouseNew> Add(HouseDto dto)
        {
            HouseNew house = new HouseNew();

            house.Id = Guid.NewGuid();
            house.TotalArea = dto.TotalArea;
            house.Address = dto.Address;
            house.Details = dto.Details;
            house.Price = dto.Price;
            house.Rooms = dto.Rooms;
            house.Year = dto.Year;

            await _context.House.AddAsync(house);
            await _context.SaveChangesAsync();

            return house;
        }


        public async Task<HouseNew> Delete(Guid id)
        {
            var houseId = await _context.House
                .FirstOrDefaultAsync(x => x.Id == id);

            _context.House.Remove(houseId);
            await _context.SaveChangesAsync();

            return houseId;
        }


        public async Task<HouseNew> Update(HouseDto dto)
        {
            HouseNew house = new HouseNew();

            house.Id = dto.Id;
            house.TotalArea = dto.TotalArea;
            house.Address = dto.Address;
            house.Details = dto.Details;
            house.Price = dto.Price;
            house.Rooms = dto.Rooms;
            house.Year = dto.Year;


            _context.House.Update(house);
            await _context.SaveChangesAsync();
            return house;
        }

        public async Task<HouseNew> GetAsync(Guid id)
        {
            var result = await _context.House
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }
    }
}
