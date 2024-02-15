using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceApp.Models
{
    public class Actor_Movie
    {
        public int MovieId { get; set; }
        public Movies Movie { get; set; }

        public int ActorId { get; set; }
        public Actor Actor { get; set; }
    }
}
