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
        private readonly ICellphone cellphoneRep;

        public CellphoneController(ICellphone cellphoneRep)
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
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CellphoneController>
        [HttpPost("create")]
        public async void Post([FromBody] Cellphone cellphone)
        {
            await cellphoneRep.CreateAsync(cellphone);
        }

        // PUT api/<CellphoneController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CellphoneController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
