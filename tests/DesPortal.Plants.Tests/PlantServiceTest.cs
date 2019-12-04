using DESPortal.Core.Models;
using DESPortal.Core.Services;
using DESPortal.Infrastructure.DataAccess.DESPortal;
using DESPortal.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DesPortal.Plants.Tests
{
    public class PlantServiceTest
    {

        public PlantServiceTest()
        {

        }

        private Plant CreatePlant(string plantName)
        {
            return new Plant()
            {
                Name = plantName,
            };
        }
        

        [Fact]
        public void GetAll_EmptyDatabase_ReturnsEmptyList()
        {
            var options = new DbContextOptionsBuilder<DESPortalDBContext>()
               .UseInMemoryDatabase(databaseName: "GetAll_EmptyDatabase_ReturnsEmptyList")
               .Options;

            // Insert seed data into the database using one instance of the context
            using (var context = new DESPortalDBContext(options))
            {
                IPlantService plantService = new PlantService(context);
                Assert.Empty(plantService.GetAll());
            }
        }

        [Fact]
        public void GetAll_MultiplePlants_ReturnsAllEntries()
        {
            const string PlantName1 = "PlantName1";
            const string PlantName2 = "PlantName2";
            const int TotalPlantCount = 2;

            var options = new DbContextOptionsBuilder<DESPortalDBContext>()
               .UseInMemoryDatabase(databaseName: "GetAll_MultiplePlants_ReturnsAllEntries")
               .Options;

            var item1 = CreatePlant(PlantName1);
            var item2 = CreatePlant(PlantName2);
            // Insert seed data into the database using one instance of the context
            using (var context = new DESPortalDBContext(options))
            {
                context.Plants.Add(item1);
                context.Plants.Add(item2);
                context.SaveChanges();
            }

            using (var context = new DESPortalDBContext(options))
            {
                IPlantService plantService = new PlantService(context);

                List<Plant> plants = plantService.GetAll();

                Assert.True(plants.Any(x => x.Name == item1.Name));
                Assert.True(plants.Any(x => x.Name == item2.Name));
                Assert.Equal(TotalPlantCount, plants.Count);
            }

        }

        [Fact]
        public void Search_MultiplePlants_ReturnsResult()
        {
            const string PlantName1 = "PlantName1";
            const string PlantName2 = "PlantName2";

            var options = new DbContextOptionsBuilder<DESPortalDBContext>()
               .UseInMemoryDatabase(databaseName: "Search_MultiplePlants_ReturnsResult")
               .Options;

            // Insert seed data into the database using one instance of the context
            using (var context = new DESPortalDBContext(options))
            {
                IPlantService plantService = new PlantService(context);
                var plant1 = CreatePlant(PlantName1);
                var plant2 = CreatePlant(PlantName2);

                context.Plants.Add(plant1);
                context.Plants.Add(plant2);
                context.SaveChanges();

                List<Plant> plants = plantService.Search("PlantName");

                Assert.Contains(plant1, plants);
                Assert.Contains(plant2, plants);
            }

        }

        [Fact]
        public void Search_MultiplePlants_ReturnsEmpty()
        {
            const string PlantName1 = "PlantName1";
            const string PlantName2 = "PlantName2";

            var options = new DbContextOptionsBuilder<DESPortalDBContext>()
               .UseInMemoryDatabase(databaseName: "Search_MultiplePlants_ReturnsEmpty")
               .Options;

            // Insert seed data into the database using one instance of the context
            using (var context = new DESPortalDBContext(options))
            {
                IPlantService plantService = new PlantService(context);
                var plant1 = CreatePlant(PlantName1);
                var plant2 = CreatePlant(PlantName2);

                context.Plants.Add(plant1);
                context.Plants.Add(plant2);
                context.SaveChanges();
                
                List<Plant> plants = plantService.Search("PlantNotExistingName");

                Assert.Empty(plants);
            }

        }

        [Fact]
        public void Delete_PlantExists_PlantDeleted()
        {
            const string PlantName = "PlantName";

            var options = new DbContextOptionsBuilder<DESPortalDBContext>()
               .UseInMemoryDatabase(databaseName: "Delete_PlantExists_PlantToUserDeleted")
               .Options;

            // Insert seed data into the database using one instance of the context
            using (var context = new DESPortalDBContext(options))
            {
                IPlantService plantService = new PlantService(context);
                var plant = CreatePlant(PlantName);

                context.Plants.Add(plant);
                context.SaveChanges();
                
                plantService.Delete(plant.Id);

                plant = context.Plants.Find(plant.Id);
                Assert.Null(plant);
            }
        }

        [Fact]
        public void GetById_PlantExists_ReturnsPlant()
        {
            const string PlantName = "PlantName";

            var options = new DbContextOptionsBuilder<DESPortalDBContext>()
               .UseInMemoryDatabase(databaseName: "GetById_PlantExists_ReturnsPlant")
               .Options;

            // Insert seed data into the database using one instance of the context
            using (var context = new DESPortalDBContext(options))
            {
                IPlantService plantService = new PlantService(context);
                var plant = CreatePlant(PlantName);

                context.Plants.Add(plant);
                context.SaveChanges();
                
                var result = plantService.GetById(plant.Id);

                Assert.Equal(PlantName, result.Name);
            }
        }


    }
}
