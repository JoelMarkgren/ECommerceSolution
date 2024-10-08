using ECommerceProject.Data.Interfaces;
using ECommerceProject.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ECommerceProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CellphoneController : ControllerBase
    {
        private readonly ICellphoneRepository cellphoneRep;

        public CellphoneController(ICellphoneRepository cellphoneRep)
        {
            this.cellphoneRep = cellphoneRep;
        }
        // GET: api/<CellphoneController>
        [HttpGet]
        public async Task<IEnumerable<Cellphone>> GetAll()
        {
            return await cellphoneRep.GetAllAsync();
        }

        // GET api/<CellphoneController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var cellphone = await cellphoneRep.GetByIdAsync(id);
            if (cellphone == null)
            {
                return NotFound();
            }
            return Ok(cellphone);
        }

        // POST api/<CellphoneController>
        [HttpPost("create")]
        public async Task Post([FromBody] Cellphone cellphone)
        {
            await cellphoneRep.CreateAsync(cellphone);
        }

        // PUT api/<CellphoneController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var cellphone = await cellphoneRep.GetByIdAsync(id);
            if (cellphone == null)
            {
                return NotFound();
            }
            await cellphoneRep.DeleteAsync(id);
            return NoContent();
        }
    }
}
