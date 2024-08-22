using Temperature;
using Microsoft.AspNetCore.Mvc;

namespace TemperatureAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TemperatureController : ControllerBase
    {
        private List<TemperatureConverter> lstTemperature;

        public TemperatureController()
        {
            var temp_1 = new TemperatureConverter(215, "f");
            var temp_2 = new TemperatureConverter(354, "c");

            lstTemperature = new List<TemperatureConverter> { temp_1, temp_2 };
        }

        [HttpGet]
        public IEnumerable<TemperatureConverter> Get() => lstTemperature;

        [HttpGet("{unit}")]
        public TemperatureConverter Get(string unit)
        {
            foreach (var converter in lstTemperature) 
            { 
                if(converter.Unit == unit)
                {
                    return converter;
                }
            }
            return new TemperatureConverter(0, "N.A");
        }

        [HttpPost] // Rever o erro 500 
        public List<TemperatureConverter> Post([FromBody] TemperatureConverter newTemperature)
        {
            lstTemperature.Add(newTemperature);
            return lstTemperature;
        }
    }
}
