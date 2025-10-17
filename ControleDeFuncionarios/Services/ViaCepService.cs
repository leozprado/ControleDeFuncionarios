using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeFuncionarios.Services
{
    /// <summary>
    /// Classe de serviço para integração com a API ViaCEP
    /// </summary>
    public class ViaCepService
    {
        /// <summary>
        /// Metodo para obter o endereço a partir do CEP
        /// </summary>
  
        public string ObterEndereco(string cep)
        {
            using (var client = new HttpClient())
            {
                //fazendo uma chamada para o serciço de consulta do ViaCEP
                var response = client.GetAsync($"https://viacep.com.br/ws/{cep}/json/").Result;

                //retornando o conteúdo JSON obtido da consulta
                return response.Content.ReadAsStringAsync().Result;
            }
        }
    }
}
