using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFBirdData.Models;
using Microsoft.EntityFrameworkCore;
using BirdWatcher;
using System.Diagnostics;

namespace EFBirdData.Models
{
    public class BirdManager
    {

        public List<string> Colors = new List<string>();//{ "Pink", "Blue", "Green", "Brown", "Black", "White", "Red", "Orange", "Yellow" };

        private EFBirdDbContext _context;

        public BirdManager(IEFBirdDbContext context)
        {
            _context = (EFBirdDbContext)context;
        }
        public async Task EnsureSeedData()
        {

            if (!_context.Birds.Any())
            {
                _context.Birds.RemoveRange(_context.Birds);
                _context.Places.RemoveRange(_context.Places);
                _context.BirdsPlaces.RemoveRange(_context.BirdsPlaces);
                _context.Sightings.RemoveRange(_context.Sightings);
                _context.BirdsTernaryColors.RemoveRange(_context.BirdsTernaryColors);
                _context.TernaryColors.RemoveRange(_context.TernaryColors);

                await _context.SaveChangesAsync();

                var birds = BirdRepository.LoadBirds();
                var moreBirds = BirdRepository.LoadImportedBirds();
                var allBirds = birds.Union(moreBirds);//.Take(2);


                foreach (var bird in allBirds)
                {
                    Debug.WriteLine(bird.CommonName);
                    await BuildModelBirdFromRepo(bird);
                    await _context.SaveChangesAsync();
                }

                //await _context.SaveChangesAsync();
            }
        }
        public async Task BuildModelBirdFromRepo(BirdWatcher.Bird birdIn)
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
            _context.Birds.Add(newBird);
            await _context.SaveChangesAsync();

            foreach (var sighting in birdIn.Sightings)
            {
                var newSighting = new Sighting();
                newSighting.ObserverFirstName = sighting.ObserverFirstName;
                newSighting.ObserverLastName = sighting.ObserverLastName;
                newSighting.SightingDate = sighting.SightingDate;
                newSighting.BirdId = newBird.Id;
                newSighting.Bird = newBird;


                //Test if place exists
                var place = _context.Places.FirstOrDefault(p => p.Country == sighting.Place.Country);
                if (place == null)
                {
                    var newPlace = new Place()
                    {
                        Country = sighting.Place.Country
                        //other properties never set in Repo data, ignore here
                    };
                    _context.Places.Add(newPlace);
                    await _context.SaveChangesAsync();
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
                _context.Sightings.Add(newSighting);
                await _context.SaveChangesAsync();

                _context.Entry(newSighting).State = EntityState.Modified;
                await _context.SaveChangesAsync();

            }

            //Habitats
            foreach (var habitat in birdIn.Habitats)
            {
                var place = _context.Places.FirstOrDefault(p => p.Country == habitat.Country);
                if (place == null)
                {
                    var newPlace = new Place()
                    {
                        Country = habitat.Country
                        //other properties never set in Repo data, ignore here
                    };
                    _context.Places.Add(newPlace);
                    await _context.SaveChangesAsync();
                    var newBP = new BirdsPlaces() { BirdId = newBird.Id, PlaceId = newPlace.Id };
                    _context.BirdsPlaces.Add(newBP);
                    await _context.SaveChangesAsync();

                }
                else
                {
                    var newBP = new BirdsPlaces() { BirdId = newBird.Id, PlaceId = place.Id };
                    _context.BirdsPlaces.Add(newBP);
                    await _context.SaveChangesAsync();

                }
                //var newBirdsPlaces = new BirdsPlaces() { BirdId = newBird.Id, PlaceId = place.Id };
                //context.BirdsPlaces.Add(newBirdsPlaces);
                //context.SaveChanges();
            }
            foreach (var color in birdIn.TertiaryColors)
            {
                if (color != "")
                {
                    var tColor = _context.TernaryColors.FirstOrDefault(c => c.Name == color);
                    //if (colorIndex == -1)
                    //{
                    //    Colors.Add(color);
                    //    colorIndex = Colors.Count();

                    //}
                    if (true)
                    {

                    }
                    if (tColor == null)
                    {
                        tColor = new TernaryColor() { Name = color };
                        _context.TernaryColors.Add(tColor);
                        await _context.SaveChangesAsync();
                    }

                    BirdsTernaryColors birdTColor = new BirdsTernaryColors()
                    {
                        BirdId = newBird.Id,
                        TernaryColorId = tColor.Id
                    };
                        _context.BirdsTernaryColors.Add(birdTColor);
                        await _context.SaveChangesAsync();

                }
            }

            //update bird entity
            _context.Entry(newBird).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            //return newBird;
        }
        public Place FindPlace(string country)
        {
            return new Place();
        }

        public int FindColorIndex(string color)
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
