cd C:\Users\921611\source\repos\Clinic Visit Appointment Booking System\UserMicroservice

dotnet test .\UserMicroServiceTest\UserMicroServiceTest.csproj /p:CollectCoverage=true /p:CoverletOutputFormat=opencover


dotnet sonarscanner begin /k:"UserMicroserviceBackend" /d:sonar.host.url="http://localhost:9000" /d:sonar.cs.opencover.reportsPaths=./UserMicroServiceTest/coverage.opencover.xml /d:sonar.login="541d6f1cc69c126fa5dc5fca106436424d1c6b9b"

dotnet build

dotnet sonarscanner end /d:sonar.login="541d6f1cc69c126fa5dc5fca106436424d1c6b9b"