using CdbDomain.Domain;

namespace TestInvestimento.Moq
{
    public class InvestimentoModelBuild
    {
        public Investimento Build()
        {
            return new Investimento()
            {
                Valor = 100,
                Mes = 6
            };
        }
    }
}
