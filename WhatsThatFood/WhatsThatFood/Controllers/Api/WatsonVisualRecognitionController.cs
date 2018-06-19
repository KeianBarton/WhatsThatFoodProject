using Microsoft.AspNetCore.Mvc;
using WhatsThatFood.Domain.Dtos;
using WhatsThatFood.Services.Services;

namespace WhatsThatFood.Controllers.Api
{
    [Route("api/watson")]
    public class WatsonVisualRecognitionController : Controller
    {
        private readonly IWatsonVisualRecognitionService _watsonVisualRecognitionService;

        public WatsonVisualRecognitionController(IWatsonVisualRecognitionService watsonVisualRecognitionService)
        {
            _watsonVisualRecognitionService = watsonVisualRecognitionService;
        }

        // POST api/values
        [HttpPost]
        [Route("food")]
        public IActionResult DetectFoodFromImage([FromBody] ImageDto imageDto)
        {
            if (imageDto == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(!_watsonVisualRecognitionService.IsUserAuthenticated)
            {
                return Unauthorized();
            }

            _watsonVisualRecognitionService.DetectFoodFromImage(imageDto.Base64String);

            return Ok();
        }
    }
}
