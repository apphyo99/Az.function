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

## Additional Resources

- [Azure Functions Documentation](https://learn.microsoft.com/en-us/azure/azure-functions/)
- [Azure CLI Documentation](https://learn.microsoft.com/en-us/cli/azure/)

## License

This project is licensed under the [MIT License](LICENSE).