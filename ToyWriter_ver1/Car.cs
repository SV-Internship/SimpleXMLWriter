using System;

public class Car
{
    public string Model { get; set; }
    public string Type { get; set; }
    public int Year { get; set; }
    public string FuelType { get; set; }
    public string Color { get; set; }

    public Car(string model, string type, string year, string fuelType, string color)
    {
        this.Model = model;
        this.Type = type;
        this.Year = Convert.ToInt32(year);
        this.FuelType = fuelType;
        this.Color = color;
    }
    public Car() { }
}


