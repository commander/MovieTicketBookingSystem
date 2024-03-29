# Movie Ticket Booking System

To run the APIs in the solution run bellow commands from the command line in the root directory of the folder:

```
dotnet restore "MovieTicketBookingSystem"
```

```
docker-compose up -d --build
```

Then the APIs will be available at following url:

https://localhost:51443/api/v1/Account/register

https://localhost:51443/api/v1/Account/register-admin

https://localhost:51443/api/v1/Account/login

https://localhost:51443/api/v1/Cities/{cityName}/Movies

https://localhost:51443/api/v1/Movies/{movieName}/Cinemas/{cinema}/Shows

# Architecture

![Components](/Architecture/Components.png)

The System has two main components. Accounts service and Core service.

**Core Service:** supports the functionality to serach movies and view avaialability of the shows, Add new movies, Cinemas, shows, Booking Tickets etc.

**Accounts Service:** supports the functionality to for admin and user to register, login, reset password etc.

Each service is hosted under their own docker containers, with separate DBs for them.