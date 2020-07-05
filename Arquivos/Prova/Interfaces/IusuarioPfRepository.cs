using Prova.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prova.Interfaces
{
    interface IusuarioPfRepository
    {
        /// <summary>
        /// Lista todos os jogos
        /// </summary>
        /// <returns>Uma lista de jogos</returns>
        List<UsuarioPF> Listar();

        /// <summary>
        /// Busca um jogo através do ID
        /// </summary>
        /// <param name="cpf">ID do jogo que será buscado</param>
        /// <returns>Um jogo buscado</returns>
        UsuarioPF BuscarPorCpf(int cpf);

        /// <summary>
        /// Cadastra um novo jogo
        /// </summary>
        /// <param name="novoJogo">Objeto novoJogo que será cadastrado</param>
        void Cadastrar(UsuarioPF novoUsuarioPF);

        /// <summary>
        /// Atualiza um jogo existente
        /// </summary>
        /// <param name="cpf">ID do jogo que será atualizado</param>
        /// <param name="jogoAtualizado">Objeto jogoAtualizado que será alterado</param>
        void Atualizar(int id, UsuarioPF UsuarioPFAtualizado);

        /// <summary>
        /// Deleta um jogo existente
        /// </summary>
        /// <param name="cpf">ID do jogo que será deletado</param>
        void Deletar(int cpf);

    }
}
