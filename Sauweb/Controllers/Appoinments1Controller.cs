using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SauWeb.Models;
using Sauweb.Data;

namespace Sauweb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Appoinments1Controller : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public Appoinments1Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Appoinments1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Appoinment>>> GetAppoinments()
        {
            if (_context.Appoinments == null)
            {
                return NotFound();
            }
            return await _context.Appoinments.ToListAsync();
        }


    }
}

