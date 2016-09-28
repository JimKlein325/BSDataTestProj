using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFBirdData.Models;
using Microsoft.EntityFrameworkCore;

namespace EFBirdData.Models
{
    public static class BirdManager
    {

        public static string[] Colors = new string[] { "Pink", "Blue", "Green", "Brown", "Black", "White", "Red", "Orange", "Yellow" };
        public static Bird BuildModelBirdFromRepo(BirdWatcher.Bird birdIn, EFBirdDbContext context)
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
            //add to context
            context.Birds.Add(newBird);
            context.SaveChanges();

            foreach (var sighting in birdIn.Sightings)
            {
                var newSighting = new Sighting();
                newSighting.ObserverFirstName = sighting.ObserverFirstName;
                newSighting.ObserverLastName = sighting.ObserverLastName;
                newSighting.SightingDate = sighting.SightingDate;
                newSighting.BirdId = newBird.Id;
                newSighting.Bird = newBird;


                //Test if place exists
                var place = context.Places.FirstOrDefault(p => p.Country == sighting.Place.Country);
                if (place == null)
                {
                    var newPlace = new Place()
                    {
                        Country = sighting.Place.Country
                        //other properties never set in Repo data, ignore here
                    };
                    context.Places.Add(newPlace);
                    context.SaveChanges();
                    newSighting.PlaceId = newPlace.Id;
                    newSighting.Place = newPlace;

                }
                else
                {
                    //update sighting
                    newSighting.PlaceId = place.Id;
                    newSighting.Place = place;
                }
                //add to context
                context.Sightings.Add(newSighting);
                context.SaveChanges();

                context.Entry(newSighting).State = EntityState.Modified;
                context.SaveChanges();

            }

            //Habitats
            foreach (var habitat in birdIn.Habitats)
            {
                var place = context.Places.FirstOrDefault(p => p.Country == habitat.Country);
                if (place == null)
                {
                    var newPlace = new Place()
                    {
                        Country = habitat.Country
                        //other properties never set in Repo data, ignore here
                    };
                    context.Places.Add(newPlace);
                    context.SaveChanges();
                    var newBP = new BirdsPlaces() { BirdId = newBird.Id, PlaceId = newPlace.Id };
                    context.BirdsPlaces.Add(newBP);
                    context.SaveChanges();

                }
                else
                {
                    var newBP = new BirdsPlaces() { BirdId = newBird.Id, PlaceId = place.Id };
                    context.BirdsPlaces.Add(newBP);
                    context.SaveChanges();

                }
                //var newBirdsPlaces = new BirdsPlaces() { BirdId = newBird.Id, PlaceId = place.Id };
                //context.BirdsPlaces.Add(newBirdsPlaces);
                //context.SaveChanges();
            }
            foreach (var color in birdIn.TertiaryColors)
            {
                var colorIndex = BirdManager.FindColorIndex(color);
                BirdsTernaryColors tColor = new BirdsTernaryColors()
                {
                    BirdId = newBird.Id,
                    TernaryColorId = colorIndex
                };
                if (colorIndex != -1)
                {
                    context.Add(tColor);
                    context.SaveChanges();

                }
            }
            
        //update bird entity
        context.Entry(newBird).State = EntityState.Modified;
            context.SaveChanges();

            return newBird;
      }
        public static Place FindPlace(string country)
        {
            return new Place();
        }

        public static int FindColorIndex (string color)
        {
            int colorIndex = -1;
            for (int i = 0; i < Colors.Count(); i++)
            {
                if (Colors[i] == color) return i;
            }
            return colorIndex;
        }
    }
   
}
