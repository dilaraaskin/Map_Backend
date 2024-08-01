namespace MapApp.Services
{
	public interface IPointService
	{
		Response<List<Point>> GetAllPoints();
		Response<Point> GetPointById(int id);
		Response<Point> AddPoint(Point point);
		Response<bool> UpdatePoint(int id, Point updatedPoint);
		Response<bool> DeletePoint(int id);
	}

}
