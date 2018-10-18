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

        public LocationsController(ILocationService locationRepository)
        {
            _LocationsRepository = locationRepository;
        }

        private ILocationService _LocationsRepository;

        public IEnumerable<Location> Get()
        {
            
            List<Location> locations = new List<Location>();
            
            var results = _LocationsRepository.Get().OrderBy(l=> l.Name).ToList();

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
            
            var entity = _LocationsRepository.GetByID(id);

            if(entity == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Location with id = " + id.ToString() + " not found.");
                   
            }
            else
            {
                Location location = new Location()
                {
                    ID = entity.ID,
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

                _LocationsRepository.Insert(location);

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
                
                var entity = _LocationsRepository.GetByID(id);

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

                    _LocationsRepository.Update(entity);

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
