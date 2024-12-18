using RentARide.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentARide.Core.Models.Vehicle
{
    public class RentViewModel
    {

        public int Id { get; set; }


        public string Model { get; set; } = string.Empty;

  
        public string Description { get; set; }

        public short Year { get; set; }

        public short HorsePower { get; set; }

       
        public decimal PricePerDay { get; set; }


        public string ImageUrl { get; set; } = string.Empty;


        public string RenterId { get; set; } = String.Empty;

     

        public string Category { get; set; } = null!;


      
        public string Engine { get; set; } = null!;


      
        public string Manufacturer { get; set; } = null!;


    }
}
