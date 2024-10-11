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
    public class AddressesController : ControllerBase
    {
        private readonly AppDbContext _db;

        public AddressesController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet("addresses")]
        public ActionResult<IEnumerable<Address>> GetAddresses()
        {
            var addresses = _db.Addresses.ToList();
            return Ok(addresses);
        }
    }
}