using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VäderDataForms.Models
{
    class IndoorTemperature
    {
        [Required]
        public int Id { get; set; }
        public DateTime DateAndTime { get; set; }
        public decimal? Temperature { get; set; }
        public decimal? Humidity { get; set; }
    }
}
