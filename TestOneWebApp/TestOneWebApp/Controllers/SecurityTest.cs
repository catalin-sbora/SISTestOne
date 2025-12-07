using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestOneWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityTest : ControllerBase
    {
        // GET: api/<SecurityTest>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<SecurityTest>/5
        [HttpGet("{ip}")]
        public string Get(string ip)
        {
            var commandToExecute = "ping -c " + ip;
            ProcessStartInfo processStartInfo = new ProcessStartInfo("cmd.exe", "-c \"" + commandToExecute + "\"");
            Process? process = Process.Start(processStartInfo);
            if (process != null)
            {
                process.WaitForExit();
            }
            return commandToExecute;
        }

        // POST api/<SecurityTest>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SecurityTest>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SecurityTest>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
