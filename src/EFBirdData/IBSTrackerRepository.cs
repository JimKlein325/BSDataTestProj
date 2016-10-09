using System.Collections.Generic;
using System.Linq;

namespace EFBirdData.Models
{
    public interface IBSTrackerRepository
    {
        IEnumerable<Bird> GetAllBirds();
        Bird GetBirdByCommonName(string name);
        Bird GetBirdByID(int id);

        IEnumerable<ViewModels.RecentSightingViewModel> MostRecentlySightedBirds(int birdsToReturn);
        IOrderedQueryable<Sighting> GetSightings();
    }
}