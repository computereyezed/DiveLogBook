using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiveLogBook.Server.Data;

using DiveLogBook.Shared.Models.DiveInfo;
using DiveLogBook.Shared.Models.Models;
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
        public IActionResult Get()
        {
            var query = from d in _divectx.Dives
                        join dl in _divectx.Locations on d.DiveLocationID equals dl.Id
                        join c in _divectx.Countries on dl.CountryID equals c.Id
                        //where d.UserID == userid
                        orderby d.DiveDateTime descending
                        select new DiveView
                        {
                            DiveLogId = d.Id,
                            DiverId = d.UserID,
                            DiveLocationId = d.DiveLocationID,
                            DiveDateTime = d.DiveDateTime,
                            Depth = d.Depth,
                            BottomTime = d.BottomTime,
                            Country = c.Country,
                            Located = dl.Located,
                            Location = dl.Location,
                            Latitude = dl.Latitude,
                            Longitude = dl.Longitude,
                            WhatToSee = dl.WhatToSee,
                            Comments = dl.Comments
                        };
            var dive = new List<DiveView>(query);
            return Ok(dive);
            //var dives = await _divectx.Dives.ToListAsync();
            //return Ok(dives);
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
