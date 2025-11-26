using Microsoft.AspNetCore.Mvc;

namespace Api_FNAF.Controllers
{
    public class FNAFController : ControllerBase
    {
        private readonly Api_FNAF.Services.FNFAFServices _fnafServices;

        public FNAFController(Api_FNAF.Services.FNFAFServices fnafServices)
        {
            _fnafServices = fnafServices;
        }


        [HttpPost]
        public async Task<ActionResult<bool>> AddAnimatronicAsync([FromBody] Api_FNAF.DBOjects.Animatronic animatronic)
        {
            var result = await _fnafServices.AddAnimatronicAsync(animatronic);
            if (!result) return NotFound(false);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteAnimatronicAsync(int id)
        {
            var result = await _fnafServices.DeleteAnimatronicAsync(id);
            if (!result) return BadRequest(false);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<bool>> UpdateAnimatronicAsync([FromBody] Api_FNAF.DBOjects.Animatronic animatronic)
        {
            var result = await _fnafServices.UpdateAnimatronicAsync(animatronic);
            if (!result) return BadRequest(false);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Api_FNAF.DBOjects.Animatronic>>> GetAllAnimatronicsAsync()
        {
            var result = await _fnafServices.GetAllAnimatronicsAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Api_FNAF.DBOjects.Animatronic>> GetAnimatronicByIdAsync(int id)
        {
            var result = await _fnafServices.GetAnimatronicByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }
    }
}
