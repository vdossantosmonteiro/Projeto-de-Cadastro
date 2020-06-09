using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Projeto.Services.Models
{
    public class ProdutoEdicaoModel
    {
        [Required(ErrorMessage ="Campo obrigatório")]
        public int IdProduto { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public int Quantidade { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public int IdFornecedor { get; set; }
    }
}
