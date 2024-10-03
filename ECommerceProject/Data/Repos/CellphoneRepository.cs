using ECommerceProject.Data;
using ECommerceProject.Data.Interfaces;
using ECommerceProject.Dto;
using ECommerceProject.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerceProject.Data.Repos
{
    public class CellphoneRepository : ICellphone
    {
        private readonly ApplicationDbContext applicationDbContext;

        public CellphoneRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public async Task<Cellphone> CreateAsync(Cellphone cellphone)
        {
            await applicationDbContext.Cellphones.AddAsync(cellphone);
            await applicationDbContext.SaveChangesAsync();
            return cellphone;
        }

        public async Task DeleteAsync(int id)
        {
            var cellPhone = await applicationDbContext.Cellphones.FindAsync(id);
            applicationDbContext.Cellphones.Remove(cellPhone);
            await applicationDbContext.SaveChangesAsync();
        }

        public Task<Cellphone> EditAsync(Cellphone cellphone)
        {
            throw new NotImplementedException();
        }

        public Task<Cellphone> GetByIdAsync(int id)
        {
            return applicationDbContext.Cellphones.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Cellphone>> GetAllAsync()
        {
            return await applicationDbContext.Cellphones.OrderBy(x => x.Brand).ToListAsync();
        }
    }
}
