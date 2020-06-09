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
    public class ProdutoController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(ProdutoCadastroModel model,
            [FromServices] IProdutoRepository repository,
            [FromServices] IMapper mapper)
        {
            if (!ModelState.IsValid)
                return BadRequest("Ocorreram erro de validações");

            try
            {

                var produto = mapper.Map<Produto>(model);
                repository.Inserir(produto);

                return Ok("Produto Cadastrado com sucesso");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

        }

        [HttpPut]
        public IActionResult Put(ProdutoEdicaoModel model,
            [FromServices] IProdutoRepository repository,
            [FromServices] IMapper mapper)
        {
            if (!ModelState.IsValid)
                return BadRequest("Ocorreram erros de validações");

            try
            {
                var produto = mapper.Map<Produto>(model);
                repository.Alterar(produto);

                return Ok("Produto atualizado com sucesso");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id,
            [FromServices] IProdutoRepository repository)
        {
            try
            {
                repository.Excluir(id);
                return Ok("Produto excluído com sucesso");
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }

           
        }

        [HttpGet]
        public IActionResult GetAll(
            [FromServices] IProdutoRepository repository,
            [FromServices] IMapper mapper)
        {
            try
            {
                var lista = mapper.Map<List<ProdutoConsultaModel>>(repository.ObterTodos());

                return Ok(lista);
                
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id, [FromServices] IProdutoRepository repository,
            [FromServices] IMapper mapper)
        {
            try
            {
                var produto = mapper.Map<ProdutoConsultaModel>(repository.ObterPorId(id));

                return Ok(produto);
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
            
        }
    }
}
