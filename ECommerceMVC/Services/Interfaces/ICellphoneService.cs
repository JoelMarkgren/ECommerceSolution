using ECommerceMVC.Models;

namespace ECommerceMVC.Services.Interfaces
{
    public interface ICellphoneService
    {
        Task<IEnumerable<Cellphone>> GetAllAsync();
        Task<Cellphone> GetByIdAsync(int id);
        Task CreateAsync(Cellphone cellphone);
        Task DeleteAsync(int id);
    }
}
