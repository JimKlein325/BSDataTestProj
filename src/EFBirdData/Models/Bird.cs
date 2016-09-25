using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EFBirdData.Models
{
    [Table("Birds")]    
    public class Bird
    {
        [Key]
        public int Id { get; set; }
        public string CommonName { get; set; }
        public int PrimaryColorId { get; set; }
        public PrimaryColor PrimaryColor { get; set; }
        public int SecondaryColorId { get; set; }
        public SecondaryColor SecondaryColor { get; set; }
        public ICollection<BirdsPlaces> Habitats { get; set; }
        public ICollection<Sighting> Sightings { get; set; }
        public ICollection<BirdsTernaryColors> BirdsTernaryColors { get; set;}


    }
}
