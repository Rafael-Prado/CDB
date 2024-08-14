using CdbDomain.Domain;
using FluentValidation;

namespace CdbDomain.Validador
{
    public  class InvestimentoValidador: AbstractValidator<Investimento>
    {
        public InvestimentoValidador()
        {
            RuleFor(x => x.Valor).NotNull().NotEqual(0).WithMessage(x => $"Valor nao pode ser 0 ou vazio");
            RuleFor(x => x.Mes).NotNull().NotEqual(0).WithMessage(x => $"Mes nao pode ser 0 ou vazio")
                .Must(MesMaiorQue12).WithMessage(x => $"Mes nao pode ser maior que 12");
            
        }

        private static bool MesMaiorQue12(int mes)
        {
            return mes < 12;
        }
    }
}
