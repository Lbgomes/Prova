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
        /// Lista todos os Usuarios
        /// </summary>
        /// <returns>Uma lista de Usuarios</returns>
        List<UsuarioPF> Listar();

        /// <summary>
        /// Busca um Usuario através do ID
        /// </summary>
        /// <param name="cpf">ID do Usuario que será buscado</param>
        /// <returns>Um Usuario buscado</returns>
        UsuarioPF BuscarPorCpf(int cpf);

        /// <summary>
        /// Cadastra um novo Usuario
        /// </summary>
        /// <param name="novoUsuarioPF">Objeto novoUsuarioPF que será cadastrado</param>
        void Cadastrar(UsuarioPF novoUsuarioPF);

        /// <summary>
        /// Atualiza um Usuario existente
        /// </summary>
        /// <param name="cpf">ID do Usuario que será atualizado</param>
        /// <param name="UsuarioPFAtualizado">Objeto UsuarioPFAtualizado que será alterado</param>
        void Atualizar(int id, UsuarioPF UsuarioPFAtualizado);

        /// <summary>
        /// Deleta um Usuario existente
        /// </summary>
        /// <param name="cpf">ID do Usuario que será deletado</param>
        void Deletar(int cpf);

    }
}
