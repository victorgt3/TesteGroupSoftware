using GroupSoftware.Domain.Dto.ProdutoDto;
using GroupSoftware.Repository.Entities;
using GroupSoftware.Repository.Repositories.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GroupSoftware.Api.Controllers
{
    [ApiController]
    [Route("ecommerce/v1/[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly IGenericRepository<Produto> _repositoryProduto;
        public ProdutosController(IGenericRepository<Produto> repositoryProduto)
        {
            _repositoryProduto = repositoryProduto;
        }

        [HttpGet]
        public virtual async Task<ActionResult<ProdutoDto>> Get()
        {

            return Ok(await _repositoryProduto.GetAllAsync());
        }
    }
}
