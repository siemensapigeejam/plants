using DESPortal.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DESPortal.Plants.Models.ViewModels
{
    public class PlantViewModel
    {
        public PlantViewModel()
        {

        }

        public PlantViewModel(Plant plant)
        {
            Id = plant.Id;
            Name = plant.Name;
            Latitude = plant.Latitude;
            Longitude = plant.Longitude;
        }

        public List<PlantViewModel> Tranform(List<Plant> plants)
        {
            List<PlantViewModel> result = new List<PlantViewModel>();
            foreach (var plant in plants)
            {
                result.Add(new PlantViewModel(plant));
            }
            return result;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }
        
    }
}
