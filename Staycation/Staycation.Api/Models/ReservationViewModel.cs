﻿using Staycation.Api.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace Staycation.Api.Models
{
    public class ReservationViewModel
    {
        [MaxLength(100)]
        public string Email { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int PersonCount { get; set; }
        public bool Confirmed { get; set; }
        public int AccommodationId { get; set; }

    }
}