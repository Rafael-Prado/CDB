using CdbDomain.Repository.Interface;
using CdbDomain.Service.Interfaces;

namespace CdbDomain.Service
{
    public  class InvestimentoService : IInvestimentoService
    {
        private readonly IInvestimentoRepository _investimentoRepository;

        public InvestimentoService(IInvestimentoRepository investimentoRepository)
        {
            _investimentoRepository = investimentoRepository;
        }

        public decimal CalcularTaxa(int mes, decimal valorBruto, decimal valor)
        {
            var saldoGanho = valorBruto - valor;
            decimal taxaAplicada = _investimentoRepository.GetTaxaMes(mes);            
            return saldoGanho * taxaAplicada;
        }

        public decimal CalcularValorBruto(decimal valor, int mes)
        {
            var resualtado = _investimentoRepository.GetTbCdi();

            decimal valorBruto = valor ;
            for (int i = 0; i < mes; i++) {

                valorBruto *= (1 + (resualtado.Item1 * resualtado.Item2));            
            }
            return valorBruto;
        }
    }
}
