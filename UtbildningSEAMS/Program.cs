using UtbildningSEAMS;

// Setup
var context = new UserDatabaseContext();
context.Database.EnsureCreated();               // OBS skapar db i C:\Users\{USER}\AppData\Local


// Execute
var patrik = new BusinessLogic();
var (city, temp) = await patrik.WeatherInMostDenseCity();

Console.WriteLine($"Dom har det bra i {city} där är det {temp} grader");