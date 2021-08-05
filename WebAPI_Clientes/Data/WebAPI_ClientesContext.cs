using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_Clientes.Models;

namespace WebAPI_Clientes.Data
{
    public class WebAPI_ClientesContext : DbContext
    {
        public WebAPI_ClientesContext(DbContextOptions<WebAPI_ClientesContext> options)
                : base(options)
        {
        }

        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Logradouro> Logradouro { get; set; }
    }
}
