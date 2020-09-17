using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiveLogBook.Server.Data;
using DiveLogBook.Server.Migrations;
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
        private readonly DiveDbContext _divecontext;

        public DiveController(DiveDbContext context)
        {
            this._divecontext = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var dives = await _divecontext.Dives.ToListAsync();
            return Ok(dives);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var dive = await _divecontext.Dives.FirstOrDefaultAsync(a => a.Id == id);
            return Ok(dive);
        }

        [HttpPost]
        public async Task<IActionResult> Post(DiveData dive)
        {
            _divecontext.Add(dive);
            await _divecontext.SaveChangesAsync();
            return Ok(dive.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Put(DiveData dive)
        {
            _divecontext.Entry(dive).State = EntityState.Modified;
            await _divecontext.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var div = new DiveData { Id = id };
            _divecontext.Remove(div);
            await _divecontext.SaveChangesAsync();
            return NoContent();
        }
    }
}
