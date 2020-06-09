using Projeto.Data.Contracts;
using Projeto.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace Projeto.Data.Repositories
{
    public class FornecedorRepository : IFornecedorRepository
    {
        private readonly string connectionString;

        public FornecedorRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Inserir(Fornecedor obj)
        {
            var query = "insert into Fornecedor(Nome) values(@Nome)";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(query, obj);
            }
        }

        public void Alterar(Fornecedor obj)
        {
            var query = "update Fornecedor set Nome = @Nome where IdForncedor = @IdFornecedor";

            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Execute(query, obj);
            }
        }

        public void Excluir(int id)
        {
            var query = "delete from Fornecedor where IdFornecedor = @IdFornecedor";

            using(var connection = new SqlConnection(connectionString))
            {
                connection.Execute(query, new { IdFornecedor = id });
            }
        }

        public List<Fornecedor> ObterTodos()
        {
            var query = "select*from Fornecedor";

            using(var connection = new SqlConnection(connectionString))
            {
                return connection.Query<Fornecedor>(query).ToList();
            }
        }

        public Fornecedor ObterPorId(int id)
        {
            var query = "select*from Fornecedor where IdFornecedor = @IdFornecedor";
            
            using(var connection = new SqlConnection(connectionString))
            {
                return connection.Query<Fornecedor>(query, new { IdFornecedor = id }).SingleOrDefault();
            }
        }

        
    }
}
