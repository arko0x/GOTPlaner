using GOTPlaner.Models;
using GOTPlaner.Models.DTO;
using GOTPlaner.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace GOTPlaner.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToursRestController : ControllerBase
    {
        private TourService _tourService;
        public ToursRestController(TourService tourService)
        {
            _tourService = tourService;
        }

        [HttpPost]
        [Route("/api/Tours/Create")]
        public HttpResponseMessage AddTour(List<TourItemDto> tourItemDtos)
        {
            bool success = _tourService.BuildTour(tourItemDtos);
            if (success)
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
            }
            else
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError);
            }
        }
    }
}
