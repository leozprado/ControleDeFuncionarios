using ControleDeFuncionarios.Entities;
using ControleDeFuncionarios.Enums;
using ControleDeFuncionarios.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ControleDeFuncionarios.Controllers
{
    /// <summary>
    /// Controlador de Funcionários
    /// </summary>
    public class FuncionarioController
    {
        /// <summary>
        /// Cadastra um novo funcionário no sistema
        /// </summary>
        public void CadastrarFuncionario()
        {
            try
            {
                Console.WriteLine("\nCADASTRO DE FUNCIONÁRIO:\n");

                //criando um objeto da classe funcionario                
                    var funcionario = new Funcionario();

                Console.Write("NOME DO FUNCIONÁRIO....: ");
                funcionario.Nome = Console.ReadLine() ?? string.Empty;

                Console.Write("CPF.............: ");
                funcionario.Cpf = Console.ReadLine() ?? string.Empty;

                Console.Write("MATRÍCULA.............: ");
                funcionario.Matricula = Console.ReadLine() ?? string.Empty;

                Console.Write("DATA DE ADMISSÃO...........: ");
                funcionario.DataAdmissao = DateTime.Parse(Console.ReadLine() ?? string.Empty);

                Console.Write("SALÁRIO.............: ");
                funcionario.Salario = decimal.Parse(Console.ReadLine() ?? string.Empty);

                Console.Write("INFORME O CEP.........:");
                var cep = Console.ReadLine() ?? string.Empty;

                //Criando um objeto da classe de serviço ViaCepService
                var viaCepService = new ViaCepService();

                //consultando o endereço a partir do CEP
                var endereco = viaCepService.ObterEndereco(cep);

                //imprimindo o endereço no console
                Console.WriteLine("\nENDEREÇO ENCONTRADO: \n");
                Console.WriteLine(endereco);

                //lendo os dados do endereço contido no json retornado pelo via cep
                var json = JsonDocument.Parse(endereco);
                funcionario.Endereco.Logradouro = json.RootElement.GetProperty("logradouro").GetString() ?? string.Empty;
                funcionario.Endereco.Bairro = json.RootElement.GetProperty("bairro").GetString() ?? string.Empty;
                funcionario.Endereco.Localidade = json.RootElement.GetProperty("localidade").GetString() ?? string.Empty;
                funcionario.Endereco.Uf = json.RootElement.GetProperty("uf").GetString() ?? string.Empty;
                funcionario.Endereco.Cep = json.RootElement.GetProperty("cep").GetString() ?? string.Empty;






                Console.Write("\nINFORME O NUMERO DO ENDEREÇO:");
                funcionario.Endereco.Numero = Console.ReadLine() ?? string.Empty;

                Console.WriteLine("\nCARGOS:");
                foreach (var item in Enum.GetValues(typeof(Cargo))) //listando os cargos
                {
                    var valor = (int)item; //capturando o valor de cada opção do enum
                    var nome = item.ToString(); //capturando o nome de cada opção do enum

                    Console.WriteLine($"\t{valor} - {nome}");
                }

                Console.Write("\nINFORME O CARGO DESEJADO: ");
                funcionario.Cargo = (Cargo)int.Parse(Console.ReadLine() ?? string.Empty);

                //Enviando para o banco de dados (repositório)
                var funcionarioRepository = new Repositories.FuncionarioRepository();
                funcionarioRepository.Inserir(funcionario);

                Console.WriteLine($"\nFuncionário {funcionario.Nome} cadastrado com sucesso!" );


            }

            catch (Exception e)
            {

                Console.WriteLine($"\nFalha ao cadastrar funcionário: {e.Message}" );
            }
        }
    }
}
