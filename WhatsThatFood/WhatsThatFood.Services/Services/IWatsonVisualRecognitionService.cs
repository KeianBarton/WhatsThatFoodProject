using WhatsThatFood.Domain.Dtos;

namespace WhatsThatFood.Services.Services
{
    public interface IWatsonVisualRecognitionService
    {
        VisualRecognitionDto DetectFoodFromImage();
    }
}