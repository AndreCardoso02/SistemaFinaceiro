﻿using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.InterfaceServicos
{
    public interface IDespesaServico
    {
        Task AdicionarDespesa(Despesa despesa);
        Task ActualizarDespesa(Despesa despesa);
        Task<object> CarregaGraficos(string emailUsuario);
    }
}
