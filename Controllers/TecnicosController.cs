using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CopaApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using CopaHAS.Data;

namespace CopaApi.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class TecnicosController : ControllerBase
    {
        private readonly DataContext _context;
        public TecnicosController(DataContext context)
        {
            _context = context;
        }
    
    [HttpGet("GetAll")]
    public async Task<IActionResult> Get()
        {
            try
            {
                List<Tecnico> lista = await _context.TB_TECNICOS.Include(s => s.SelecaoIdNavegacao).ToListAsync();
                return Ok(lista);
            }
            catch(System.Exception ex)
            {
                return BadRequest(ex.Message + " - " + ex.InnerException);
            }
        }
    }
}
