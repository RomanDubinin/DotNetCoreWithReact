using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DBRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace HelloWorld.Controllers
{
    [Route("api/[controller]")]
    public class IdeomController : DbContext
    {
        private readonly IdeomRepository ideomRepository;

        public IdeomController()
        {
            ideomRepository = new IdeomRepository(MyOptions.PostgresConnectionString);
        }

        [HttpGet("[action]")]
        public async Task<IEnumerable<Ideom>> Ideoms()
        {
            var ideoms = await ideomRepository.SelectAsync().ConfigureAwait(false);
            return ideoms;
        }
    }
}