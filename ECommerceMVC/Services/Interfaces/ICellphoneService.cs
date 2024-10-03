using ECommerceMVC.Models;

namespace ECommerceMVC.Services.Interfaces
{
    public interface ICellphoneService
    {
        Task<IEnumerable<Cellphone>> GetAllAsync();
        Task<Cellphone> GetByIdAsync(string id);
        Task<Cellphone> CreateAsync();
    }
}
