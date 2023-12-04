using EZUJIA_HFT_2022232.Logic;
using EZUJIA_HFT_2022232.Models;
using EZUJIA_HFT_20223.Endpoint.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;

namespace EZUJIA_HFT_2022232.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CarBrandController : ControllerBase
    {
        ICarBrandLogic logic;
        IHubContext<SignalRHub> hub;

        public CarBrandController(ICarBrandLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }

        // GET: api/<CarBrandController>
        [HttpGet]
        public IEnumerable<CarBrand> ReadAll()
        {
            return logic.ReadAll();
        }

        // GET api/<CarBrandController>/5
        [HttpGet("{id}")]
        public CarBrand Read(int id)
        {
            return logic.Read(id);
        }

        // POST api/<CarBrandController>
        [HttpPost]
        public void Create([FromBody] CarBrand value)
        {
            logic.Create(value);
            this.hub.Clients.All.SendAsync("CarBrandCreated", value);

        }

        // PUT api/<CarBrandController>/5
        [HttpPut]
        public void Put([FromBody] CarBrand value)
        {
            logic.Update(value);
            this.hub.Clients.All.SendAsync("CarBrandUpdated", value);

        }

        // DELETE api/<CarBrandController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var carsbrandtodelete = this.logic.Read(id);
            logic.Delete(id);
            this.hub.Clients.All.SendAsync("CarBrandDeleted", carsbrandtodelete);
        }
    }
}

