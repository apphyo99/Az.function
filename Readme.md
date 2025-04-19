# Azure Function App

This document provides instructions for setting up and running an Azure Function App.

## Prerequisites

Before you begin, ensure you have the following installed:
- [Azure CLI](https://learn.microsoft.com/en-us/cli/azure/install-azure-cli)
- [.NET Core 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Visual Studio Code](https://code.visualstudio.com/) with the Azure Functions extension
- An active Azure subscription

## Steps to Run the Azure Function App

1. **Clone the Repository**
    ```bash
    git clone <repository-url>
    cd <repository-folder>
    ```

2. **Install Dependencies**
    Navigate to the function app directory and install dependencies:
    ```bash
    npm install
    ```

3. **Run Locally**
    Use the Azure Functions Core Tools to start the function app locally:
    ```bash
    func start
    ```

4. **Deploy to Azure**
    Log in to Azure and deploy the function app:
    ```bash
    az login
    func azure functionapp publish <function-app-name>
    ```

    ## Build and Run with Docker

    You can also containerize and run the Azure Function App using Docker. Follow these steps:

    1. **Build the Docker Image**
        Build a container image for your function app:
        ```bash
        docker build -t myfunctionapp .
        ```

    2. **Run the Docker Container**
        Run the container locally:
        ```bash
        docker run -p 8080:80 myfunctionapp
        ```

    3. **Push to Azure Container Registry**
        Log in to your Azure Container Registry (ACR):
        ```bash
        az acr login --name repository-name
        ```

        Tag the Docker image for ACR:
        ```bash
        docker tag myfunctionapp repository-url/myfunctionapp-image:v1
        ```

        Push the image to ACR:
        ```bash
        docker push repository-url/myfunctionapp-image:v1
        ```

## Additional Resources

- [Azure Functions Documentation](https://learn.microsoft.com/en-us/azure/azure-functions/)
- [Azure CLI Documentation](https://learn.microsoft.com/en-us/cli/azure/)

## License

This project is licensed under the [MIT License](LICENSE).