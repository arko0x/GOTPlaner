using GOTPlaner.Data;
using GOTPlaner.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Linq;

namespace GOTPlaner.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class SegmentsRestController : ControllerBase
    {
        private GotContext _context;

        public SegmentsRestController(GotContext context)
        {
            _context = context;
        }
    }
}
