## Requirement
1. Vs 2022
2. net core 6
3. C# 10
## Project Structure
The Project Code is in the src folder and it's divided into three part
1. Core: Contain the basic method and type like
	 Interfaces,
	 Models,
	 Expression(anonymous function used in entity framework)
	 validate Method 
2.Infrastructure Contain Class That Represent the Application functionality like
		Data Access Class,
		Logger 
3.Web Hold the class that represent the application web interface and it's configurations like
	controllers,
	middleware,
	server configuration
## Application dataflow
1. listeners receiving HTTP request 
2. pipeline Default middleware
2. GlobalErrorHandler :: used to catch all the application exceptions and return them as response
but it won't do anything to the incoming request, it will only catch exception if its emitted 
3. Controllers 
4. Repository Class
5. Entity Framework
6. Database


