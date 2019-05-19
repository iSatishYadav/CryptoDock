using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using CryptoDock.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CryptoDock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HashController : ControllerBase
    {
        // GET: api/Hash/5
        [HttpGet("{text}", Name = "Get")]
        public string Get(string text)
        {
            return text.ToMd5();
        }

        // POST: api/Hash
        [HttpPost]
        public IDictionary<string, string> Post([FromBody] string[] value)
        {
            return value.ToMd5();
        }


    }
}
