# Investment Performance API

## Overview

This repository serves as my submission for the Nuix Investment Performance WebAPI assignment.

## Pre-requisites

- .NET 8.0 or later

This project can be run on Windows, Mac OS, or Linux. The .NET SDK can be used on all platforms, and Visual Studio can be used on Windows. The project was developed using the .NET SDK on Linux.

## How to Run

Clone the repository:

```bash
git clone git@github.com:cooldudemcgeexl/CodingExercise.git
```

Change into the `InvestmentPerformance` folder:

```bash
cd InvestmentPerformance/
```

### Running the Application

Start the application:

```bash
dotnet run --launch-profile https
```

The application will be available at [https://localhost:7258](https://localhost:7258) or [http://localhost:5128](http://localhost:5128).

See [Usage](#usage) for details

### Running Tests

Change directory into the tests folder:

```bash
cd InvestmentPerformanceTests/
```

Run the tests:

```bash
dotnet test
```

## Usage

For convenience, there is a Swagger docs page available at [https://localhost:7258/swagger/index.html](https://localhost:7258/swagger/index.html). This allows one to more easily explore the API, as well as test queries.

### Investment List for a User

To get the list of investments for a user, make a GET request to `https://localhost:7258/api/InvestmentPerformance/{userID}`, where `{userId}` is the integer ID of the user you wish to get investments for.

For example, making a request to [https://localhost:7258/api/investmentperformance/1](https://localhost:7258/api/investmentperformance/1) should return:

```json
[
  {
    "id": 1,
    "name": "Alan Smithee Productions"
  },
  {
    "id": 2,
    "name": "Novatera Dynamics"
  },
  {
    "id": 3,
    "name": "Lumora Ventures Inc."
  },
  {
    "id": 4,
    "name": "Alan Smithee Productions"
  }
]
```

### Investment Details

To get the details of a specific investment for a user, make a POST request to `https://localhost:7258/api/investmentperformance/`. Include the following data in the body of the request:

```json
{
  "id": <investment id, int>,
  "userId": <user id, int>
}
```

For example, making a query with the body:

```json
{
  "id": 1,
  "userId": 1
}
```

will yield the following:

```json
{
  "name": "Alan Smithee Productions",
  "numShares": 45,
  "costBasisPerShare": 102.57,
  "currentValue": 4500,
  "currentPrice": 100,
  "investmentTerm": "Long",
  "totalGainLoss": -115.65
}
```

## Architecture

- ASP.NET Web API (Using .NET 8.0)
  - Chosen to be similar to Nuix's stack
- EntityFramework Core - ORM
  - Using an in-memory database for demonstration purposes.
- Xunit/Moq - Tests

## Assumptions

- Investments are seen as unique transactions. Companies can have multiple investments. In a full system, companies would be their own object with price tracking attached to them.
- Investments must have a purchase date to calculate the term of the investment. I elected to only have this used internally, while just exposing the term value to the end user.

## Notes

This was a good assignment. I hadn't gotten the chance to experiment with cross-platform .NET development until now, so I'm glad to have gotten the opportunity here. This was also my first time using Xunit and Moq specifically. Both tools are quite powerful and I will be looking to use them in the future.

## References

- [Tutorial: Create a web API with ASP.NET Core | Microsoft Learn](https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-9.0&tabs=visual-studio)
- [Getting Started - EF Core | Microsoft Learn](https://learn.microsoft.com/en-us/ef/core/get-started/overview/first-app?tabs=netcore-cli)
- [Test Minimal API apps | Microsoft Learn](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis/test-min-api?view=aspnetcore-9.0)

## Disclaimer

ChatGPT was used to assist in the creation of [seed data](/InvestmentPerformance/Utils/SeedData.cs). Relevant pieces of data are marked if they are the output of an LLM.

No LLM-generated code was used in the logic of this solution.
