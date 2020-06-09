using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto.Data.Contracts;
using Projeto.Data.Entities;
using Projeto.Services.Models;

namespace Projeto.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedorController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(FornecedorCadastroModel model,
            [FromServices] IFornecedorRepository repository,
            [FromServices] IMapper mapper)
        {
            if (!ModelState.IsValid)
                return BadRequest("Ocorreram erro de validações");

            try
            {
                var fornecedor = mapper.Map<Fornecedor>(model);
                repository.Inserir(fornecedor);

                return Ok("Fornecedor Cadastrado com sucesso");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

        }

        [HttpPut]
        public IActionResult Put(FornecedorEdicaoModel model,
            [FromServices] IFornecedorRepository repository,
            [FromServices] IMapper mapper)
        {
            if (!ModelState.IsValid)
                return BadRequest("Ocorreram erros de validações");

            try
            {
                var fornecedor = mapper.Map<Fornecedor>(model);
                repository.Alterar(fornecedor);

                return Ok("Fornecedor editado com sucesso");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id,
            [FromServices] IFornecedorRepository repository)
        {
            try
            {
                
                repository.Excluir(id);
                return Ok("Fornecedor excluído com sucesso");
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAll([FromServices] IFornecedorRepository repository,
            [FromServices] IMapper mapper)
        {
            try
            {
                var lista = mapper.Map<List<FornecedorConsultaModel>>(repository.ObterTodos());

                return Ok(lista);
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
         
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id,
            [FromServices] IFornecedorRepository repository,
            [FromServices] IMapper mapper) 
        {

            try
            {
                var fornecedor = mapper.Map<FornecedorConsultaModel>(repository.ObterPorId(id));
                return Ok(fornecedor);
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}