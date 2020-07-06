using Microsoft.Data.SqlClient;
using Prova.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prova.Repository
{
    public class UsuarioPjRepository: IusuarioPjRepository
    {  /// <summary>
       /// String de conexão com o banco de dados que recebe os parâmetros
       /// </summary>
        //private string stringConexao = "Data Source=DESKTOP-NJ6LHN1\\SQLDEVELOPER; initial catalog=InLock_Games; integrated security=true;";
        private string stringConexao = "Data Source=LAB08DESK2301\\SQLEXPRESS; initial catalog=Prova; user Id=sa; pwd=sa@132";

        /// <summary>
        /// Atualiza um UsuarioPJ existente
        /// </summary>
        /// <param name="cnpj">cnpj do usuario que será atualizado</param>
        /// <param name="UsuarioPjAtualizado">Objeto UsuarioPJAtualizado que será alterado</param>
        public void Atualizar(int cnpj, UsuarioPJ UsuarioPjAtualizado)
        {
            // Declara a conexão passando a string de conexão
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query que será executada
                string queryUpdate = "UPDATE UsuarioPJ " +
                                     "SET NomeUsuario = @NomeUsuario, IdTipo = @IdTipo, NumeroCnpj = @NumeroCnpj, Telefone = @Telefone " +
                                     "WHERE UsuarioPJ = @NumeroCnpj";

                // Declara o SqlCommand passando o comando a ser executado e a conexão
                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    // Passa os valores dos parâmetros
                    cmd.Parameters.AddWithValue("@IdUsuarioPJ", UsuarioPjAtualizado.IdUsuarioPj);
                    cmd.Parameters.AddWithValue("@NomeUsuario", UsuarioPjAtualizado.NomeUsuario);
                    cmd.Parameters.AddWithValue("@IdTipo", UsuarioPjAtualizado.IdTipo);
                    cmd.Parameters.AddWithValue("@NumeroCnpj", UsuarioPjAtualizado.NumeroCnpj);
                    cmd.Parameters.AddWithValue("@Telefone", UsuarioPjAtualizado.Telefone);

                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa o comando
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Busca um usuario através do cnpj
        /// </summary>
        /// <param name="cnpj">ID do usuario que será buscado</param>
        /// <returns>Um usuario buscado</returns>
        public UsuarioPJ BuscarPorCnpj(int cnpj)
        {
            // Declara a conexão passando a string de conexão
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query que será executada
                string querySelectById = "SELECT *" +
                                         "FROM UsuarioPJ" +
                                         "WHERE IdUsuarioPJ = @NumeroCnpj";

                // Abre a conexão com o banco de dados
                con.Open();

                // Declara o SqlDataReader para receber os dados do banco de dados
                SqlDataReader rdr;

                // Declara o SqlCommand passando o comando a ser executado e a conexão
                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    // Passa o valor do parâmetro
                    cmd.Parameters.AddWithValue("@NumeroCnpj", cnpj);

                    // Executa a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();

                    // Caso o resultado da query possua registro
                    if (rdr.Read())
                    {
                        // Instancia um objeto usuario 
                        UsuarioPJ PJ = new UsuarioPJ
                        {
                            // Atribui às propriedades os valores das colunas da tabela do banco
                            IdUsuarioPj = Convert.ToInt32(rdr["IdUsuarioPJj"]),
                            NomeUsuario = rdr["NomeUsuario"].ToString(),
                            NumeroCnpj = Convert.ToInt32(rdr["NumeroCnpj"]),
                            Telefone = Convert.ToInt32(rdr["Telefone"]),
                            IdTipo = Convert.ToInt32(rdr["IdTipo"].ToString()
                            )
                        };

                        // Retorna o usuario buscado
                        return PJ;
                    }

                    // Caso o resultado da query não possua registros, retorna null
                    return null;
                }
            }
        }

        /// <summary>
        /// Cadastra um novo usuario
        /// </summary>
        /// <param name="novoUusarioPF">Objeto novoUsuarioPJ que será cadastrado</param>
        public void Cadastrar(UsuarioPJ novoUsuarioPJ)
        {
            // Declara a SqlConnection passando a string de conexão
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query que será executada
                string queryInsert = "INSERT INTO UsuarioPJ(NomeUsuario, IdTipo, NumeroCnpj, Telefone)" +
                                    "VALUES(@NomeUsuario, @IdTipo, @NumeroCnpj, @Telefone)";

                // Declara o comando passando a query e a conexão
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    // Passa os valores dos parâmetros
                    cmd.Parameters.AddWithValue("@IdUsuarioPJ", novoUsuarioPJ.IdUsuarioPj);
                    cmd.Parameters.AddWithValue("@NomeUsuario", novoUsuarioPJ.NomeUsuario);
                    cmd.Parameters.AddWithValue("@IdTipo", novoUsuarioPJ.IdTipo);
                    cmd.Parameters.AddWithValue("@NumeroCnpj", novoUsuarioPJ.NumeroCnpj);
                    cmd.Parameters.AddWithValue("@Telefone", novoUsuarioPJ.Telefone);

                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa o comando
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Deleta um usuario existente
        /// </summary>
        /// <param name="cnpj">cnpj do usuario que será deletado</param>
        public void Deletar(int cnpj)
        {
            // Declara a conexão passando a string de conexão
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query que será executada passando o valor como parâmetro
                string queryDelete = "DELETE FROM UsuarioPJ WHERE NumeroCnpj = @NumeroCnpj";

                // Declara o comando passando a query e a conexão
                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    // Passa o valor do parâmetro
                    cmd.Parameters.AddWithValue("@NumeroCnpj", cnpj);

                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa o comando
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Lista todos os usuarios
        /// </summary>
        /// <returns>Uma lista de usuarios</returns>
        public List<UsuarioPJ> Listar()
        {
            // Cria uma lista usuários onde serão armazenados os dados
            List<UsuarioPJ> UsPF = new List<UsuarioPJ>();

            // Declara a SqlConnection passando a string de conexão
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a instrução a ser executada
                string querySelectAll = "SELECT * FROM UsuarioPJ";

                // Abre a conexão com o banco de dados
                con.Open();

                // Declara o SqlDataReader para receber os dados do banco de dados
                SqlDataReader rdr;

                // Declara o SqlCommand passando o comando a ser executado e a conexão
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    // Executa a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();

                    // Enquanto houver registros para serem lidos no rdr, o laço se repete
                    while (rdr.Read())
                    {
                        // Instancia um objeto UPF 
                        UsuarioPJ UPF = new UsuarioPJ
                        {
                            // Atribui às propriedades os valores das colunas da tabela do banco
                            IdUsuarioPj = Convert.ToInt32(rdr["IdUsuarioPJ"]),
                            NomeUsuario = rdr["NomeUsuario"].ToString(),
                            NumeroCnpj = Convert.ToInt32(rdr["NumeroCnpj"]),
                            Telefone = Convert.ToInt32(rdr["Telefone"]),
                            IdTipo = Convert.ToInt32(rdr["IdTipo"].ToString()

                            )
                        };

                        // Adiciona o usuario criado à lista UsPF
                        UsPF.Add(UPF);
                    }
                }
            }

            // Retorna a lista de usuarios
            return UsPF;
        }

    }
}
