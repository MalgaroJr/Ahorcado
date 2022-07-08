using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using API.DataAccess;
using ClasesAhorcado;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JuegosController : ControllerBase
    {
        // GET: api/<JuegosController>/<user>
        [HttpGet("{user}")]
        public string Get(string user)
        {
            DatosJuegos dj = new DatosJuegos();
            List<Juego> juegoList = dj.All(user);
            /*List<string> result = new List<string>();
            foreach (Juego juego in juegoList)
            {
                string o=JsonConvert.SerializeObject(juego);
                result.Add(o);
            }
            return result.ToArray();*/
            //IEnumerable<string>
            string json = JsonConvert.SerializeObject(juegoList);
            return json;

        }

        // POST api/<JuegosController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
            try
            {
                var usr = JsonConvert.DeserializeObject<Usuario>(value);
                DatosJuegos dj = new DatosJuegos();
                dj.Nuevo(usr.Juegos.Last(), usr.Username);
            }
            catch (Exception e)
            {

                throw new Exception("No fue posible registrar el juego->"+e.Message);
            }
            
        }

        // PUT api/<JuegosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<JuegosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
