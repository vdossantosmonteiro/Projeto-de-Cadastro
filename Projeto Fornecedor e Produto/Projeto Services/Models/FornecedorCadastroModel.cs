using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Projeto_Services.Models
{
    public class FornecedorCadastroModel
    {
        [Required(ErrorMessage ="Campo obrigatório")]
        public string Nome { get; set; }
    }
}
