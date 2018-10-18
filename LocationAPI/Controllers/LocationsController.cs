using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LocationAPI.Models;
using LocationAPI.Services;
using LocationAPI.Repositories;

namespace LocationAPI.Controllers
{
    public class LocationsController : ApiController
    {
        private ILocationService LocationsRepository = new LocationRepository(new LocationDBEntities());

        public LocationsController(ILocationService locationRepository)
        {
            _LocationRepository = locationRepository;
        }

        ILocationService _LocationRepository;

        public IEnumerable<Location> Get()
        {
            
            List<Location> locations = new List<Location>();
           
            var results = LocationsRepository.Get().OrderBy(l=> l.Name).ToList();

            foreach(var result in results)
            {
                Location location = new Location()
                {
                    Name = result.Name,
                    Address = result.Address,
                    City = result.City,
                    Province = result.Province
                };

                locations.Add(location);
            }

            return locations;
        }

        public HttpResponseMessage Get(int id)
        {
            
            using (LocationDBEntities entities = new LocationDBEntities())
            {
                var entity = entities.spGetAllLocationsById(id).FirstOrDefault();

                if(entity == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Location with id = " + id.ToString() + " not found.");
                   
                }
                else
                {
                    Location location = new Location()
                    {
                        Name = entity.Name,
                        Address = entity.Address,
                        City = entity.City,
                        Province = entity.Province

                    };

                    return Request.CreateResponse(HttpStatusCode.OK, location);
                }

            }
        }

        public HttpResponseMessage Post([FromBody] Location location)
        {
            try
            {
                using (LocationDBEntities entities = new LocationDBEntities())
                {
                    var result = entities.spInsertLocation(location.Name, location.Address, location.City, location.Province);

                    var message = Request.CreateResponse(HttpStatusCode.Created, location);
                    message.Headers.Location = new Uri(Request.RequestUri + location.ID.ToString());

                    return message;

                }
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
           
        }

        public HttpResponseMessage Put(int id, [FromBody] Location location)
        {
            try
            {
                using(LocationDBEntities entities = new LocationDBEntities())
                {
                    var entity = entities.spGetAllLocationsById(id).FirstOrDefault();

                    if(entity != null)
                    {
                        entities.spUpdateLocation(id, location.Name, location.Address, location.City, location.Province);

                        return Request.CreateResponse(HttpStatusCode.OK, entity);
                    }
                    else
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Location with id = " + id.ToString() + " not found.");
                    }
                }
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

    }
}
