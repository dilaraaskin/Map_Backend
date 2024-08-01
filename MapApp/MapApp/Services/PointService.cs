using System;
using System.Collections.Generic;
using System.Linq;

namespace MapApp.Services
{
	namespace MapApp.Services
	{
		public class PointService : IPointService
		{
			private readonly List<Point> points = new List<Point>();

			public Response<List<Point>> GetAllPoints()
			{
				try
				{
					return new Response<List<Point>>
					{
						Success = true,
						Data = points
					};
				}
				catch (Exception ex)
				{
					return new Response<List<Point>>
					{
						Success = false,
						Message = ex.Message,
						Data = null
					};
				}
			}

			public Response<Point> GetPointById(int id)
			{
				try
				{
					var point = points.FirstOrDefault(p => p.Id == id);
					if (point == null)
					{
						return new Response<Point>
						{
							Success = false,
							Message = "Point not found",
							Data = null
						};
					}
					return new Response<Point>
					{
						Success = true,
						Data = point
					};
				}
				catch (Exception ex)
				{
					return new Response<Point>
					{
						Success = false,
						Message = ex.Message,
						Data = null
					};
				}
			}

			public Response<Point> AddPoint(Point point)
			{
				try
				{
					var item = new Point
					{
						Id = points.Count + 1,
						X = point.X,
						Y = point.Y,
						Name = point.Name
					};

					points.Add(item);
					return new Response<Point>
					{
						Success = true,
						Data = item
					};
				}
				catch (Exception ex)
				{
					return new Response<Point>
					{
						Success = false,
						Message = ex.Message,
						Data = null
					};
				}
			}

			public Response<bool> UpdatePoint(int id, Point updatedPoint)
			{
				try
				{
					var pointToUpdate = points.FirstOrDefault(p => p.Id == id);
					if (pointToUpdate == null)
					{
						return new Response<bool>
						{
							Success = false,
							Message = "Point not found",
							Data = false
						};
					}

					pointToUpdate.X = updatedPoint.X;
					pointToUpdate.Y = updatedPoint.Y;
					pointToUpdate.Name = updatedPoint.Name;

					return new Response<bool>
					{
						Success = true,
						Data = true
					};
				}
				catch (Exception ex)
				{
					return new Response<bool>
					{
						Success = false,
						Message = ex.Message,
						Data = false
					};
				}
			}

			public Response<bool> DeletePoint(int id)
			{
				try
				{
					var pointToRemove = points.FirstOrDefault(p => p.Id == id);
					if (pointToRemove == null)
					{
						return new Response<bool>
						{
							Success = false,
							Message = "Point not found",
							Data = false
						};
					}

					points.Remove(pointToRemove);
					return new Response<bool>
					{
						Success = true,
						Data = true
					};
				}
				catch (Exception ex)
				{
					return new Response<bool>
					{
						Success = false,
						Message = ex.Message,
						Data = false
					};
				}
			}
		}
	}

}
