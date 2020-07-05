using Microsoft.Data.SqlClient;
using Prova.Interfaces;
using Prova.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prova.Repository
{
    public class UsuarioPfRepository : IusuarioPfRepository
    {
        /// <summary>
        /// String de conexão com o banco de dados que recebe os parâmetros
        /// </summary>
        //private string stringConexao = "Data Source=DESKTOP-NJ6LHN1\\SQLDEVELOPER; initial catalog=InLock_Games; integrated security=true;";
        private string stringConexao = "Data Source=LAB08DESK2301\\SQLEXPRESS; initial catalog=SQLQuery1; user Id=sa; pwd=sa@132";

        /// <summary>
        /// Atualiza um UsuarioPF existente
        /// </summary>
        /// <param name="cpf">cpf do usuario que será atualizado</param>
        /// <param name="UsuarioPfAtualizado">Objeto UsuarioPfAtualizado que será alterado</param>
        public void Atualizar(int cpf, UsuarioPF UsuarioPFAtualizado)
        {
            // Declara a conexão passando a string de conexão
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query que será executada
                string queryUpdate = "UPDATE UsuarioPF " +
                                     "SET NomeUsuario = @NomeUsuario, IdTipo = @IdTipo, NumeroCpf = @NumeroCpf, Telefone = @Telefone " +
                                     "WHERE IdUsuarioPF = @NumeroCpf";

                // Declara o SqlCommand passando o comando a ser executado e a conexão
                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    // Passa os valores dos parâmetros
                    cmd.Parameters.AddWithValue("@IdUsuarioPF", UsuarioPFAtualizado.IdUsuarioPf);
                    cmd.Parameters.AddWithValue("@NomeUsuario", UsuarioPFAtualizado.NomeUsuario);
                    cmd.Parameters.AddWithValue("@IdTipo", UsuarioPFAtualizado.IdTipo);
                    cmd.Parameters.AddWithValue("@NumeroCpf", UsuarioPFAtualizado.NumeroCpf);
                    cmd.Parameters.AddWithValue("@Telefone", UsuarioPFAtualizado.Telefone);

                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa o comando
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Busca um usuario através do cpf
        /// </summary>
        /// <param name="cpf">ID do usuario que será buscado</param>
        /// <returns>Um usuario buscado</returns>
        public UsuarioPF BuscarPorCpf(int cpf)
        {
            // Declara a conexão passando a string de conexão
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query que será executada
                string querySelectById = "SELECT *" +
                                         "FROM UsuarioPF" +
                                         "WHERE IdUsuarioPF = @NumeroCpf";

                // Abre a conexão com o banco de dados
                con.Open();

                // Declara o SqlDataReader para receber os dados do banco de dados
                SqlDataReader rdr;

                // Declara o SqlCommand passando o comando a ser executado e a conexão
                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    // Passa o valor do parâmetro
                    cmd.Parameters.AddWithValue("@NumeroCpf", cpf);

                    // Executa a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();

                    // Caso o resultado da query possua registro
                    if (rdr.Read())
                    {
                        // Instancia um objeto usuario 
                        UsuarioPF PF = new UsuarioPF
                        {
                            // Atribui às propriedades os valores das colunas da tabela do banco
                            IdUsuarioPf = Convert.ToInt32(rdr["IdUsuarioPf"]),
                            NomeUsuario = rdr["NomeUsuario"].ToString(),
                            NumeroCpf = Convert.ToInt32(rdr["NumeroCpf"]),
                            Telefone = Convert.ToInt32(rdr["Telefone"]),
                            IdTipo = Convert.ToInt32(rdr["IdTipo"].ToString()
                            )
                        };

                        // Retorna o usuario buscado
                        return PF;
                    }

                    // Caso o resultado da query não possua registros, retorna null
                    return null;
                }
            }
        }

        /// <summary>
        /// Cadastra um novo usuario
        /// </summary>
        /// <param name="novoUusarioPF">Objeto novoUsuarioPF que será cadastrado</param>
        public void Cadastrar(UsuarioPF novoUsuarioPF)
        {
            // Declara a SqlConnection passando a string de conexão
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query que será executada
                string queryInsert = "INSERT INTO UsuarioPF(NomeUsuario, IdTipo, NumeroCpf, Telefone)" +
                                    "VALUES(@NomeUsuario, @IdTipo, @NumeroCpf, @Telefone)";

                // Declara o comando passando a query e a conexão
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    // Passa os valores dos parâmetros
                    cmd.Parameters.AddWithValue("@IdUsuarioPF", novoUsuarioPF.IdUsuarioPf);
                    cmd.Parameters.AddWithValue("@NomeUsuario", novoUsuarioPF.NomeUsuario);
                    cmd.Parameters.AddWithValue("@IdTipo", novoUsuarioPF.IdTipo);
                    cmd.Parameters.AddWithValue("@NumeroCpf", novoUsuarioPF.NumeroCpf);
                    cmd.Parameters.AddWithValue("@Telefone", novoUsuarioPF.Telefone);

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
        /// <param name="cpf">cpf do usuario que será deletado</param>
        public void Deletar(int cpf)
        {
            // Declara a conexão passando a string de conexão
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query que será executada passando o valor como parâmetro
                string queryDelete = "DELETE FROM UsuarioPF WHERE NumeroCpf = @NumeroCpf";

                // Declara o comando passando a query e a conexão
                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    // Passa o valor do parâmetro
                    cmd.Parameters.AddWithValue("@NumeroCpf", cpf);

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
        public List<UsuarioPF> Listar()
        {
            // Cria uma lista usuários onde serão armazenados os dados
            List<UsuarioPF> UsPF = new List<UsuarioPF>();

            // Declara a SqlConnection passando a string de conexão
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a instrução a ser executada
                string querySelectAll = "SELECT * FROM UsuarioPF";

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
                        UsuarioPF UPF = new UsuarioPF
                        {
                            // Atribui às propriedades os valores das colunas da tabela do banco
                            IdUsuarioPf = Convert.ToInt32(rdr["IdUsuarioPf"]),
                            NomeUsuario = rdr["NomeUsuario"].ToString(),
                            NumeroCpf = Convert.ToInt32(rdr["NumeroCpf"]),
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
