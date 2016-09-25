using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFBirdData.Models
{
    [Table("Places")]
    public class Place
    {
        [Key]
        public int Id { get; set; }
        public string Country { get; set; }

        public ICollection<Sighting> Sightings { get; set; }

        public ICollection<BirdsPlaces> Habitats { get; set; }

    }
}
