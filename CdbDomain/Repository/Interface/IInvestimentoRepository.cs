
namespace CdbDomain.Repository.Interface
{
    public  interface IInvestimentoRepository
    {
        Tuple<decimal, decimal> GetTbCdi();
        decimal GetTaxaMes(int mes);
    }
}
