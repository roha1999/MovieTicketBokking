using eCommerceApp.Data.Base;
using eCommerceApp.Models;
using Microsoft.EntityFrameworkCore;

namespace eCommerceApp.Data.Services
{
    public class ActorService :EntityBaseRepository<Actor>, IActorService
    {
        public ActorService(AppdbContext context) : base(context) { }
    }
}