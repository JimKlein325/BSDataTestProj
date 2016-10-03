using System.Collections.Generic;

namespace EFBirdData.Models
{
    public interface IBSTrackerRepository
    {
        IEnumerable<Bird> GetAllBirds();
        Bird GetBirdByCommonName(string name);
        Bird GetBirdByID(int id);
    }
}