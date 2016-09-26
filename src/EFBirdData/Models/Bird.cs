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
        public string Family { get; set; }
        public string ScientificName { get; set; }
        public string PrimaryColor { get; set; }
        public string SecondaryColor { get; set; }
        public double Length { get; set; }
        public double Width { get; set; }
        public double Weight { get; set; }
        public string Size { get; set; }
        public string ConservationStatus { get; set; }
        public string ConservationCode { get; set; }
        public ICollection<BirdsPlaces> Habitats { get; set; }
        public ICollection<Sighting> Sightings { get; set; }
        public ICollection<BirdsTernaryColors> BirdsTernaryColors { get; set;}
    }
}
