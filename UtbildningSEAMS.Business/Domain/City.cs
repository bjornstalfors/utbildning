namespace UtbildningSEAMS.Business.Domain;

public class City
{
    public int CityId { get; set; }
    
    public string Name { get; set; }

    public int Population { get; set; }
    
    public int Area { get; set; }
    
    public double Latitude { get; set; }
    
    public double Longitude { get; set; }
}