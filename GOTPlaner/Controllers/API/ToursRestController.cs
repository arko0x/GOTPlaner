using GOTPlaner.Models.DTO;
using GOTPlaner.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
        public void AddTour(List<TourItemDto> tourItemDtos)
        {
            _tourService.BuildTour(tourItemDtos);
        }
    }
}
