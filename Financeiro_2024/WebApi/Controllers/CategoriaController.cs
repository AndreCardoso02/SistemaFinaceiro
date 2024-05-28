using Domain.Interfaces.ICategoria;
using Domain.Interfaces.InterfaceServicos;
using Entities.Entidades;
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

        [HttpPost("/api/AdicionarCategoria")]
        [Produces("application/json")]
        public async Task<object> AdicionarCategoria(Categoria categoria)
        {
            await _ICategoriaServico.AdicionarCategoria(categoria);
            return Task.FromResult(categoria);
        }

        [HttpPut("/api/ActualizarCategoria")]
        [Produces("application/json")]
        public async Task<object> ActualizarCategoria(Categoria categoria)
        {
            await _ICategoriaServico.ActualizarCategoria(categoria);
            return Task.FromResult(categoria);
        }

        [HttpGet("/api/ObterCategoria")]
        [Produces("application/json")]
        public async Task<object> ObterCategoria(int id)
        {
            return await _InterfaceCategoria.GetEntityById(id);
        }

        [HttpDelete("/api/RemoverCategoria")]
        [Produces("application/json")]
        public async Task<object> RemoverCategoria(int id)
        {
            try
            {
                var categoria = await _InterfaceCategoria.GetEntityById(id);
                await _InterfaceCategoria.Delete(categoria);
                return true.ToString();
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
