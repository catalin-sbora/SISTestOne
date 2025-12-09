using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;
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
            // Validate that 'ip' is a valid IPv4 or IPv6 address
            if (!System.Net.IPAddress.TryParse(ip, out var address))
            {
                return "Invalid IP address";
            }

            // Prepare arguments for 'ping'
            string arguments;

#if WINDOWS
            arguments = "-n 4 " + ip; // Windows uses -n for count
            var processStartInfo = new ProcessStartInfo("ping.exe", arguments);
#else
            arguments = "-c 4 " + ip; // Linux/macOS uses -c for count
            var processStartInfo = new ProcessStartInfo("ping", arguments);
#endif

            Process? process = Process.Start(processStartInfo);
            if (process != null)
            {
                process.WaitForExit();
            }
            return "ping " + arguments;
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
