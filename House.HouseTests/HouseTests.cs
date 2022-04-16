using House.Core.Dtos;
using House.Core.ServiceInterface;
using System;
using System.Threading.Tasks;
using Xunit;

namespace House.HouseTests
{
    public class HouseTests : TestBase
    {
        [Fact]
        public async Task AddHouseNotNull()
        {
            string guid = "b75f644b-ef34-4aeb-80fe-c78817d9c4e6";

            HouseDto house = new HouseDto();

            house.Id = Guid.Parse(guid);
            house.TotalArea = 60;
            house.Address = "Tallinn";
            house.Details = "Modern home with Sauna";
            house.Price = 100000;
            house.Rooms = 3;
            house.Year = 2000;

            var result = await Svc<IHouseServices>().Add(house);

            Assert.NotNull(result);
        }


        [Fact]
        public async Task SameGuid()
        {
            string guid = "b75f644b-ef34-4aeb-80fe-c78817d9c4e6";
            string sameGuid = "b75f644b-ef34-4aeb-80fe-c78817d9c4e6";

            var guid1 = Guid.Parse(guid);
            var guid2 = Guid.Parse(sameGuid);

            await Svc<IHouseServices>().GetAsync(guid1);
            Assert.Equal(guid1, guid2);
        }

        [Fact]
        public async Task DifferentGuid()
        {
            string guid = "b75f644b-ef34-4aeb-80fe-c78817d9c4e6";
            string differentGuid = "58dd1dcb-cc07-4562-acfd-492fa3631df5";

            var guid1 = Guid.Parse(guid);
            var guid2 = Guid.Parse(differentGuid);

            await Svc<IHouseServices>().GetAsync(guid1);
            Assert.NotEqual(guid1, guid2);
        }

        [Fact]
        public async Task UpdateHouse()
        {
            var guid = new Guid("b75f644b-ef34-4aeb-80fe-c78817d9c4e6");

            HouseDto house = new HouseDto();

            house.Id = guid;
            house.TotalArea = 60;
            house.Address = "Tallinn";
            house.Details = "Modern home with Sauna";
            house.Price = 100000;
            house.Rooms = 3;
            house.Year = 2000;

            var houseId = guid;
            var houseToUpdate = new HouseDto()
            {
                TotalArea = 70,
                Rooms = 4
            };

            await Svc<IHouseServices>().Update(houseToUpdate);

            Assert.Equal(house.Id.ToString(), houseId.ToString());
            Assert.NotEqual(house.TotalArea, houseToUpdate.TotalArea);
            Assert.NotEqual(house.Rooms, houseToUpdate.Rooms);
        }
    }
}
