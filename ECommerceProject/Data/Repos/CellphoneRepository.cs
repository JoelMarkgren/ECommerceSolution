using ECommerceProject.Data;
using ECommerceProject.Data.Interfaces;
using ECommerceProject.Dto;
using ECommerceProject.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerceProject.Data.Repos
{
    public class CellphoneRepository : ICellphoneRepository
    {
        private readonly ApplicationDbContext applicationDbContext;

        public CellphoneRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public async Task CreateAsync(Cellphone cellphone)
        {
            if (cellphone == null)
            {
                throw new ArgumentNullException(nameof(cellphone), "Cellphone object cannot be null");
            }
            await applicationDbContext.Cellphones.AddAsync(cellphone);
            await applicationDbContext.SaveChangesAsync();
            
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

        public async Task<Cellphone> GetByIdAsync(int id)
        {
            return await applicationDbContext.Cellphones.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Cellphone>> GetAllAsync()
        {
            return await applicationDbContext.Cellphones.OrderBy(x => x.Brand).ToListAsync();
        }
    }
}
