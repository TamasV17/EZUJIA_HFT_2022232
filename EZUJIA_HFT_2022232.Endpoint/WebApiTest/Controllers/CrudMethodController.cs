using EZUJIA_HFT_2022232.Logic;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using static EZUJIA_HFT_2022232.Logic.CarsLogic;
using static EZUJIA_HFT_2022232.Logic.RentLogic;

namespace EZUJIA_HFT_2022232.Endpoint.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CrudMethodController : ControllerBase
    {
        ICarLogic carlogic;
        IRentLogic rentlogic;

        public CrudMethodController(ICarLogic carlogic, IRentLogic rentlogic)
        {
            this.carlogic = carlogic;
            this.rentlogic = rentlogic;
        }

        [HttpGet]
        public IEnumerable<string> TheRentsCarBrand()
        {
            return this.rentlogic.TheRentsCarBrand();
        }

        [HttpGet]
        public IEnumerable<BrandperRentsCount> BrandperRentsCountsMethod()
        {
            return this.rentlogic.BrandperRentsCountsMethod();
        }

        [HttpGet]
        public TheMostFamous TheMostFamousBrand()
        {
            return carlogic.TheMostFamousBrand();
        }

        [HttpGet]
        public IEnumerable<AvarageCarHP> AvarageHPperCar()
        {
            return this.carlogic.AvarageHPperCar();
        }

    }
}
