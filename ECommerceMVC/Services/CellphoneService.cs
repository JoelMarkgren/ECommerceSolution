using ECommerceMVC.Models;
using ECommerceMVC.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace ECommerceMVC.Services
{
    public class CellphoneService : ICellphoneService
    {
        private readonly HttpClient httpClient;

        public CellphoneService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task CreateAsync(Cellphone cellphone)
        {
            try
            {
                var response = await httpClient.PostAsJsonAsync("api/cellphone/create", cellphone);
                response.EnsureSuccessStatusCode();
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
                var cellphones = await httpClient.GetFromJsonAsync<IEnumerable<Cellphone>>("api/cellphone");
                return cellphones.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Cellphone> GetByIdAsync(int id)
        {
            try
            {

                var response = await httpClient.GetAsync($"api/cellphone/{id}");

                if (response.IsSuccessStatusCode)
                {
                    var cellphone = await response.Content.ReadFromJsonAsync<Cellphone>();
                    return cellphone;
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"API returned an error: {errorContent}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching cellphone by id: {ex.Message}");
            }


        }
        public async Task DeleteAsync(int id)
        {
            try
            {
                var response = await httpClient.DeleteAsync($"api/cellphone/delete/{id}");
                if (!response.IsSuccessStatusCode)
                {
                    // Log or inspect the error
                    var content = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error deleting cellphone: {content}");
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }


    }
}
