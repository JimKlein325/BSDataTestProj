using System.Collections.Generic;
using System.Linq;
using EFBirdData.ViewModels;

namespace EFBirdData.Models
{
    public interface IBSTrackerRepository
    {
        IEnumerable<Bird> GetAllBirds();
        Bird GetBirdByCommonName(string name);
        Bird GetBirdByID(int id);

        IEnumerable<Models.ResultItem> MostRecentlySightedBirds(int birdsToReturn);
        IQueryable<Sighting> GetSightings();
        ViewModels.SightingsForYearReportViewModel GetSightingsForYear(int year);


    }
}