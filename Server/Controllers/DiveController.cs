using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiveLogBook.Server.Data;

using DiveLogBook.Shared.Models.DiveInfo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DiveLogBook.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiveController : ControllerBase
    {
        private readonly DiveCtx _divectx;

        public DiveController(DiveCtx context)
        {
            this._divectx = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var dives = await _divectx.Dives.ToListAsync();
            return Ok(dives);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var dive = await _divectx.Dives.FirstOrDefaultAsync(a => a.Id == id);
            return Ok(dive);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Dives dive)
        {
            _divectx.Add(dive);
            await _divectx.SaveChangesAsync();
            return Ok(dive.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Dives dive)
        {
            _divectx.Entry(dive).State = EntityState.Modified;
            await _divectx.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var div = new Dives { Id = id };
            _divectx.Remove(div);
            await _divectx.SaveChangesAsync();
            return NoContent();
        }
    }
}
