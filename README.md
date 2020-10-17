# CodeTest
 LoveMoney Code Test Example
 Web API & xUnit testing environment featuring JSON data.
 
 New Improvements:
 
 • gitignore
 • structure of the project (https://gist.github.com/davidfowl/ed7564297c61fe9ab814)
 • Sort out current testing environment
 • Fix output error with GetAlbumsPhotos() method
 • Add asnyc implementation
 • Replace JSON static data with the JSON URL data link
 • Increase testing coverage
 • Apply SOLID principles
 • Benchmark implementation (https://github.com/dotnet/BenchmarkDotNet)
 
 -------------------------------------------------------------------------------------------------
 
 Old Improvements:
 
•	Completing the GetAlbumsPhotos method and testing environment requirements.
•	Create a link connection to the JSON URL raw data instead of copying static JSON into the project. Static JSON has better correlation to static database format.
•	Create more class encapsulation for the service and controller methods.
•	Naming property conflict when considering concatenation of the JSON files.
•	Async functionality.
•	Using string output for service methods, not IEnumberable<string>, to save memory.

