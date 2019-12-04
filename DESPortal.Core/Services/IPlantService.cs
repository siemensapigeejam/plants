using DESPortal.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DESPortal.Core.Services
{
    public interface IPlantService
    {

        List<Plant> GetAll();
        List<Plant> Filter(List<int> ids);
        List<Plant> Search(string keyword, int skip = 0, int top = 10);
        List<int> SearchInList(string keyword, List<int> ids);
        Plant GetById(int id);
        void Delete(int id);

    }
}
