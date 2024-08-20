using CdbDomain.Repository.Interface;
using CdbInfra.Context;
using Microsoft.EntityFrameworkCore.Storage;

namespace CdbInfra.Repository
{
    public class InvestimentoRepository : IInvestimentoRepository
    {
        private const decimal TB = 1.08M;
        private const decimal CDI = 0.009M;
           

        public decimal GetTaxaMes(int mes)
        {
            var taxaAplicada = mes switch
            {
                <= 6 => 0.225M,
                <= 12 => 0.20M,
                <= 24 => 0.175M,
                _ => 0.15M
            };

            return taxaAplicada;
        }

        public Tuple<decimal, decimal> GetTbCdi()
        {
            return Tuple.Create(CDI, TB);
        }
    }
}
