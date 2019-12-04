using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DESPortal.Core.Models;
using DESPortal.Core.Services;
using DESPortal.Plants.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DESPortal.Plants.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantsController : ControllerBase
    {
        private readonly IPlantService _plantService;

        public PlantsController(IPlantService plantService)
        {
            _plantService = plantService;
        }

        /// <summary>
        /// Returns Plants
        /// </summary>
        /// <returns>All Plants </returns>
        /// <response code="200">Returns all Plants</response>
        ///// <response code="403">If userId is not valid </response>
        [HttpGet]
        public ActionResult<List<PlantViewModel>> Get()
        {
            return new PlantViewModel().Tranform(_plantService.GetAll());
        }
        
        /// <summary>
        /// Returns Plants by keyword search
        /// </summary>
        /// <returns>Result of search as list of Plants </returns>
        /// <response code="200">Returns result list of Plants </response>
        ///// <response code="403">If userId is not valid </response>
        [HttpGet("Search")]
        public ActionResult<List<PlantViewModel>> Search(string keyword = "", int skip = 0, int top = 10)
        {
            if(keyword == null)
            {
                keyword = "";
            }
            return new PlantViewModel().Tranform(_plantService.Search(keyword, skip, top));
        }

        /// <summary>
        /// Returns Plant Ids by keyword search
        /// </summary>
        /// <returns>Result of search as list of Plant Ids </returns>
        /// <response code="200">Returns result list of Plant Ids </response>
        ///// <response code="403">If userId is not valid </response>
        [HttpGet("Search/GetIds")]
        public ActionResult<List<int>> SearchIds([FromQuery]int[] ids, string keyword = "")
        {
            if (keyword == null)
            {
                keyword = "";
            }
            return _plantService.SearchInList(keyword, ids.ToList());
        }

        /// <summary>
        /// Returns Plants by list of ids
        /// </summary>
        /// <returns>Result of filter as list of Plants </returns>
        /// <response code="200">Returns result list of Plants </response>
        ///// <response code="403">If userId is not valid </response>
        [HttpGet("Filter")]
        public ActionResult<List<PlantViewModel>> Filter([FromQuery]int[] ids)
        {
            return new PlantViewModel().Tranform(_plantService.Filter(ids.ToList()));
        }

        // GET: api/Plant/5
        [HttpGet("{id}", Name = "Get")]
        public PlantViewModel Get(int id)
        {
            return new PlantViewModel(_plantService.GetById(id));
        }

    }
}
