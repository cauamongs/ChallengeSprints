using ChallengeApi.Models;
using ChallengeApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChallengeApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PartnersController : ControllerBase
    {
        private readonly IPartnerService _partnerService;

        public PartnersController(IPartnerService partnerService)
        {
            _partnerService = partnerService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Partner>>> GetAllPartners()
        {
            
            var partnersWithOffers = await _partnerService.GetAllPartnersWithOffersAsync();

            return Ok(partnersWithOffers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Partner>> GetPartnerById(int id)
        {
            var partner = await _partnerService.GetPartnerByIdAsync(id);
            if (partner == null)
            {
                return NotFound();
            }
            return Ok(partner);
        }

        [HttpPost]
        public async Task<ActionResult<Partner>> CreatePartner(Partner partner)
        {
            await _partnerService.AddPartnerAsync(partner);
            return CreatedAtAction(nameof(GetPartnerById), new { id = partner.Id }, partner);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePartner(int id, Partner partner)
        {
            if (id != partner.Id)
            {
                return BadRequest();
            }
            await _partnerService.UpdatePartnerAsync(partner);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePartner(int id)
        {
            await _partnerService.DeletePartnerAsync(id);
            return NoContent();
        }
    }
}