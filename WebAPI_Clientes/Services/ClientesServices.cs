using System.Linq;
using System.Collections.Generic;
using WebAPI_Clientes.Data;
using WebAPI_Clientes.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System;

namespace WebAPI_Clientes.Services
{
    public class ClientesServices
    {
        private readonly WebAPI_ClientesContext _context;

        public ClientesServices(WebAPI_ClientesContext context)
        {
            _context = context;
        }
        public ClientesServices()
        {
        }

        public List<Clientes> GetClientes()
        {
            return _context.Clientes.ToList();
        }


        public void PutClient(Clientes clientes)
        {
            using (var connection = new SqlConnection("server=DESKTOP-JERKDL2\\SQLEXPRESS; database=produtosdb; user=sa; password=123456; persist security info=False; initial catalog=WebAPI"))
            {
                try
                {
                    string sql = "UPDATE dbo.Clientes SET Email = @email, Nome = @nome, Logotipo = @logotipo, IdLogradouro = @idLogradouro;";

                    DynamicParameters param = new DynamicParameters();
                    param.Add("email", clientes.Email);
                    param.Add("nome", clientes.Nome);
                    param.Add("logotipo", clientes.Logotipo);
                    param.Add("idLogradouro", clientes.IdLogradouro);


                    connection.Query(sql, param);
                }
                catch (Exception Ex)
                {

                }

                finally
                {
                }


            }
        }





        public void PostClient(Clientes clientes)
        {
            using (var connection = new SqlConnection("server=DESKTOP-JERKDL2\\SQLEXPRESS; database=produtosdb; user=sa; password=123456; persist security info=False; initial catalog=WebAPI"))
            {
                try
                {
                    string sql = "INSERT INTO dbo.Clientes(Email, Nome, Logotipo, IdLogradouro) VALUES(@email, @nome, @logotipo, @idLogradouro);";

                    DynamicParameters param = new DynamicParameters();
                    param.Add("email", clientes.Email);
                    param.Add("nome", clientes.Nome);
                    param.Add("logotipo", clientes.Logotipo);
                    param.Add("idLogradouro", clientes.IdLogradouro);

                    
                    connection.Query(sql, param);
                }
                catch (Exception Ex)
                {

                }

                finally
                {
                }

                
            }
        }
    }
}
