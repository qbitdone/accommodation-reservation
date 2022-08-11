﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Staycation.Api.Models;
using Staycation.Api.Services;

namespace Staycation.Api.Controllers
{
    [Route("api/reservation")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        public ReservationService _reservationService;

        public ReservationController(ReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpPost]
        public IActionResult AddReservation([FromBody] ReservationViewModel reservation)
        {
            _reservationService.AddReservation(reservation);
            return Ok(reservation);
        }

        [HttpGet]
        public IActionResult GetAllReservations()
        {
            var _allReservations = _reservationService.GetAllReservations();
            return Ok(_allReservations);
        }
    }
}
