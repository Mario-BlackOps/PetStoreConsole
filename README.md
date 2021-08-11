# Pet Store 
This project is to show you how to call a pet store API and return all the available pet names in a descending order under their category. I am using the new .Net 5.0 framework with Autofac as a NuGet Package that simulate Inversion of Control.

## PetStore.App
This is the console application project and when you run it, you will get a list with all the categories and pet names from a method called ‘GetAvailablePets’ that will write it to the console.

## PetStore.Services
This is the library project with the helper class ‘HttpPetsHandler’ and it is inheriting the interface ‘IHttpPetsHandler’. This project has the HttpClient logic that is used to make an asynchronous call to the API and is used by the PetStore.App project, it also has the Dto models to map the JSON result from the get request of the API. There is a IoC module added to this project to register the type of instance we will use on the console app.

## PetStore.Tests
This is a xUnit test project that contains the unit test of the public method used on the PetStore.App project. This project is also using the Moq NuGet Package, it is used to mock out the interface from the PetStore.Services project and gives it a specific list of objects to use when running through the code and hitting the method that was mocked with a setup and return. 

