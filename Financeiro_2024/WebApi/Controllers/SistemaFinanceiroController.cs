using Domain.Interfaces.InterfaceServicos;
using Domain.Interfaces.ISistemaFinanceiro;
using Entities.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SistemaFinanceiroController : ControllerBase
    {
        private readonly InterfaceSistemaFinanceiro _InterfaceSistemaFinanceiro;
        private readonly ISistemaFinanceiroServico _ISistemaFinanceiro;

        public SistemaFinanceiroController(ISistemaFinanceiroServico ISistemaFinanceiro, InterfaceSistemaFinanceiro InterfaceSistemaFinanceiro)
        {
            _ISistemaFinanceiro = ISistemaFinanceiro;
            _InterfaceSistemaFinanceiro = InterfaceSistemaFinanceiro;
        }

        [HttpGet("/api/ListarSistemasUsuario")]
        [Produces("application/json")]
        public async Task<object> ListarSistemasUsuario(string emailUsuario)
        {
            return await _InterfaceSistemaFinanceiro.ListarSistemasUsuario(emailUsuario);
        }

        [HttpPost("/api/AdicionarSistemasUsuario")]
        [Produces("application/json")]
        public async Task<object> AdicionarSistemasUsuario(SistemaFinanceiro sistemaFinanceiro)
        {
            await _ISistemaFinanceiro.AdicionarSistemaFinanceiro(sistemaFinanceiro);

            return Task.FromResult(sistemaFinanceiro);
        }

        [HttpPut("/api/ActualizarSistemaFinanceiro")]
        [Produces("application/json")]
        public async Task<object> ActualizarSistemaFinanceiro(SistemaFinanceiro sistemaFinanceiro)
        {
            await _ISistemaFinanceiro.ActualizarSistemaFinanceiro(sistemaFinanceiro);

            return Task.FromResult(sistemaFinanceiro);
        }

        [HttpGet("/api/ObterSistemaFinanceiro")]
        [Produces("application/json")]
        public async Task<object> ObterSistemaFinanceiro(int id)
        {
            return await _InterfaceSistemaFinanceiro.GetEntityById(id);
        }

        [HttpDelete("/api/RemoverSistemaFinanceiro")]
        [Produces("application/json")]
        public async Task<object> RemoverSistemaFinanceiro(int id)
        {
            try
            {
                var sistemaFinanceiro = await _InterfaceSistemaFinanceiro.GetEntityById(id);
                await _InterfaceSistemaFinanceiro.Delete(sistemaFinanceiro);
            }
            catch (Exception ex)
            {
                return false;
            }

            return true.ToString();
        }
    }
}
