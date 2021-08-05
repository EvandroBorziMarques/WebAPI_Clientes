using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI_Clientes.Models
{
    public class Clientes
    {
        [Key]
        public string Email { get; set; }
        public string Nome { get; set; }
        public string Logotipo { get; set; }

        [ForeignKey("Logradouro")]
        public int IdLogradouro { get; set; }
        public Logradouro Logradouro { get; set; }

        public Clientes(string email, string nome, string logotipo, int idLogradouro)
        {
            Email = email;
            Nome = nome;
            Logotipo = logotipo;
            IdLogradouro = idLogradouro;
        }

        public Clientes()
        {
        }
    }
}
