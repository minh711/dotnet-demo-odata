using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using demo_odata.Models;
using Microsoft.AspNetCore.Mvc;

namespace demo_odata.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PressesController : ControllerBase
    {
        private readonly AppDbContext _db;

        public PressesController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet("presses")]
        public ActionResult<IEnumerable<Address>> GetPresses()
        {
            var presses = _db.Presses.ToList();
            return Ok(presses);
        }
    }
}