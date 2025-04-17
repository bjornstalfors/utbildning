using UtbildningSEAMS;

// Execute
var patrik = new BusinessLogic();
var (city, temp) = await patrik.WeatherInMostDenseCity();

Console.WriteLine($"Dom har det bra i {city} där är det {temp} grader");