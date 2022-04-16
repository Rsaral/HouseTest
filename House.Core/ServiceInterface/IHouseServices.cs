using House.Core.Domain;
using House.Core.Dtos;
using System;
using System.Threading.Tasks;

namespace House.Core.ServiceInterface
{
    public interface IHouseServices : IApplicationServices
    {
        Task<HouseNew> Add(HouseDto dto);

        Task<HouseNew> Delete(Guid id);

        Task<HouseNew> Update(HouseDto dto);

        Task<HouseNew> GetAsync(Guid id);
    }
}
