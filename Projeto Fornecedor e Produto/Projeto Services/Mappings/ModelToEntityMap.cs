using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Projeto.Data.Entities;
using Projeto_Services.Models;

namespace Projeto_Services.Mappings
{
    public class ModelToEntityMap : Profile
    {
        public ModelToEntityMap()
        {
            CreateMap<FornecedorCadastroModel, Fornecedor>();
            CreateMap<FornecedorEdicaoModel, Fornecedor>();

            CreateMap<ProdutoCadastroModel, Produto>();
            CreateMap<ProdutoEdicaoModel, Produto>();
        }
    }
}
