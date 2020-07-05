using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prova.Interfaces;
using Prova.Models;
using Prova.Repository;

namespace Prova.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioPfController : ControllerBase
    {
        /// <summary>
        /// Cria um objeto _jogoRepository que irá receber todos os métodos definidos na interface
        /// </summary>
        private IusuarioPfRepository _usuarioPfRepository { get; set; }

        /// <summary>
        /// Instancia este objeto para que haja a referência aos métodos no repositório
        /// </summary>
        public UsuarioPfController()
        {
            _usuarioPfRepository = new UsuarioPfRepository();
        }

        /// <summary>
        /// Lista todos os jogos
        /// </summary>
        /// <returns>Uma lista de jogos e um status code 200 - Ok</returns>
        /// dominio/api/Jogos
        [HttpGet]
        public IActionResult Get()
        {
            // Faz a chamada para o método .Listar()
            // Retorna a lista e um status code 200 - Ok
            return Ok(_usuarioPfRepository.Listar());
        }

        /// <summary>
        /// Cadastra um novo jogo
        /// </summary>
        /// <param name="novoUsuarioPF">Objeto novoJogo que será cadastrado</param>
        /// <returns>Os dados que foram enviados para cadastro e um status code 201 - Created</returns>
        /// dominio/api/Jogos
        [HttpPost]
        public IActionResult Post(UsuarioPF novoUsuarioPF)
        {
            // Faz a chamada para o método .Cadastrar();
            _usuarioPfRepository.Cadastrar(novoUsuarioPF);

            // Retorna o status code 201 - Created com a URI e o objeto cadastrado
            return Created("http://localhost:5000/api/Funcionarios", novoUsuarioPF);
        }

        /// <summary>
        /// Busca um jogo através do seu ID
        /// </summary>
        /// <param name="cpf">ID do jogo que será buscado</param>
        /// <returns>Um jogo buscado ou NotFound caso nenhum seja encontrado</returns>
        /// dominio/api/Jogos/1

        [HttpGet("{NumeroCpf}")]
        public IActionResult GetByCpf(int cpf)
        {
            // Cria um objeto jogoBuscado que irá receber o jogo buscado no banco de dados
            UsuarioPF usuarioPFBuscado = _usuarioPfRepository.BuscarPorCpf(cpf);

            // Verifica se algum jogo foi encontrado
            if (usuarioPFBuscado != null)
            {
                // Caso seja, retorna os dados buscados e um status code 200 - Ok
                return Ok(usuarioPFBuscado);
            }

            // Caso não seja, retorna um status code 404 - NotFound com a mensagem
            return NotFound("Nenhum usuario Físico encontrado para o identificador informado");
        }

        /// <summary>
        /// Atualiza um jogo existente
        /// </summary>
        /// <param name="cpf">ID do jogo que será atualizado</param>
        /// <param name="UsuarioPFAtualizado">Objeto jogoAtualizado que será alterado</param>
        /// <returns>Retorna um status code</returns>
        /// dominio/api/Jogos/1
        [HttpPut("{NumeroCpf}")]
        public IActionResult Put(int cpf, UsuarioPF UsuarioPFAtualizado)
        {
            // Cria um objeto jogoBuscado que irá receber o jogo buscado no banco de dados
            UsuarioPF UsuarioPFBuscado = _usuarioPfRepository.BuscarPorCpf(cpf);

            // Verifica se algum jogo foi encontrado
            if (UsuarioPFBuscado != null)
            {
                // Tenta atualizar o registro
                try
                {
                    // Faz a chamada para o método .Atualizar();
                    _usuarioPfRepository.Atualizar(cpf, UsuarioPFAtualizado);

                    // Retorna um status code 204 - No Content
                    return NoContent();
                }
                // Caso ocorra algum erro
                catch (Exception erro)
                {
                    // Retorna BadRequest e o erro
                    return BadRequest(erro);
                }

            }

            // Caso não seja encontrado, retorna NotFound com uma mensagem personalizada
            // e um bool para representar que houve erro
            return NotFound
                (
                    new
                    {
                        mensagem = "Usuario Físico não encontrado",
                        erro = true
                    }
                );
        }

        /// <summary>
        /// Deleta um jogo
        /// </summary>
        /// <param name="cpf">ID do jogo que será deletado</param>
        /// <returns>Um status code com uma mensagem de sucesso ou erro</returns>
        /// dominio/api/Jogos/1
        [HttpDelete("{NumeroCpf}")]
        public IActionResult Delete(int cpf)
        {
            // Cria um objeto jogoBuscado que irá receber o jogo buscado no banco de dados
            UsuarioPF usuarioPFBuscado = _usuarioPfRepository.BuscarPorCpf(cpf);

            // Verifica se o jogo foi encontrado
            if (usuarioPFBuscado != null)
            {
                // Caso seja, faz a chamada para o método .Deletar()
                _usuarioPfRepository.Deletar(cpf);

                // e retorna um status code 200 - Ok com uma mensagem de sucesso
                return Ok($"O Usuário físico {cpf} foi deletado com sucesso!");
            }

            // Caso não seja, retorna um status code 404 - NotFound com a mensagem
            return NotFound("Nenhum  Usuário físico encontrado para o identificador informado");
        }

       
    }
}