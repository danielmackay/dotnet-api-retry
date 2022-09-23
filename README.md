# .NET API Retry

[![Gitmoji](https://img.shields.io/badge/gitmoji-%20😜%20😍-FFDD67.svg?style=flat-square)](https://gitmoji.dev)

[![.NET](https://github.com/danielmackay/dotnet-api-retry/actions/workflows/dotnet.yml/badge.svg)](https://github.com/danielmackay/dotnet-api-retry/actions/workflows/dotnet.yml)

[![Licence](https://img.shields.io/badge/licence-MIT-brightgreen)](https://github.com/danielmackay/dotnet-api-retry/blob/main/licence.md)

> Based off of Nick Chapsas's Youtube [video](https://youtu.be/nJH0PC2Pubs)

## 💡 Overview

Simple Web API that returns Star Wars People from an external API.  `IHttpClientFactory` and `Polly` have been used to implement a transient retry policy.

The policy works as follows:

- Triggered via
  - `HttpRequestException` being thrown
  - HTTP 5XX being returned
  - Http 408 (request timeout) being returned
- Retries
  - Retry 5 times
  - Exponential backoff with jitter between retries

## ⚡ Getting Started

- `dotnet run` or `dotnet watch run`
- Browser will launch and navigate to <https://localhost:7128/swagger/index.html>

## 📖 References

- [Starwars API](https://swapi.dev/)
