using eCommerceApp.Data.Base;
using eCommerceApp.Data.Services;
using eCommerceApp.Models;

namespace eCommerceApp.Data
{
    public class ProducerService : EntityBaseRepository<Producer>, IProducerService
    {
        public ProducerService(AppdbContext context) : base(context)
        {

        }
    }
}
