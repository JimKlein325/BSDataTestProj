using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFBirdData.Models
{
    [Table("Sightings")]                    
    public class Sighting
    {
        [Key]
        public int Id { get; set; }

        public int BirdId { get; set; }
        public Bird Bird { get; set; }
        public string ObserverFirstName { get; set; }
        public int PlaceId { get; set; }
        public virtual Place Place { get; set; }

    }
}
