using Fitness.DAL.Context;
using Fitness.DAL.Entities;

using Microsoft.EntityFrameworkCore;

using System.Linq;

namespace Fitness.DAL
{
    class UserRepository : DbRepository<User>
    {
        public UserRepository(FitnessDb db) : base(db) { }

        public override IQueryable<User> Items => base.Items.Include(items => items.Days);

    }
}
