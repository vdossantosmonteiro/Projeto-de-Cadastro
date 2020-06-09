using AutoMapper;
using Projeto.Data.Entities;
using Projeto_Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Services.Mappings
{
    public class EntityToModel : Profile
    {
        public EntityToModel()
        {
            CreateMap<Fornecedor, FornecedorConsultaModel>();

            CreateMap<Produto, ProdutoConsultaModel>();
        }
    }
}
