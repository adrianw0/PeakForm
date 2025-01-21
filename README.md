# PeakForm
[![Build](https://github.com/adrianw0/Fuel/actions/workflows/dotnet.yml/badge.svg)](https://github.com/adrianw0/Fuel/actions/workflows/dotnet.yml)


# PeakForm - Diet and Meal Planning App

## Features

- **Integration with OpenAI:**
  - Assistance in creating and adjusting personalized diet plans.
  - Personalized diet suggestions generated by OpenAI, automatically considering previously entered user data in the application.

- **Integration with OpenFoodFacts:**
  - Ability to fetch product data from the OpenFoodFacts database using product names or barcodes.

- **User Parameter Tracking:**
  - Functionality to monitor user metrics such as weight, body measurements, and goals.

- **Core Features:**
  - Ability to create and manage meals, custom products, and dishes.

# Installation Instructions

## 1. Download the Release

Instead of building the application yourself, you can simply download the latest release from the [Releases section](#) on GitHub.

- Download the `docker-compose.yml` and `.env` files.

## 2. Set up the Environment
- Copy the `.env.example` file to `.env`:
   ```bash
   cp .env.example .env
   ```
- Edit the .env file to set the appropriate values for your environment
- Run the application using command
  ```docker compose up```
  This will pull the required Docker images and start the application.
## 3. Stopping the Application 
  To stop the services run 
  ```docker compose down```
  
# Building the Application from Source
If you want to build the application from source instead of using the pre-built images, follow these steps:
## 1. Clone the Repository

First, clone the repository to your local machine:

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
- Next, you'll need to build the Docker images for both the main API and the auth API. In the project root, run the following command:
```bash
docker compose up
```

## Stopping the Application
- To stop the services, run:
```bash
docker compose down
```
