using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFBirdData.Models;

namespace EFBirdData.Models
{
    public static class BirdManager
    {
        public static string[] Colors;
        public static Bird BuildModelBirdFromRepo(BirdWatcher.Bird birdIn)
        {
            var newBird = new EFBirdData.Models.Bird()
            {
                CommonName = birdIn.CommonName,
                Family = birdIn.Family,
                ScientificName = birdIn.ScientificName,
                PrimaryColor = birdIn.PrimaryColor,
                SecondaryColor = birdIn.SecondaryColor,
                Length = birdIn.Length,
                Width = birdIn.Width,
                Weight = birdIn.Weight,
                Size = birdIn.Size,
                ConservationStatus = birdIn.ConservationStatus,
                ConservationCode = birdIn.ConservationCode
            };
            return newBird;
        }
    }
}
