# Bank Of wizard

![1_x4O5ae2f8UzCXncyvqprMg](https://i.ibb.co/MZ5GSj7/wizardbank.png)

* ORM = Entityframework
* .Net Version =5
* DB= PostgreSQL
* Authentication = Jwt based 
* Containerize = Docker

* All http requests are standartized for communication on API layer.

* All methods logged  with aspect oriented approach.

For installation,

1. Go to main directory where yml file in. Then open command line . Type  docker-compose up  <br/>
2. Use Authorization/Login endpoint .Username =getir password=123123 <br/>
3. Click top right Authorize button . Then type -> Bearer "Token which you take with Login endpoint" <br/>
4. Now you are ready to use end points.


* In this project i used DDD principles.

<b>App Layer            :</b> Manages use cases with mediator pattern by calling domain methods and repositories. <br/>
<b>Domain Layer         :</b> Core business entities layers and business rules. <br/>
<b>Repository Layer     :</b> Database operations like repositories <br/>
<b>Test Layer           :</b> Unit tests<br/>
<b>Identity Layer       :</b> JWT settings. <br/>


![1_x4O5ae2f8UzCXncyvqprMg](https://i.ibb.co/h8BqQcP/ddd.png)

Authorization Api

-Login : Getting a token with using username and password

Customer Api

- CreateNewCustomer : Creates new customer
- GetAllCustomerAccounts : Gets customer's all accounts
- GetCustomerAccountInfo : Get customer's chosen account details

Account Api

- CreateNewAccount : Creates new account for chosen customer.
- WithDrawMoneyFromAccount :  Decrease money from chosen account
- AddMoneyToAccount : Incrase  money to chosen account
- GetAccountTransactionBetweenPeriod : Getting all transactions between two time period
- GetAllAccountTransactions : Getting all transactions chosen account







