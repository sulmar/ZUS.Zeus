using FluentValidation.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZUS.Zeus.Models.Validators;

namespace ZUS.Zeus.Models
{
    [Validator(typeof(BikeValidator))]
    public class Bike : Base
    {

        public int BikeId { get; set; }

      //  [Required]
        public string Color { get; set; }

        public BikeType  BikeType { get; set; }

      //  [MaxLength(5)]
        public string Number { get; set; }

        public bool IsActive { get; set; }

        public Station CurrentStation { get; set; }

    }
}
