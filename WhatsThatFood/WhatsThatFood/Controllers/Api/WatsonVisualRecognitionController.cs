using Microsoft.AspNetCore.Mvc;
using WhatsThatFood.Domain.Dtos;

namespace WhatsThatFood.Controllers.Api
{
    [Route("api/watson")]
    public class WatsonVisualRecognitionController : Controller
    {
        // POST api/values
        [HttpPost]
        [Route("food")]
        public void DetectFoodFromImage([FromBody] ClientImageDto clientImage)
        {
        }
    }
}
