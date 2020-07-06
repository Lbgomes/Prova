using Prova.Models;
using System.Collections.Generic;

interface IusuarioPjRepository
{
    /// <summary>
    /// Lista todos os Usuarios
    /// </summary>
    /// <returns>Uma lista de Usuarios</returns>
    List<UsuarioPJ> Listar();

    /// <summary>
    /// Busca um Usuario através do ID
    /// </summary>
    /// <param name="cnpj">ID do Usuario que será buscado</param>
    /// <returns>Um Usuario buscado</returns>
    UsuarioPJ BuscarPorCnpj(int cnpj);

    /// <summary>
    /// Cadastra um novo Usuario
    /// </summary>
    /// <param name="novoUsuarioPJ">Objeto novoUsuarioPJ que será cadastrado</param>
    void Cadastrar(UsuarioPJ novoUsuarioPJ);

    /// <summary>
    /// Atualiza um Usuario existente
    /// </summary>
    /// <param name="cnpj">ID do Usuario que será atualizado</param>
    /// <param name="UsuarioPJAtualizado">Objeto UsuarioPJAtualizado que será alterado</param>
    void Atualizar(int cnpj, UsuarioPJ UsuarioPJAtualizado);

    /// <summary>
    /// Deleta um Usuario existente
    /// </summary>
    /// <param name="cnpj">ID do Usuario que será deletado</param>
    void Deletar(int cnpj);

}