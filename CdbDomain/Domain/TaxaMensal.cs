
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CdbDomain.Domain
{
    public class TaxaMensal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public decimal Taxa { get; set; }
        public int Meses { get; set; }
    }
}
