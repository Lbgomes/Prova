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
    public class UsuarioPjController : ControllerBase
    {
        /// <summary>
        /// Cria um objeto _UsuarioRepository que irá receber todos os métodos definidos na interface
        /// </summary>
        private IusuarioPjRepository _usuarioPjRepository { get; set; }

        /// <summary>
        /// Instancia este objeto para que haja a referência aos métodos no repositório
        /// </summary>
        public UsuarioPjController()
        {
            _usuarioPjRepository = new UsuarioPjRepository();
        }

        /// <summary>
        /// Lista todos os Usuarios
        /// </summary>
        /// <returns>Uma lista de Usuarios e um status code 200 - Ok</returns>
        /// dominio/api/Usuarios
        [HttpGet]
        public IActionResult Get()
        {
            // Faz a chamada para o método .Listar()
            // Retorna a lista e um status code 200 - Ok
            return Ok(_usuarioPjRepository.Listar());
        }

        /// <summary>
        /// Cadastra um novo Usuario
        /// </summary>
        /// <param name="novoUsuarioPJ">Objeto novoUsuario que será cadastrado</param>
        /// <returns>Os dados que foram enviados para cadastro e um status code 201 - Created</returns>
        /// dominio/api/Usuarios
        [HttpPost]
        public IActionResult Post(UsuarioPJ novoUsuarioPJ)
        {
            // Faz a chamada para o método .Cadastrar();
            _usuarioPjRepository.Cadastrar(novoUsuarioPJ);

            // Retorna o status code 201 - Created com a URI e o objeto cadastrado
            return Created("http://localhost:5000/api/Funcionarios", novoUsuarioPJ);
        }

        /// <summary>
        /// Busca um Usuario através do seu ID
        /// </summary>
        /// <param name="cnpj">ID do Usuario que será buscado</param>
        /// <returns>Um Usuario buscado ou NotFound caso nenhum seja encontrado</returns>
        /// dominio/api/Usuarios/1

        [HttpGet("{NumeroCnpj}")]
        public IActionResult GetByCnpj(int cnpj)
        {
            // Cria um objeto UsuarioBuscado que irá receber o Usuario buscado no banco de dados
            UsuarioPJ usuarioPJBuscado = _usuarioPjRepository.BuscarPorCnpj(cnpj);

            // Verifica se algum Usuario foi encontrado
            if (usuarioPJBuscado != null)
            {
                // Caso seja, retorna os dados buscados e um status code 200 - Ok
                return Ok(usuarioPJBuscado);
            }

            // Caso não seja, retorna um status code 404 - NotFound com a mensagem
            return NotFound("Nenhum usuario Físico encontrado para o identificador informado");
        }

        /// <summary>
        /// Atualiza um Usuario existente
        /// </summary>
        /// <param name="cpf">ID do Usuario que será atualizado</param>
        /// <param name="UsuarioPFAtualizado">Objeto UsuarioAtualizado que será alterado</param>
        /// <returns>Retorna um status code</returns>
        /// dominio/api/Usuarios/1
        [HttpPut("{NumeroCpf}")]
        public IActionResult Put(int cnpj, UsuarioPJ UsuarioPJAtualizado)
        {
            // Cria um objeto UsuarioBuscado que irá receber o Usuario buscado no banco de dados
            UsuarioPJ UsuarioPJBuscado = _usuarioPjRepository.BuscarPorCnpj(cnpj);

            // Verifica se algum Usuario foi encontrado
            if (UsuarioPJBuscado != null)
            {
                // Tenta atualizar o registro
                try
                {
                    // Faz a chamada para o método .Atualizar();
                    _usuarioPjRepository.Atualizar(cnpj, UsuarioPJAtualizado);

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
        /// Deleta um Usuario
        /// </summary>
        /// <param name="cpf">ID do Usuario que será deletado</param>
        /// <returns>Um status code com uma mensagem de sucesso ou erro</returns>
        /// dominio/api/Usuarios/1
        [HttpDelete("{NumeroCnpj}")]
        public IActionResult Delete(int cnpj)
        {
            // Cria um objeto UsuarioBuscado que irá receber o Usuario buscado no banco de dados
            UsuarioPJ usuarioPJBuscado = _usuarioPjRepository.BuscarPorCnpj(cnpj);

            // Verifica se o Usuario foi encontrado
            if (usuarioPJBuscado != null)
            {
                // Caso seja, faz a chamada para o método .Deletar()
                _usuarioPjRepository.Deletar(cnpj);

                // e retorna um status code 200 - Ok com uma mensagem de sucesso
                return Ok($"O Usuário jurídico {cnpj} foi deletado com sucesso!");
            }

            // Caso não seja, retorna um status code 404 - NotFound com a mensagem
            return NotFound("Nenhum  Usuário jurídico encontrado para o identificador informado");
        }

       
    }
}