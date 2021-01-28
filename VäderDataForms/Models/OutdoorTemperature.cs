using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VäderDataForms.Models
{
    class OutdoorTemperature
    {
        [Required]
        public int Id { get; set; }
        public DateTime DateAndTime { get; set; }
        public decimal? Temperature { get; set; }
        public decimal? Humidity { get; set; }
    }
}
