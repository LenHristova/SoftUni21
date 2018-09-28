﻿namespace CameraBazar.Data.Models.Enums
{
    using System;
    using System.ComponentModel.DataAnnotations;

    [Flags]
    public enum LightMetering
    {
        Spot = 1,
        [Display(Name = "Center-Weighted")]
        CenterWeighted = 2,
        Evaluative = 4
    }
}
