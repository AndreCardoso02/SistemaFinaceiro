using Domain.Interfaces.ICategoria;
using Domain.Interfaces.InterfaceServicos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly InterfaceCategoria _InterfaceCategoria;
        private readonly ICategoriaServico _ICategoriaServico;
        public CategoriaController(ICategoriaServico iCategoriaServico, InterfaceCategoria interfaceCategoria)
        {
            _ICategoriaServico = iCategoriaServico;
            _InterfaceCategoria = interfaceCategoria;
        }

        [HttpGet("/api/ListarCategoriasUsuario")]
        [Produces("application/json")]
        public async Task<object> ListarCategoriasUsuario(string emailUsuario)
        {
            return await _InterfaceCategoria.ListarCategoriasUsuario(emailUsuario);
        }
    }
}
