using GOTPlaner.Data;
using GOTPlaner.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GOTPlaner.Controllers.API
{
    [ApiController]
    public class MountainRangesRestController : ControllerBase
    {
        private GotContext _context;
        public MountainRangesRestController(GotContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("api/MountainRanges")]
        public async Task<List<MountainRangeDto>> GetMountainRanges()
        {
            var mountainRangesDtos = await _context.MountainRanges.Select(m => new MountainRangeDto
            {
                MountainRangeId = m.MountainRangeId,
                Name = m.Name
            }).ToListAsync();
            return mountainRangesDtos;
        }
    }
}
