[![Build](https://github.com/adrianw0/Fuel/actions/workflows/dotnet.yml/badge.svg)](https://github.com/adrianw0/Fuel/actions/workflows/dotnet.yml)
<!-- TOC start (generated with https://github.com/derlin/bitdowntoc) -->

- [PeakForm - Diet and Meal Planning App](#peakform---diet-and-meal-planning-app)
   * [Features](#features)
- [Installation Instructions](#installation-instructions)
   * [1. Download the Release](#1-download-the-release)
   * [2. Set up the Environment](#2-set-up-the-environment)
   * [3. Stopping the Application ](#3-stopping-the-application)
- [Building the Application from Source](#building-the-application-from-source)
   * [1. Clone the Repository](#1-clone-the-repository)
   * [2. Set up the Environment](#2-set-up-the-environment-1)
   * [3. Build and run the docker images](#3-build-and-run-the-docker-images)
   * [4. Stopping the Application](#4-stopping-the-application)
- [Usage](#usage)
   * [API Documentation](#api-documentation)
   * [Authentication](#authentication)
   * [AI Assistant](#ai-assistant)
   * [technology stack used:](#technology-stack-used)
   * [Roadmap](#roadmap)

<!-- TOC end -->

# PeakForm - Diet and Meal Planning App
PeakForm is a diet and meal planning application designed to help users achieve their fitness and nutrition goals. By integrating advanced AI capabilities and OpenFoodFacts data, PeakForm offers a seamless experience for personalized diet suggestions, meal tracking, and progress monitoring. Whether you're a fitness enthusiast or someone looking to adopt healthier eating habits, PeakForm provides the tools you need to succeed.

## Features

- **Integration with OpenAI:**
  - Generates personalized diet suggestions and plans based on user data.
  - Provides AI-powered assistance for optimizing fitness and health.

- **Integration with OpenFoodFacts:**
  - Fetches product data containing nutrients, macros etc.. by product name or barcode using OpenFoodFacts API.

- **User Parameter Tracking:**
  - Monitor and track metrics like weight, goals, body measurements, and activity levels.

- **Core Features:**
  - Create and manage meals, custom dishes, and products with ease.

# Installation Instructions

## 1. Download the Release

You can quickly get started by downloading the latest release:
- Navigate to the [Releases section](https://github.com/adrianw0/PeakForm/releases) on GitHub.
- Download the `docker-compose.yml` and `.env` files to your machine.

## 2. Set up the Environment
- Copy the ` default.env` file to `.env`:
   ```bash
   cp  default.env .env
   ```
- Edit the .env file to set the appropriate values for your environment
- Run the application using Docker:
  ```bash
  docker compose up
  ```
  This pulls the necessary Docker images (both auth and main API) and starts the application.
  
## 3. Stopping the Application 
  To stop the services run 
  ```bash
  docker compose down
  ```
  
# Building the Application from Source
If you'd like to build the application yourself:
## 1. Clone the Repository
Clone the PeakForm repository:
```bash
git clone https://github.com/adrianw0/peakform.git
cd peakform
```

## 2. Set up the Environment
  - Copy the .env.example file to .env:
  ```bash
    cp .env.example .env
  ```
  - Edit the .env file and set the required environment variables
        
## 3. Build and run the docker images
Build and start the Docker images:
```bash
docker compose up
```

## 4. Stopping the Application
To stop the services, run:
```bash
docker compose down
```
# Usage
## API Documentation
- Available Features:
  - Fetch products from the OpenFoodFacts database.
  - Add, modify, and delete custom user-defined products.
  - Create and manage meals and dishes.
  - Track user metrics such as goals, measurements, and activity levels.
  - AI-powered advice for diet, workouts, fitness ratings, etc.
  
Access API documentation via Swagger at:
```http
  http://localhost:5000/swagger
```
## Authentication
Before accessing specific features, users must register and log in via the auth-api.
- **Register a new user:**
  ```http
  POST http://localhost:5050/Auth/CreateUser
  Content-Type: application/json
  {
    "UserName": "exampleUser",
    "Email": "user@example.com",
    "Password": "StrongPassword123!"
  }
  ```
- **Login an existing user:**
  ```http
  POST http://localhost:5050/Auth/Login
  Content-Type: application/json
  {
    "Email": "user@example.com",
    "Password": "StrongPassword123!"
  }
  ```
Use the returned JWT token for subsequent requests:
```HTTP
Authorization: Bearer <your-token-here>
```
## AI Assistant
The AI assistant uses SignalR for real-time chat capabilities, leveraging user data for personalized advice.
- **Example using postman:**
  - use WebSocket request
  - add `access_token` param with the JWT token
  - Perform a handshake:
     ```json
      {"protocol":"json","version":1}
     ```
  - nowSend prompts:
    ```
      {
          "type": 1,
          "target": "SendMessage",
          "arguments": ["Hello!"]
      }
    ```
 

## technology stack used:
- .NET 9
- Docker
- SignalR for real time communication with OpenAI chat
- PostgreSQL for authentication API
- MongoDB for the main API
- ASP.NET Core Identity
- JWT Authentication 
- Github actions
- NUnit

## Roadmap
- Add localization support for multiple languages.
- Develop a mobile app for easier access.
- Add progress tracking with detailed historical data.
- Summarize meals with nutrient, calorie, and macro breakdowns for selected time periods.
- Implement gamification features to improve user engagement.


