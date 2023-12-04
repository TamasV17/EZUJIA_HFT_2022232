using EZUJIA_HFT_2022232.Logic;
using EZUJIA_HFT_2022232.Models;
using EZUJIA_HFT_20223.Endpoint.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;

namespace EZUJIA_HFT_2022232.Endpoint.WebApiTest.Controllers
{    
        [Route("[controller]")]
        [ApiController]
        public class RentController : ControllerBase
        {
            IRentLogic logic;
            IHubContext<SignalRHub> hub;

        public RentController(IRentLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }

        // GET: api/<RentsController>
        [HttpGet]
            public IEnumerable<Rent> ReadAll()
            {
                return logic.ReadAll();
            }

            // GET api/<RentsController>/5
            [HttpGet("{id}")]
            public Rent Read(int id)
            {
                return logic.Read(id);
            }

            // POST api/<RentsController>
            [HttpPost]
            public void Create([FromBody] Rent value)
            {
                logic.Create(value);
            this.hub.Clients.All.SendAsync("RentsCreated", value);

        }

        // PUT api/<RentsController>/5
        [HttpPut]
            public void Put([FromBody] Rent value)
            {
                logic.Update(value);
            this.hub.Clients.All.SendAsync("RentsUpdated", value);

        }

        // DELETE api/<RentsController>/5
        [HttpDelete("{id}")]
            public void Delete(int id)
            {
            var item = this.logic.Read(id);
            logic.Delete(id);
            this.hub.Clients.All.SendAsync("RentsDeleted", item);
        }
        }
    }
