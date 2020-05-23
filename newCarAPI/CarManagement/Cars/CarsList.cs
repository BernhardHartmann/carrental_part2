namespace CarManagement.Car
{
	using System.Collections.Generic;

	public class CarsList
	{
		public IEnumerable<Car> Cars { get; set; }
		public CarsFilter Filters { get; set; }
	}
}