using Microsoft.AspNetCore.Identity;
using RentARide.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentARide.Infrastructure.Data.SeedDb
{
    internal  class SeedData
    {

        public IdentityUser AgentUser { get; set; }

        public IdentityUser GuestUser { get; set; }

        public Agent Agent { get; set; }

        //Categories

        public Category HatchbackCategory { get; set; }

        public Category WagonCategory { get; set; }

        public Category SuvCategory { get; set; }

        public Category SedanCategory { get; set; }

        //Manufacturers

        public Manufacturer AudiManufacturer { get; set; }

        public Manufacturer HondaManufacturer { get; set; }

        public Manufacturer VwManufacturer { get; set; }

        public Manufacturer MercedesManufacturer { get; set; }

        public Manufacturer HyundaiManufacturer { get; set; }

        //Engines

        public  Engine DieselEngine  { get; set; }

        public Engine PetrolEngine { get; set; }

        public Engine HybridEngine { get; set; }

        public Engine ElectricEngine { get; set; }

        //vehicles
        public Vehicle FirstVehicle { get; set; }

        public Vehicle SecondVehicle { get; set; }
        public Vehicle ThirdVehicle { get; set; }
     public SeedData()
        {

            SeedUsers();
            SeedAgent();
            SeedCategories();
            SeedManufacturers();
            SeedEngine();
            SeedVehicles();
        }
        private void SeedUsers()
        {
            var hasher = new PasswordHasher<IdentityUser>();

            AgentUser = new IdentityUser()
            {
                Id = "dea12856-c198-4129-b3f3-b893d8395082",
                UserName = "agent@mail.com",
                NormalizedUserName = "agent@mail.com",
                Email = "agent@mail.com",
                NormalizedEmail = "agent@mail.com"
            };

            AgentUser.PasswordHash =
                 hasher.HashPassword(AgentUser, "agent123");

            GuestUser = new IdentityUser()
            {
                Id = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                UserName = "guest@mail.com",
                NormalizedUserName = "guest@mail.com",
                Email = "guest@mail.com",
                NormalizedEmail = "guest@mail.com"
            };

            GuestUser.PasswordHash =
            hasher.HashPassword(AgentUser, "guest123");
        }

        private void SeedAgent()
        {
            Agent = new Agent()
            {
                Id = 1,
                PhoneNumber = "+359888888888",
                UserId = AgentUser.Id
            };
        }

        private void SeedCategories()
        {
            HatchbackCategory = new Category()
            {
                Id = 1,
                Name = "Hatchback"
            };

            WagonCategory = new Category()
            {
                Id = 2,
                Name = "Wagon"
            };

            SuvCategory = new Category()
            {
                Id = 3,
                Name = "Suv"
            };

            SedanCategory = new Category()
            {
                Id = 4,
                Name = "Sedan"
            };
        }

        private void SeedManufacturers()
        {
            AudiManufacturer = new Manufacturer()
            {

                Id = 1,
                Name = "Audi"
            };

            HondaManufacturer = new Manufacturer()
            {
                Id = 2,
                Name = "Honda"

            };

           VwManufacturer = new Manufacturer()
            {
                Id = 3,
                Name = "VW"

            };

            MercedesManufacturer = new Manufacturer()
            {
                Id = 4,
                Name = "Mercedes"

            };

            HyundaiManufacturer = new Manufacturer()
            {
                Id = 5,
                Name = "Hyundai"

            };

        }

        private void SeedEngine()
        {
            DieselEngine = new Engine()
            {
                Id = 1,
                Type = "Diesel"

            };

            PetrolEngine = new Engine()
            {
                Id = 2,
                Type = "Petrol"

            };

           HybridEngine = new Engine()
            {
                Id = 3,
                Type = "Hybrid"

            };

            ElectricEngine = new Engine()
            {
                Id = 4,
                Type = "Electric"

            };


        }

        private void SeedVehicles()
        {
            FirstVehicle = new Vehicle()
            {
                Id = 1,
                Model = "A3",
                Description = "A small diesel efficient Hatchback produced by Audi. Extremely reliable vehicle that is cheap to mantain",
                Year = 2020,
                HorsePower = 150,
                ImageUrl = "https://uploads.audi-mediacenter.com/system/production/media/90567/images/72391bd2d21a80a761f0df1bd5bff197d5804daa/A201895_blog.jpg?1698421086",
                PricePerDay = 100.00M,
                CategoryId = HatchbackCategory.Id,
                ManufacturerId = AudiManufacturer.Id,
                EngineId = DieselEngine.Id,
                AgentId = Agent.Id,
                RenterId = GuestUser.Id
            };

            SecondVehicle = new Vehicle()
            {
                Id = 2,
                Model = "Accord",
                Description = "A mid size sedan produced by Honda. Extremely reliable vehicle that is cheap to mantain",
                Year = 2018,
                HorsePower = 190,
                ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRz9gv29Fkt4YY3iFnTLgG-lyKErfmnHrmeZg&s",
                PricePerDay = 150.00M,
                CategoryId = SedanCategory.Id,
                ManufacturerId = HondaManufacturer.Id,
                EngineId = PetrolEngine.Id,
                AgentId = Agent.Id,
                RenterId = GuestUser.Id
            };

            ThirdVehicle = new Vehicle()
            {
                Id = 3,
                Model = "E350",
                Description = "A big sedan produced by Mercedes-Benz. Extremely reliable vehicle that costly to maintain",
                Year = 2011,
                HorsePower = 272,
                ImageUrl = "https://www.jonathanmotorcars.com/imagetag/80/main/l/Used-2011-Mercedes-Benz-E-Class-E350-Sedan-4MATIC-1500582553.jpg",
                PricePerDay = 130.00M,
                CategoryId = SedanCategory.Id,
                ManufacturerId = MercedesManufacturer.Id,
                EngineId = HybridEngine.Id,
                AgentId = Agent.Id,
                RenterId = GuestUser.Id
            };
        }

    }
}
