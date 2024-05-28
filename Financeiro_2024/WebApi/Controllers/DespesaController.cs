using Domain.Interfaces.IDespesa;
using Domain.Interfaces.InterfaceServicos;
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

    }
}
