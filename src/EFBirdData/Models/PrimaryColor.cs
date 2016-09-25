using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFBirdData.Models
{
    [Table("PrimaryColors")]
    public class PrimaryColor
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Bird> Birds { get; set; }

    }
}
