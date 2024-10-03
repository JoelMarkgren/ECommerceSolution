using ECommerceProject.Dto;
using ECommerceProject.Models;

namespace ECommerceProject.Data.Interfaces
{
    public interface ICellphone
    {
        Task<Cellphone> GetByIdAsync(int id);
        Task<IEnumerable<Cellphone>> GetAllAsync();
        Task<Cellphone> EditAsync(Cellphone cellphone);
        Task DeleteAsync(int id);
        Task<Cellphone> CreateAsync(Cellphone cellphone);
    }
}
