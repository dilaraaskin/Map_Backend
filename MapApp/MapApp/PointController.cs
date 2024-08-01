using System.Collections.Generic;
using System.Linq;
using MapApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace MapApp.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PointController : ControllerBase
	{
		private readonly IPointService _pointService;

		public PointController(IPointService pointService)
		{
			_pointService = pointService;
		}

		
		[HttpGet]
		public ActionResult<List<Point>> GetAll()
		{
			var response = _pointService.GetAllPoints();
			if (!response.Success)
			{
				return BadRequest(response);
			}
			return Ok(response.Data);
		}

		
		[HttpGet("{id}")]
		public ActionResult<Point> GetById(int id)
		{
			var response = _pointService.GetPointById(id);
			if (!response.Success)
			{
				return NotFound(response);
			}
			return Ok(response.Data);
		}

		
		[HttpPost]
		public ActionResult<Point> Add(Point point)
		{
			var response = _pointService.AddPoint(point);
			if (!response.Success)
			{
				return BadRequest(response);
			}
			return CreatedAtAction(nameof(GetById), new { id = response.Data.Id }, response.Data);
		}

		
		[HttpPost("{id}")]
		public IActionResult Update(int id, Point updatedPoint)
		{
			var response = _pointService.UpdatePoint(id, updatedPoint);
			if (!response.Success)
			{
				return NotFound(response);
			}
			return NoContent();
		}

		
		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			var response = _pointService.DeletePoint(id);
			if (!response.Success)
			{
				return NotFound(response);
			}
			return NoContent();
		}
	}
}
