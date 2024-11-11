using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RentARide.Infrastructure.Data.Constants.DataConstants;

namespace RentARide.Infrastructure.Data.Models
{
    public class Vehicle
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ModelMaxlength)]
        public string Model { get; set; } = string.Empty;

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        public short Year { get; set; }

        [Required]
        //value
        public short HorsePower { get; set; }

        [Required]
        public decimal PricePerDay { get; set; }

        
        public string ImageUrl { get; set; } = string.Empty;

        //Ids
        [Required]
        public int AgentId { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public int EngineId { get; set; }

        [Required]
        public int ManufacturerId { get; set; }

   
        [ForeignKey(nameof(AgentId))]
        public Agent Agent { get; set; } = null!;

       
        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; } = null!;
        
      
        [ForeignKey(nameof(EngineId))]
        public Engine Engine { get; set; } = null!;

     
        [ForeignKey(nameof(ManufacturerId))]
        public Manufacturer Manufacturer { get; set; } = null!;


       
    }
}
