using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CdbDomain.Domain
{
    public  class TaxaBancaria
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public decimal Cdb { get; set; }
        public decimal Tb { get; set; }
    }
}
