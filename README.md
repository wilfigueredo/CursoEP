# CursoEP — ASP.NET Core Enterprise Applications

A study repository developed while completing the **ASP.NET Core Enterprise Applications** course by Eduardo Pires, focused on enterprise application architecture and the .NET ecosystem.

## About the project

This repository contains the practical application developed throughout the course. Its purpose was to study and implement patterns and technologies commonly used in larger ASP.NET Core applications rather than serving as an original production product.

> **Study project:** the implementation follows course material and is preserved as part of my technical learning history. It documents the enterprise architecture concepts and technologies I studied and practiced at the time.

## Topics and technologies practiced

The project combines backend, frontend and infrastructure concerns, including:

- ASP.NET Core
- C#
- Angular 5
- REST APIs
- Dependency Injection
- MediatR
- Docker
- Docker Compose
- Nginx
- Client/server architecture
- HTTP communication and error handling

The historical project notes also document the adoption of Angular's `HttpClient`, specialized error handling and MediatR 4.0 during the course evolution.

## Repository structure

```text
├── client/                 # Angular frontend
├── server/                 # ASP.NET Core backend
├── nginx/                  # Reverse-proxy configuration
├── docker-compose.dev.yml  # Development containers
└── docker-compose.prod.yml # Production-oriented containers
```

## Docker

The project includes Docker Compose configurations for development and production scenarios.

The original production command documented by the course project was:

```bash
docker-compose -f docker-compose.prod.yml up --build --scale serverApi=4
```

After the images are built, the environment can be started without rebuilding:

```bash
docker-compose -f docker-compose.prod.yml up --scale serverApi=4
```

For the frontend dependencies, run `npm install` inside the client directory as required by the original project setup.

## Historical context

The source material dates from the .NET Core/Angular ecosystem of 2017–2018. The repository intentionally preserves that implementation rather than modernizing it, because its value today is primarily as a record of the enterprise application concepts and infrastructure practices studied during the course.

Current .NET, Node.js, Angular and Docker environments may therefore require compatibility adjustments before the application can run unchanged.

## Attribution

This repository was created while following the **ASP.NET Core Enterprise Applications** course by **Eduardo Pires**. The architecture and educational material originate from the course; this repository represents my implementation and study work performed while completing it.

---

**William Figueiredo**  
Software Engineering → AI Engineering
