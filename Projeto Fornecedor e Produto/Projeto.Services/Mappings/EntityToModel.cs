﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Projeto.Data.Entities;
using Projeto.Services.Models;

namespace Projeto.Services.Mappings
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
