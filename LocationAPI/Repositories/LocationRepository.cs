using System;
using LocationAPI.Models;
using LocationAPI.Services;

namespace LocationAPI.Repositories
{
    public class LocationRepository : Repository<Location>, ILocationService
    {
        public LocationRepository(LocationDBEntities dbContext) :base(dbContext)
        {

        }
    }
}