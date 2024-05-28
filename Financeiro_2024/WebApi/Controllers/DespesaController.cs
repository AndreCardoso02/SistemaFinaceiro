﻿using Domain.Interfaces.ICategoria;
using Domain.Interfaces.IDespesa;
using Domain.Interfaces.InterfaceServicos;
using Domain.Servicos;
using Entities.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DespesaController : ControllerBase
    {
        private readonly InterfaceDespesa _InterfaceDespesa;
        private readonly IDespesaServico _IDespesaServico;

        public DespesaController(InterfaceDespesa interfaceDespesa, IDespesaServico iDespesaServico)
        {
            _InterfaceDespesa = interfaceDespesa;
            _IDespesaServico = iDespesaServico;
        }

        [HttpGet("/api/ListarDispesasUsuario")]
        [Produces("application/json")]
        public async Task<object> ListarDispesasUsuario(string emailUsuario)
        {
            return await _InterfaceDespesa.ListarDispesasUsuario(emailUsuario);
        }

        [HttpGet("/api/ListarDispesasNaoPagasUsuario")]
        [Produces("application/json")]
        public async Task<object> ListarDispesasNaoPagasUsuario(string emailUsuario)
        {
            return await _InterfaceDespesa.ListarDispesasNaoPagasUsuario(emailUsuario);
        }

        [HttpPost("/api/AdicionarDespesa")]
        [Produces("application/json")]
        public async Task<object> AdicionarDespesa(Despesa despesa)
        {
            await _IDespesaServico.AdicionarDespesa(despesa);
            return Task.FromResult(despesa);
        }

        [HttpPut("/api/ActualizarDespesa")]
        [Produces("application/json")]
        public async Task<object> ActualizarDespesa(Despesa despesa)
        {
            await _IDespesaServico.ActualizarDespesa(despesa);
            return Task.FromResult(despesa);
        }
    }
}
