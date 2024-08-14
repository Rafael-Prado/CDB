using CdbDomain.Validador;
using TestInvestimento.Moq;
using Moq;
using CdbDomain.Service.Interfaces;

namespace TestInvestimento
{
    [TestClass]
    public class InvestimentoTeste
    {
        private InvestimentoValidador validador = new InvestimentoValidador();

        [TestMethod]
        public void Investimento_Nao_Deve_Ser_Valido()
        {
            var investimento = new InvestimentoModelBuild().Build();
            Assert.IsNotNull(investimento);


        }
        [TestMethod]
        public void Investimento_Deve_Ser_Valido()
        {
            var investimento = new InvestimentoModelBuild().Build();

            var result = validador.Validate(investimento);
            var erros = result.Errors.Select(a => a.ErrorMessage).ToList();
            Assert.AreEqual(0, erros.Count);
        }

        [TestMethod]
        public void Investimento_Valor_0()
        {
            var investimento = new InvestimentoModelBuild().Build();
            investimento.Valor = 0;

            var result = validador.Validate(investimento);
            var erros = result.Errors.Select(a => a.ErrorMessage).ToList();
            Assert.AreEqual(1, erros.Count);
            Assert.IsTrue(erros.Contains("Valor nao pode ser 0 ou vazio"));
        }
        [TestMethod]
        public void Investimento_Mes_0()
        {
            var investimento = new InvestimentoModelBuild().Build();
            investimento.Mes = 0;

            var result = validador.Validate(investimento);
            var erros = result.Errors.Select(a => a.ErrorMessage).ToList();
            Assert.AreEqual(1, erros.Count);
            Assert.IsTrue(erros.Contains("Mes nao pode ser 0 ou vazio"));
        }

        [TestMethod]
        public void Investimento_Mes_Maior_Que_12()
        {
            var investimento = new InvestimentoModelBuild().Build();
            investimento.Mes = 13;
            
            var result = validador.Validate(investimento);
            var erros = result.Errors.Select(a => a.ErrorMessage).ToList();
            Assert.AreEqual(1, erros.Count);
            Assert.IsTrue(erros.Contains("Mes nao pode ser maior que 12"));
        }

        [TestMethod]
        public void Investimento_Retorno_Valido()
        {
            decimal teste = 0;
            var investimento = new InvestimentoModelBuild().Build();
            var service = new Mock<IInvestimentoService>();
            service.Setup(r => r.CalcularValorBruto(investimento.Valor, investimento.Mes)).Returns(teste);
            var result = validador.Validate(investimento);
            var erros = result.Errors.Select(a => a.ErrorMessage).ToList();
            var valorBruto = service.Object.CalcularValorBruto(investimento.Valor, investimento.Mes);
            Assert.AreEqual(0,valorBruto);
            Assert.AreEqual(0, erros.Count);
        }

        [TestMethod]
        public void Investimento_Taxa_Retorno_Valido()
        {
            decimal teste = 10;
            decimal valorBruto = 10;
            var investimento = new InvestimentoModelBuild().Build();
            var service = new Mock<IInvestimentoService>();
            service.Setup(r => r.CalcularTaxa(investimento.Mes, valorBruto, investimento.Valor)).Returns(teste);
            var result = validador.Validate(investimento);
            var erros = result.Errors.Select(a => a.ErrorMessage).ToList();
            var valorTaxa = service.Object.CalcularTaxa(investimento.Mes, valorBruto, investimento.Valor);
            Assert.AreEqual(10, valorTaxa);
            Assert.AreEqual(0, erros.Count);
        }
    }
}