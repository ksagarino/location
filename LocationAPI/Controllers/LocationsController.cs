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

        public IEnumerable<Location> Get()
        {
            
            List<Location> locations = new List<Location>();
            
            var results = LocationsRepository.Get().OrderBy(l=> l.Name).ToList();

            foreach(var result in results)
            {
                Location location = new Location()
                {
                    ID = result.ID,
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
            

            
            var entity = LocationsRepository.GetByID(id);

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

        public HttpResponseMessage Post([FromBody] Location location)
        {
            try
            {
                
                LocationsRepository.Insert(location);

                var message = Request.CreateResponse(HttpStatusCode.Created, location);
                message.Headers.Location = new Uri(Request.RequestUri + location.ID.ToString());

                return message;

                
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
                
                var entity = LocationsRepository.GetByID(id);

                if(entity == null)
                {
                   
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Location with id = " + id.ToString() + " not found.");
                }
                else
                {
                    entity.Name = location.Name;
                    entity.Address = location.Address;
                    entity.City = location.Address;
                    entity.Province = location.Address;
                    entity.IsDeleted = location.IsDeleted;

                    LocationsRepository.Update(entity);

                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
              
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

    }
}
