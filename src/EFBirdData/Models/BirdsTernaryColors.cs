using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFBirdData.Models
{
    [Table("BirdsTernaryColors")]
    public class BirdsTernaryColors
    {
        [Key]
        public int Id { get; set; }

        public int BirdId { get; set; }
        public Bird Bird { get; set; }

        public int TernaryColorId { get; set; }
        public TernaryColor TernaryColor { get; set; }
    }

}
