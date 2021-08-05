using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace WebAPI_Clientes.Models
{
    public class Logradouro
    {
        [Key]
        public int _idLogradouro { get; private set; }
        public string Cep { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Localidade { get; set; }
        public string Uf { get; set; }

        public Logradouro(string cep, string endereco, string numero, string complemento, string bairro, string localidade, string uf)
        {
            Cep = cep;
            Endereco = endereco;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Localidade = localidade;
            Uf = uf;
        }
    }
}
