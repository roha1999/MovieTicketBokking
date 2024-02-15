using eCommerceApp.Models;

namespace eCommerceApp.Data.ViewModels
{
    public class NewMovieDropdownsVM
    {
        public List<Producer> Producers { get; set; }
        public List<Cinemas> Cinemas { get; set; }
        public List<Actor> Actors { get; set; }

        public NewMovieDropdownsVM()
        {
            Producers = new List<Producer>();
            Cinemas = new List<Cinemas>();
            Actors = new List<Actor>();
        }
    }
}
