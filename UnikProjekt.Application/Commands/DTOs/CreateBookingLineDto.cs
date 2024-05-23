﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnikProjekt.Application.Commands.DTOs
{
    public class CreateBookingLineDto
    {
        public Guid BookingItemId { get; set; }
        public DateTime BookingStart { get; set; }
        public DateTime BookingEnd { get; set; }
        public decimal ItemPrice { get; set; }
    }
}
