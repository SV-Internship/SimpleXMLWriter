using System;

internal class Car
{
    private string model { get; set; }
    private string type { get; set; }
    private int year { get; set; }
    private string fuel_type { get; set; }
    private string color { get; set; }

    public Car(string model, string type, string year, string fuel_type, string color)
    {
        this.model = model;
        this.type = type;
        this.year = Convert.ToInt32(year);
        this.fuel_type = fuel_type;
        this.color = color;
    }
}


