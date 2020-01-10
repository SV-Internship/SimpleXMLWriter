internal class Car
{
    private string model { get; set; }
    private string category { get; set; }
    private int year { get; set; }
    private string fuel_type { get; set; }
    private string color { get; set; }

    public Car(string model, string category, int year, string fuel_type, string color)
    {
        this.model = model;
        this.category = category;
        this.year = year;
        this.fuel_type = fuel_type;
        this.color = color;
    }
}


