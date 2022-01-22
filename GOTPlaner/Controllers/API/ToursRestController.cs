using GOTPlaner.Models.DTO;
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
        [HttpPost]
        [Route("/api/Tours/Create")]
        public void AddTour(List<TourItemDto> tourItemDtos)
        {
            var result = "";
        }
    }
}
