using WhatsThatFood.Domain.Dtos;

namespace WhatsThatFood.Services.Services
{
    public interface IWatsonVisualRecognitionService
    {
        bool IsUserAuthenticated { get; }
        VisualRecognitionDto DetectFoodFromImage(string base64ImageString);
    }
}