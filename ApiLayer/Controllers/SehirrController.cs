using DataAccess.Abstract;
using DataAccess.Concrete;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SehirrController : ControllerBase
    {
        private ISehirDal sehirDal;

        public SehirrController()
        {
            sehirDal = new SehirDal();
        }


        [HttpGet]
        public List<Sehir> Get()
        {
            return sehirDal.GetList();
        }


        [HttpGet("{id}")]
        public Sehir Get(int id)
        {
            return sehirDal.GetSehirById(id);
        }

        [HttpPost("add")]
        public IActionResult Insert(Sehir sehir)
        {
            sehirDal.Insert(sehir);
            return Created("", sehir);
           
        }


        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Sehir sehir)
        {
            if (sehir == null || sehir.Id != id)
            {
                return BadRequest();
            }
            var existingSehir = sehirDal.GetSehirById(id);
            if (existingSehir == null)
            {
                return NotFound();
            }
            sehirDal.Update(sehir);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var sehir = sehirDal.GetSehirById(id);
            if (sehir == null)
            {
                return NotFound();
            }
            sehirDal.Delete(sehir);
            return new NoContentResult();
        }


    }
}
