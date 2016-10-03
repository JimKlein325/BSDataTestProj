using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFBirdData.Models
{
    public class BSTrackerRepository: IBSTrackerRepository
    {
        private EFBirdDbContext _context;

        public BSTrackerRepository(EFBirdDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Bird> GetAllBirds()
        {
            return _context.Birds.ToList();
        }

        public Bird GetBirdByID (int id)
        {
            return _context.Birds.FirstOrDefault(b => b.Id == id);
        }
        public Bird GetBirdByCommonName (string name)
        {
            return _context.Birds.FirstOrDefault(b => b.CommonName == name);
        }
    }
}
