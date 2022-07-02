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
    public class UsersController : ControllerBase
    {
        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            DatosUsuario du = new DatosUsuario();
            var usuarios = du.All();
            List<string> resp=new List<string>();
            foreach (var u in usuarios)
            {
                string o = JsonConvert.SerializeObject(u);
                resp.Add(o);
            }
            return resp.ToArray();
        }

        // GET api/<UsersController>/<username:string>
        [HttpGet("{username}")]
        public string Get(string username)
        {
            DatosUsuario du = new DatosUsuario();
            var u=du.get(username);
            var o=JsonConvert.SerializeObject(u);
            return o;
        }

        // POST api/<UsersController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
            var usr= JsonConvert.DeserializeObject<Usuario>(value);
            DatosUsuario du = new DatosUsuario();
            du.Registrar(usr);
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            throw new NotImplementedException();
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
