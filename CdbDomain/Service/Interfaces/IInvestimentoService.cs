using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CdbDomain.Service.Interfaces
{
    public interface IInvestimentoService
    {
        decimal CalcularTaxa(int mes, decimal valorBruto, decimal valor);
        decimal CalcularValorBruto(decimal valor, int mes);
    }
}
