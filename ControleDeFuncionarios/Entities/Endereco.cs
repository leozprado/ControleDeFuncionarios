using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeFuncionarios.Entities
{
    /// <summary>
    /// Modelo de dados de Endereço
    /// </summary>
    public class Endereco
    {
        #region Propriedades da entidade

        public Guid Id { get; set; } = Guid.NewGuid();
        public string Logradouro { get; set; } = string.Empty;

        public string Numero { get; set; } = string.Empty;

        public string Bairro { get; set; } = string.Empty;

        public string Localidade { get; set; } = string.Empty;

        public string Uf { get; set; } = string.Empty;

        public string Cep { get; set; } = string.Empty;


        #endregion

    }
}
