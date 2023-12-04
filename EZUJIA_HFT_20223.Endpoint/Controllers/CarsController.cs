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
    public class CarsController : ControllerBase
    {
        ICarLogic logic;
        IHubContext<SignalRHub> hub;

        public CarsController(ICarLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }


        // GET: api/<CarsController>
        [HttpGet]
        public IEnumerable<Cars> ReadAll()
        {
            return logic.ReadAll();
        }

        // GET api/<CarsController>/5
        [HttpGet("{id}")]
        public Cars Read(int id)
        {
            return logic.Read(id);
        }

        // POST api/<CarsController>
        [HttpPost]
        public void Create([FromBody] Cars value)
        {
            logic.Create(value);
            this.hub.Clients.All.SendAsync("CarsCreated", value);
        }

        // PUT api/<CarsController>/5
        [HttpPut]
        public void Put([FromBody] Cars value)
        {
            logic.Update(value);
            this.hub.Clients.All.SendAsync("CarsUpdated", value);
        }

        // DELETE api/<CarsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var items = this.logic.Read(id);
            logic.Delete(id);
            this.hub.Clients.All.SendAsync("CarsDeleted", items);
        }
    }
}
