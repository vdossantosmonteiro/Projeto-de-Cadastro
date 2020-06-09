using Dapper;
using Projeto.Data.Contracts;
using Projeto.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Projeto.Data.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly string connectionString;

        public ProdutoRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Inserir(Produto obj)
        {
            var query = "insert into Produto(Nome, Preco, Quantidade, IdFornecedor) " +
                "values(@Nome, @Preco, @Quantidade, @IdFornecedor)";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(query, obj);
            }
        }

        public void Alterar(Produto obj)
        {
            var query = "update Produto set Nome = @Nome, Preco = @Preco, Quantidade = @Quantidade, IdFornecedor = @IdFornecedor " +
                "  where IdProduto = @IdProduto";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Execute(query, obj);
            }
        }

        public void Excluir(int id)
        {
            var query = "delete from Produto where IdProduto = @IdProduto";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(query, new { IdProduto = id });
            }
        }

        public List<Produto> ObterTodos()
        {
            var query = "select*from Produto";

            using (var connection = new SqlConnection(connectionString))
            {
                return connection.Query<Produto>(query).ToList();
            }
        }

        public Produto ObterPorId(int id)
        {
            var query = "select*from Produto where IdProduto = @IdProduto";

            using (var connection = new SqlConnection(connectionString))
            {
                return connection.Query<Produto>(query, new { IdProduto = id }).SingleOrDefault();
            }
        }


    }
}
