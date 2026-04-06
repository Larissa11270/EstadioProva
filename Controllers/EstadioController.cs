using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using CopaApi.Models;
using CopaHAS.Data;
using CopaHAS.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace CopaHAS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EstadioController : ControllerBase
    {
        private readonly DataContext _context;
        public EstadioController(DataContext context)
        {
            _context = context;
        }

        public DataContext Get_context1()
        {
            return _context;
        }

        // GET TUDO
        [HttpGet()] 
        public async Task<IActionResult> GetEstadio()
        {
           List<Estadio> e = await _context.TB_ESTADIO.ToListAsync();
           return Ok(e);
        }

        //POST ESTADIO NOVO
        [HttpPost()]
        public async Task<IActionResult> Add(Estadio novoEstadio)
        {
            _context.TB_ESTADIO.Add(novoEstadio);
            return Ok(novoEstadio);
        }

        [HttpDelete()]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Estadio eRemover = await _context.TB_ESTADIO
                    .FirstOrDefaultAsync(p => p.Id == id);

                _context.TB_ESTADIO.Remove(eRemover);
                int linhaAfetadas = await _context.SaveChangesAsync();
                return Ok(linhaAfetadas);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message + " - " + ex.InnerException);
            }
        }
    }
}