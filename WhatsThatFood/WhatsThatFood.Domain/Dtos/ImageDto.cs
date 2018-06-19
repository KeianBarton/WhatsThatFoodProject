using System.ComponentModel.DataAnnotations;

namespace WhatsThatFood.Domain.Dtos
{
    public class ImageDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Base 64 image string is required.")]
        public string Base64String { get; set; }
    }
}
