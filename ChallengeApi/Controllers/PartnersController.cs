using ChallengeApi.Services;
using ChallengeApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class PartnerController : ControllerBase
{
    private readonly IPartnerService _partnerService;

    public PartnerController(IPartnerService partnerService)
    {
        _partnerService = partnerService;
    }

    // GET: api/partner
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Partner>>> GetPartners()
    {
        return Ok(await _partnerService.GetAllPartnersAsync());
    }

    // GET: api/partner/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Partner>> GetPartner(int id)
    {
        var partner = await _partnerService.GetPartnerByIdAsync(id);

        if (partner == null)
        {
            return NotFound();
        }

        return Ok(partner);
    }

    // POST: api/partner
    [HttpPost]
    public async Task<ActionResult<Partner>> CreatePartner(Partner partner)
    {
        // Remove validation for unnecessary fields
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await _partnerService.AddPartnerAsync(partner);
        return CreatedAtAction(nameof(GetPartner), new { id = partner.Id }, partner);
    }

    // PUT: api/partner/5
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePartner(int id, Partner partner)
    {
        if (id != partner.Id)
        {
            return BadRequest();
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await _partnerService.UpdatePartnerAsync(partner);
        return NoContent();
    }

    // DELETE: api/partner/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePartner(int id)
    {
        await _partnerService.DeletePartnerAsync(id);
        return NoContent();
    }
}
