﻿namespace CameraBazar.Services.Models.Camera
{
    using Data.Models.Enums;

    public class CameraListingModel
    {
        public int Id { get; set; }

        public CameraMake Make { get; set; }

        public string Model { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public string ImageUrl { get; set; }
    }
}
