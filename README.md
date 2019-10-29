# .NET Core

## Przydatne komendy CLI
- ``` dotnet --list-sdks ``` - wyświetlenie listy zainstalowanych SDK
- ``` dotnet new globaljson ``` - utworzenie pliku global.json
- ``` dotnet new globaljson --sdk-version {version} ``` - utworzenie pliku global.json i ustawienie wersji SDK
- ``` dotnet new --list ``` - wyświetlenie listy dostępnych szablonów
- ``` dotnet new {template} ``` - utworzenie nowego projektu na podstawie wybranego szablonu
- ``` dotnet new {template} -o {output} ``` - utworzenie nowego projektu w podanym katalogu
- ``` dotnet restore ``` - pobranie bibliotek nuget na podstawie pliku projektu
- ``` dotnet build ``` - kompilacja projektu
- ``` dotnet run ``` - uruchomienie projektu
- ``` dotnet run {app.dll}``` - uruchomienie aplikacji
- ``` dotnet test ``` - uruchomienie testów jednostkowych
- ``` dotnet run watch``` - uruchomienie projektu w trybie śledzenia zmian
- ``` dotnet test ``` - uruchomienie testów jednostkowych w trybie śledzenia zmian
- ``` dotnet add {project.csproj} reference {library.csproj} ``` - dodanie odwołania do biblioteki
- ``` dotnet remove {project.csproj} reference {library.csproj} ``` - usunięcie odwołania do biblioteki
- ``` dotnet new sln ``` - utworzenie nowego rozwiązania
- ``` dotnet sln {solution.sln} add {project.csproj}``` - dodanie projektu do rozwiązania
- ``` dotnet sln {solution.sln} remove {project.csproj}``` - usunięcie projektu z rozwiązania
- ``` dotnet publish -c Release -r {platform}``` - publikacja aplikacji
- ``` dotnet publish -c Release -r win10-x64``` - publikacja aplikacji dla Windows
- ``` dotnet publish -c Release -r linux-x64``` - publikacja aplikacji dla Linux
- ``` dotnet publish -c Release -r osx-x64``` - publikacja aplikacji dla MacOS
- ``` dotnet add package {package-name} ``` - dodanie pakietu nuget do projektu
- ``` dotnet remove package {package-name} ``` - usunięcie pakietu nuget do projektu

## Struktura projektu
~~~
+ Solution
   |
   + - ConsoleClient
   |
   + - Models
   |
   + - Infrastructure
   |
   + - Api
~~~   

## .NET Standard

~~~
.NET Framework | .NET Core | 
-------------------------------
.NET Standard
-------------------------------
~~~

## Protokół HTTP

żądanie (request)
~~~
GET /docs/index.html HTTP/1.1
host: www.altkom.pl
{blank line}
~~~

odpowiedź (response)
~~~
HTTP/1.1 200 OK 
Content-Length: 308
Content-Type: text/html

<html>
 <p>Hello World!</p>
</html>
~~~

----


żądanie (request)
~~~
GET /api/customers HTTP/1.1
host: www.altkom.pl
Accept: application/json
{blank line}
~~~

odpowiedź (response)
~~~
HTTP/1.1 200 OK 
Content-Length: 308
Content-Type: application/xml

<xml>
 <Customer>
   <FirstName>John</FirstName>
 </Customer>
</xml>
~~~



## SOAP 
żądanie (request)

~~~
POST /myservice.asmx HTTP/1.1
host: www.altkom.pl
Content-Type: application/xml

<xml>
 <GetCustomer>
   <FirstName>John</FirstName>
 </GetCustomer>
</xml>
~~~

## REST API

| Akcja  | Opis                  |
|--------|-----------------------|
| GET    | Pobierz               |
| POST   | Utwórz                |
| PUT    | Podmień               |
| DELETE | Usuń                  |
| PATCH  | Zmień częściowo       |
| HEAD   | Czy zasób istnieje    |


prawidłowe
~~~
GET api/customers
GET api/customers/10
GET api/customers/altkom
GET api/customers?city=Katowice&Street=Opolska
DELETE api/customers/10
~~~

nieprawidłowe
~~~
GET api/customers?Id=10
GET api/customers/delete?Id=10
GET api/customers/GetCustomerByCity?city=Poznan
~~~

## Porównanie ASP.NET MVC i .NET Core

ASP.NET MVC 
~~~
  Controller 	  ApiController
  View(model)	  Ok(model)
~~~

.NET Core
~~~
 Controller   -> BaseController
 View(model)     Ok(model)
~~~

## Wstrzykiwanie zależności

DI/IoC 

~~~ csharp
interface Factory
{
   T Create<T>();
}
~~~


~~~
| Key 			         | Value                  | Cykl zycia
| ICustomerRepository	| FakeCustomerRepository | Singleton
| CustomerFaker		   | CustomerFaker          |
| AddressFaker 		   | AddressFaker           |
~~~

- Przykładowe frameworki
Unity, AutoFac, Ninject, LightInject
 
## Baza danych

- Przykładowe frameworki
~~~
ADO.NET | Dapper/PetaPOCO | EF Core/nHibernate
~~~

## Konfiguracja

- Utworzenie klasy opcji
~~~ csharp
public class CustomerOptions
{
    public int Quantity { get; set; }
}
~~~


- Plik konfiguracyjny appsettings.json

~~~ json
{
  "CustomersModule": {
    "Quantity": 40
  },
  
  ~~~

- Instalacja biblioteki

~~~ bash
 dotnet add package Microsoft.Extensions.Options
~~~

- Użycie opcji

~~~ csharp

public class FakeCustomersService
{
   private readonly CustomerOptions options;

    public FakeCustomersService(IOptions<CustomerOptions> options)
    {
        this.options = options.Value;
    }
}
       
~~~

- Konfiguracja opcji

~~~ csharp
public class Startup
    {
        public IConfiguration Configuration { get; }
    
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false)
                .AddXmlFile("appsettings.xml", optional: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            Configuration = builder.Build();

        }
        
      public void ConfigureServices(IServiceCollection services)
      {
          services.Configure<CustomerOptions>(Configuration.GetSection("CustomersModule"));
      }
    }
~~~

- Konfiguracja bez interfejsu IOptions<T>
  
~~~ csharp
  public void ConfigureServices(IServiceCollection services)
        {
            var customerOptions = new CustomerOptions();
            Configuration.GetSection("CustomersModule").Bind(customerOptions);
            services.AddSingleton(customerOptions);

            services.Configure<CustomerOptions>(Configuration.GetSection("CustomersModule"));
        }

~~~
 






