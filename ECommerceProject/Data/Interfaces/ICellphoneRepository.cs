using ECommerceProject.Dto;
using ECommerceProject.Models;

namespace ECommerceProject.Data.Interfaces
{
    public interface ICellphoneRepository
    {
        Task<Cellphone> GetByIdAsync(int id);
        Task<IEnumerable<Cellphone>> GetAllAsync();
        Task<Cellphone> EditAsync(Cellphone cellphone);
        Task DeleteAsync(int id);
        Task CreateAsync(Cellphone cellphone);
    }
}
