using ECommerceMVC.Models;
using ECommerceMVC.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ECommerceMVC.Services
{
    public class CellphoneService : ICellphoneService
    {
        private readonly HttpClient httpClient;

        public CellphoneService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public Task<Cellphone> CreateAsync()
        {
            try
            {
                var newCellphone = httpClient.GetFromJsonAsync<Cellphone>("cellphone/create");
                return newCellphone;
            }
            catch (Exception ex)
            {
                throw;
            }  
        }

        public async Task<IEnumerable<Cellphone>> GetAllAsync()
        {
            try
            {
                var cellphones = httpClient.GetFromJsonAsync<IEnumerable<Cellphone>>("cellphone/index");
            }
            catch (Exception ex)
            {
                throw;
            }
            return null;
        }

        public Task<Cellphone> GetByIdAsync(string id)
        {
            var cellphone = httpClient.GetFromJsonAsync<Cellphone>($"cellphone/index/{id}");
            return cellphone;   
        }
    }
}
