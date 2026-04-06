using Microsoft.AspNetCore.Mvc;
using CopaHAS.Models;
using CopaHAS.Models.Enuns;

namespace CopaHAS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JogadoresExercicioController : ControllerBase
    {
        private static List<Jogador> listaJogadores = new List<Jogador>()
        {
            new Jogador(){ Id=1, Nome="Hugo Souza",NumeroCamisa=1,Posicao="Goleiro",Status=Models.Enuns.StatusJogador.Titular },
            new Jogador(){ Id=2, Nome="Yuri Alberto",NumeroCamisa=9,Posicao="Atacante",Status=Models.Enuns.StatusJogador.Titular },
            new Jogador(){ Id=3, Nome="Danilo", NumeroCamisa=2, Posicao="Lateral Direito", Status=Models.Enuns.StatusJogador.Titular },
            new Jogador(){ Id=4, Nome="Marquinhos", NumeroCamisa=4, Posicao="Zagueiro", Status=Models.Enuns.StatusJogador.Titular },
            new Jogador(){ Id=5, Nome="Casemiro", NumeroCamisa=5, Posicao="Volante", Status=Models.Enuns.StatusJogador.Titular },
            new Jogador(){ Id=6, Nome="Alex Sandro", NumeroCamisa=6, Posicao="Lateral Esquerdo", Status=Models.Enuns.StatusJogador.Titular },
            new Jogador(){ Id=7, Nome="Lucas Paquetá", NumeroCamisa=7, Posicao="Meio Campo", Status=Models.Enuns.StatusJogador.Titular },
            new Jogador(){ Id=8, Nome="Bruno Guimarães", NumeroCamisa=8, Posicao="Meio Campo", Status=Models.Enuns.StatusJogador.Reserva },
            new Jogador(){ Id=9, Nome="Richarlison", NumeroCamisa=10, Posicao="Atacante", Status=Models.Enuns.StatusJogador.Titular },
            new Jogador(){ Id=10, Nome="Vinicius Jr", NumeroCamisa=11, Posicao="Atacante", Status=Models.Enuns.StatusJogador.Titular },
            new Jogador(){ Id=11, Nome="Rodrygo", NumeroCamisa=19, Posicao="Atacante", Status=Models.Enuns.StatusJogador.DepartamentoMedico },
            new Jogador(){ Id=12, Nome="Alisson", NumeroCamisa=23, Posicao="Goleiro", Status=Models.Enuns.StatusJogador.NaoRelacionado }
        };

        //Métodos deverão ser construídos aqui
        [HttpGet("GetByNome/{nome}")]
        public IActionResult GetByNome(string nome)
        {
            Jogador jogador = listaJogadores
                .FirstOrDefault(j => j.Nome.ToLower().Contains(nome.ToLower()));

            if (jogador == null)            
                return NotFound("Nenhum jogador encontrado.");                            
            else
                return Ok(jogador);                
        }

        [HttpGet("GetTitulares")]
        public IActionResult GetTitulares()
        {
            listaJogadores.RemoveAll(j => j.Status != StatusJogador.Titular);
            return Ok(listaJogadores.OrderByDescending(j=> j.NumeroCamisa));
        }

        [HttpGet("GetEstatisticas")]
        public IActionResult GetEstatisticas()
        {
            int quantidade = listaJogadores.Count;
            int somatorio = listaJogadores.Sum(x => x.NumeroCamisa);            
            
            return Ok($"Quantidade de Jogadores: {quantidade} - Somatório número camisa: {somatorio}");
        }

        [HttpPost("PostValidacao")]
        public IActionResult PostValidacao(Jogador novoJogador)
        {                        
            if (novoJogador.NumeroCamisa > 100) 
                return BadRequest("Número da camisa não pode ser maior que 100.");

            listaJogadores.Add(novoJogador);
            return Ok(listaJogadores);
        }

        [HttpPost("PostValidacaoNome")]
        public IActionResult PostValidacaoNome(Jogador novoJogador)
        {
            //if(!novoJogador.Posicao.ToLower().Contains("goleiro") && novoJogador.NumeroCamisa == 1)//Posibilidade 1
            
            if (novoJogador.Posicao != "Goleiro" && novoJogador.NumeroCamisa == 1) //possibilidade 2
                return BadRequest("Jogador não pode ter a camisa número 1");

            listaJogadores.Add(novoJogador);
            return Ok(listaJogadores);
        }

        [HttpGet("GetByStatus/{statusDigitadoId}")]
        public IActionResult GetByEnum(int statusDigitadoId)
        {
            StatusJogador statusEnum = (StatusJogador)statusDigitadoId;
            List<Jogador> listaBusca = listaJogadores.FindAll(p => p.Status == statusEnum);
            return Ok(listaBusca);
        }

        [HttpGet("GetAll")]
        public IActionResult ObterJogadores()
        {
            List<Jogador> lista = listaJogadores;
            return Ok(lista);
        }

        [HttpGet("Get")]
        public IActionResult GetFirst()
        {
            return Ok(listaJogadores[0]);
        }

        [HttpPost]
        public IActionResult InserirJogador(Jogador j)
        {
            listaJogadores.Add(j);
            return Ok(listaJogadores);
        }

        [HttpGet("GetOrdenado")]
        public IActionResult GetOrdem()
        {
            List<Jogador> listaFinal = 
                listaJogadores.OrderBy(j => j.Nome).ToList();

            return Ok(listaFinal);
        }

        [HttpPut("AtualizarJogador")]
        public IActionResult Atualizar(Jogador j)
        {
            Jogador jEncontrado = 
                listaJogadores.Find(jBusca => jBusca.Id == j.Id );

            if(jEncontrado == null)
                return BadRequest("Jogador não encontrado");

            jEncontrado.Nome = j.Nome;
            jEncontrado.NumeroCamisa = j.NumeroCamisa;   

            return Ok(listaJogadores);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            listaJogadores.RemoveAll(j => j.Id == id);
            return Ok(listaJogadores);
        }
        
        [HttpGet("GetByNomeAproximado/{nome}")]
        public IActionResult GetByNomeAproximado(string nome)
        {
            List<Jogador> lista = 
                listaJogadores.FindAll(j => 
                    j.Nome.ToLower().Contains(nome.ToLower()));

            return Ok(lista);
        }

    }
}

