using CdbDomain.Repository.Interface;
using CdbInfra.Context;
using Microsoft.EntityFrameworkCore.Storage;

namespace CdbInfra.Repository
{
    public class InvestimentoRepository : IInvestimentoRepository
    {
        private readonly CdbContext _context;
        public InvestimentoRepository(CdbContext ctx)
        {
                _context = ctx;
        }     

        public decimal GetTaxaMes(int mes)
        {
            var taxas= _context.TaxaMensal.ToList();

            var taxa = taxas.Find(x => x.Meses == mes);
            var taxaAplicada = decimal.Zero;
            if (taxa == null)
            {
                taxaAplicada = taxas.First(x => x.Meses == 0).Taxa;
            }
            else {
                taxaAplicada = taxa.Taxa;
            }
            return taxaAplicada;
        }

        public Tuple<decimal, decimal> GetTbCdi()
        {
            var taxa = _context.TaxaBancarias.FirstOrDefault();
            if (taxa == null)
                return Tuple.Create(decimal.Zero, decimal.Zero);
            return Tuple.Create(taxa.Cdb, taxa.Tb);
        }
    }
}
