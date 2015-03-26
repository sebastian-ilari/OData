using System.Collections.Generic;
using System.Linq;

namespace MovieLibrary
{
    public class ActorProvider
    {
        private List<Actor> actors = new List<Actor>
        {
            new Actor { Name = "Sean Penn", Rating = 7, Visible = true },
            new Actor { Name = "Al Pacino", Rating = 10, Visible = true },
            new Actor { Name = "Emilio Disi", Rating = 3, Visible = true },
            new Actor { Name = "Pamela Anderson", Rating = 2, Visible = false },
        };

        public IQueryable<Actor> Actors
        {
            get { return actors.AsQueryable(); }
        }
    }
}