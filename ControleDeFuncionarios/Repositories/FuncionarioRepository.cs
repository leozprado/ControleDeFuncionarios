using ControleDeFuncionarios.Entities;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ControleDeFuncionarios.Repositories
{
    /// <summary>
    ///   Repositorio de banco de dados para a entidade Funcionário
    /// </summary>
    public class FuncionarioRepository
    {
        /// <summary>
        /// Método para inserir um novo funcionário no banco de dados
        /// </summary>
        public void Inserir(Funcionario funcionario)
        {
            //declarar uma variavel para armazenar a connectionstring
            var connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BDFuncionarios;Integrated Security=True;";

            //Abrindo conexão com o banco de dados
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute("SP_INSERIR_FUNCIONARIO", 
               new 
               {
                   @NOME = funcionario.Nome,
                   @CPF = funcionario.Cpf,
                   @MATRICULA = funcionario.Matricula,
                   @DATAADMISSAO = funcionario.DataAdmissao,
                   @SALARIO = funcionario.Salario,
                   @CARGO = (int) funcionario.Cargo,
                   @LOGRADOURO = funcionario.Endereco.Logradouro,
                   @NUMERO = funcionario.Endereco.Numero,
                   @BAIRRO = funcionario.Endereco.Bairro,
                   @LOCALIDADE = funcionario.Endereco.Localidade,
                   @UF = funcionario.Endereco.Uf,
                   @CEP = funcionario.Endereco.Cep                  

                }, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
