cd C:\Users\921611\source\repos\Clinic Visit Appointment Booking System\ScheduleMicroservice

dotnet test .\ScheduleMicroserviceTest\ScheduleMicroserviceTest.csproj /p:CollectCoverage=true /p:CoverletOutputFormat=opencover


dotnet sonarscanner begin /k:"ScheduleMicroserviceBackend" /d:sonar.host.url="http://localhost:9000" /d:sonar.cs.opencover.reportsPaths=./ScheduleMicroserviceTest/coverage.opencover.xml /d:sonar.login="9232cd29ccf8b6669fdf8f454bcea0cb8bbc4de5"

dotnet build

dotnet sonarscanner end /d:sonar.login="9232cd29ccf8b6669fdf8f454bcea0cb8bbc4de5"