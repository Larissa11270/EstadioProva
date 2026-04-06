using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using CopaHAS.Data;
using CopaHAS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CopaHAS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JogadoresController : ControllerBase
    {
        private readonly DataContext _context;

        public JogadoresController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")] //Buscar pelo id
        public async Task<IActionResult> GetSingle(int id)
        {
            try
            {
                Jogador j = await _context.TB_JOGADORES
                    .FirstOrDefaultAsync(pBusca => pBusca.Id == id);

                return Ok(j);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message + " - " + ex.InnerException);
            }
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<Jogador> lista = await _context.TB_JOGADORES.ToListAsync();
                return Ok(lista);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message + " - " + ex.InnerException);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(Jogador novoJogador)
        {
            try
            {
                if (novoJogador.NumeroCamisa >= 100)
                    return BadRequest("Número da camisa não pode ser maior/igual a 100.");

                await _context.TB_JOGADORES.AddAsync(novoJogador);
                await _context.SaveChangesAsync();

                return Ok(novoJogador.Id);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message + " - " + ex.InnerException);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(Jogador jogador)
        {
            try
            {
                if (jogador.NumeroCamisa >= 100)
                    return BadRequest("Número da camisa não pode ser maior/igual a 100.");

                _context.TB_JOGADORES.Update(jogador);
                int linhasAfetadas = await _context.SaveChangesAsync();

                return Ok(linhasAfetadas);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message + " - " + ex.InnerException);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Jogador jRemover = await _context.TB_JOGADORES
                    .FirstOrDefaultAsync(p => p.Id == id);

                _context.TB_JOGADORES.Remove(jRemover);
                int linhaAfetadas = await _context.SaveChangesAsync();
                return Ok(linhaAfetadas);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message + " - " + ex.InnerException);
            }
        }



    }
    //Fim da classe controller. Não programe nada aqui.
}



