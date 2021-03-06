using System;
using System.Collections.Generic;
using System.Threading;
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
        private readonly IIdeomRepository ideomRepository;

        public IdeomController(IIdeomRepository ideomRepository)
        {
            this.ideomRepository = ideomRepository;
        }

        [HttpGet("[action]")]
        public async Task<IEnumerable<Ideom>> SelectIdeoms()
        {
            var ideoms = await ideomRepository.SelectAsync().ConfigureAwait(false);
            return ideoms;
        }
        
        [HttpPost("[action]")]
        public async Task SaveIdeom(Ideom ideom)
        {
            ideom.Id = Guid.NewGuid();
            await ideomRepository.SaveAsync(ideom, CancellationToken.None).ConfigureAwait(false);
        }
    }
}