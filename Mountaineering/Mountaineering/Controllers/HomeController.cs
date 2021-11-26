using Microsoft.AspNetCore.Mvc;
using Mountaineering.Models.Entities;
using Mountaineering.Models.ViewModels;
using Mountaineering.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mountaineering.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        public ClimberService ClimberService { get; set; }
        public HomeController(ClimberService service)
        {
            ClimberService = service;
        }
        [HttpGet("")]
        public IActionResult Index()
        {
            var model = new IndexViewModel() { Climbers = ClimberService.FindAllClimbers(), Mountains = ClimberService.FindAllMontains() };
            return View("index", model);
        }
        [HttpGet("mountains/{id}")]
        public IActionResult ShowMountain([FromRoute] long id)
        {
            var model = new IndexViewModel() { Mountain = ClimberService.FindMountainById(id) };
            return View("showmountain", model);
        }
        [HttpPost("climbers")]
        public IActionResult Climbers(string name, string nation, string mountain)
        {
            ClimberService.AddNewClimber(name, nation, mountain);
            return RedirectToAction("Index");
        }
        [HttpPost("climbers/climb")]
        public IActionResult Climbed(string name, int altitude)
        {
            ClimberService.AddAltitude(name, altitude);
            return RedirectToAction("Index");
        }
        [HttpPost("climbers/{id}/rescue")]
        public IActionResult Rescue([FromRoute] long id)
        {
            var climber = ClimberService.FindClimberById(id);
            if (climber.IsInjured == false)
            {
                return StatusCode(400);
            }
            else
            {
                return StatusCode(200);
            }
        }
        [HttpGet("api/climbers")]
        public object ClimberApi([FromQuery] string nationality)
        {
            var climbers = new ApiModel(ClimberService.FindAllClimbers());
            return climbers.Climbers.Select(climber => new
            {
                name = climber.Name,
                nationality = climber.Nation,
                altitude = climber.CurrentAltitude,
                injured = climber.IsInjured,
                mountain = climber.Mountain.Name
            });
        }
    }
}
