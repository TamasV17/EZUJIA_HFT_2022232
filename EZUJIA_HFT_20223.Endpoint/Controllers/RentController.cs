using EZUJIA_HFT_2022232.Logic;
using EZUJIA_HFT_2022232.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EZUJIA_HFT_2022232.Endpoint.WebApiTest.Controllers
{    
        [Route("[controller]")]
        [ApiController]
        public class RentController : ControllerBase
        {
            IRentLogic logic;

            public RentController(IRentLogic logic)
            {
                this.logic = logic;
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
            }

            // PUT api/<RentsController>/5
            [HttpPut]
            public void Put([FromBody] Rent value)
            {
                logic.Update(value);
            }

            // DELETE api/<RentsController>/5
            [HttpDelete("{id}")]
            public void Delete(int id)
            {
                logic.Delete(id);
            }
        }
    }
