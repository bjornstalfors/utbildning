Skapa/seeda

### Installation

### Prerequsites
dotnet tool install --global dotnet-ef

### Visual Studio

Installera ett en speciell runner (via nuget) för att köra testerna i bägge testprojekten
xunit.runner.visualstudio 

$ cd UtbildningSEAMS
$ dotnet ef database update


$ cd UtbildningSEAMS.Tests
$ dotnet add package xunit.runner.visualstudio --version 3.0.2
