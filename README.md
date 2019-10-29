# .NET Core


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


--

żądanie (request)
GET /api/customers/create?FirstName=John&LastName=Smith&Password=1234 HTTP/1.1



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
---------
GET - Pobierz
POST - Utwórz
PUT - Podmień
PATCH - Zmień
DELETE - Usuń
HEAD - Sprawdź czy istnieje (bez pobierania danych)

prawidłowe
GET api/customers
GET api/customers/10
GET api/customers/altkom
GET api/customers?city=Katowice&Street=Opolska
DELETE api/customers/10

nieprawidłowe
GET api/customers?Id=10
GET api/customers/delete?Id=10
GET api/customers/GetCustomerByCity?city=Poznan



## KESTREL


## Porównanie ASP.NET MVC i .NET Core

ASP.NET MVC 
Controller 	ApiController
  View(model)	  Ok(model)

.NET Core
Controller    -> BaseController
 View(model)     Ok(model)


## Wstrzykiwanie zależności

DI/IoC 

interface Factory
{
   T Create<T>();
}



| Key 			| Value |		 | Cykl zycia
 ICustomerRepository	| FakeCustomerRepository | S
 CustomerFaker		  CustomerFaker
 AddressFaker 		AddressFaker


- Przykładowe frameworki
Unity, AutoFac, Ninject, LightInject)
 
## Baza danych

- Przykładowe frameworki
ADO.NET | Dapper/PetaPOCO | EF Core/nHibernate




 	  






