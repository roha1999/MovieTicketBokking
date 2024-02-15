using eCommerceApp.Data.Base;
using eCommerceApp.Models;

namespace eCommerceApp.Data.Services
{
    public class CinemaService:EntityBaseRepository<Cinemas>, ICinemasService
    {
        public CinemaService(AppdbContext context) : base(context)
        {

        }
    }
}
