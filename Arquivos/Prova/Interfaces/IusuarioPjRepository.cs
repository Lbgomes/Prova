using Prova.Models;
using System.Collections.Generic;

interface IusuarioPjRepository
{
    /// <summary>
    /// Lista todos os jogos
    /// </summary>
    /// <returns>Uma lista de jogos</returns>
    List<UsuarioPJ> Listar();

    /// <summary>
    /// Busca um jogo através do ID
    /// </summary>
    /// <param name="cnpj">ID do jogo que será buscado</param>
    /// <returns>Um jogo buscado</returns>
    UsuarioPJ BuscarPorCnpj(int cnpj);

    /// <summary>
    /// Cadastra um novo jogo
    /// </summary>
    /// <param name="novoUsuarioPJ">Objeto novoJogo que será cadastrado</param>
    void Cadastrar(UsuarioPJ novoUsuarioPJ);

    /// <summary>
    /// Atualiza um jogo existente
    /// </summary>
    /// <param name="cnpj">ID do jogo que será atualizado</param>
    /// <param name="UsuarioPJAtualizado">Objeto jogoAtualizado que será alterado</param>
    void Atualizar(int cnpj, UsuarioPJ UsuarioPJAtualizado);

    /// <summary>
    /// Deleta um jogo existente
    /// </summary>
    /// <param name="cnpj">ID do jogo que será deletado</param>
    void Deletar(int cnpj);

}