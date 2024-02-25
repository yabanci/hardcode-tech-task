# Hardcode Tech Task

## Introduction

This project is a web application developed as a technical task for Hardcode. It provides functionality related to managing products through a RESTful API.

## Installation

To run this project locally, follow these steps:

1. **Prerequisites:** Make sure you have [.NET Core SDK](https://dotnet.microsoft.com/download) installed.

2. **Clone Repository:** Clone this repository to your local machine.
   
    ```bash
    git clone <repository-url>
    ```

3. Navigate to Project Directory: Open a terminal and navigate to the project directory.
    ```bash
    cd hardcode-tech-task
    ```

4. Restore Dependencies: Run the following command to restore dependencies:
    ```bash
    dotnet restore
    ```

5. Build Project: Once the dependencies are restored, build the project using:
    ```bash
    dotnet build
    ```

6. Run Project: Finally, run the project with:
    ```bash
    dotnet run
    ```

The application should now be running locally and accessible at http://localhost:5000.
Usage

## The application provides the following endpoints:

* `/api/product`: Retrieves all products.
* `/api/product/{id}`: Retrieves a specific product by ID.
* `/api/product`: Adds a new product.
* `/api/product/{id}`: Updates an existing product.
* `/api/product/{id}`: Deletes a product by ID.

You can use tools like Postman or curl to interact with the API endpoints.

## Documentation

### API Endpoints

#### Retrieve All Products

- **URL:** `/api/product`
- **Method:** GET
- **Description:** Retrieves all products.
- **Response:** Returns a list of products in JSON format.

#### Retrieve Product by ID

- **URL:** `/api/product/{id}`
- **Method:** GET
- **Description:** Retrieves a specific product by its ID.
- **Parameters:**
  - `{id}`: The unique identifier of the product.
- **Response:** Returns the product details in JSON format if found, or a 404 Not Found error if the product does not exist.

#### Add New Product

- **URL:** `/api/product`
- **Method:** POST
- **Description:** Adds a new product.
- **Request Body:** JSON object containing the details of the new product.
- **Response:** Returns a 200 OK response if the product is successfully added.

#### Update Product

- **URL:** `/api/product/{id}`
- **Method:** PUT
- **Description:** Updates an existing product.
- **Parameters:**
  - `{id}`: The unique identifier of the product to be updated.
- **Request Body:** JSON object containing the updated details of the product.
- **Response:** Returns a 200 OK response if the product is successfully updated, or a 400 Bad Request error if the request is invalid.

#### Delete Product

- **URL:** `/api/product/{id}`
- **Method:** DELETE
- **Description:** Deletes a product by its ID.
- **Parameters:**
  - `{id}`: The unique identifier of the product to be deleted.
- **Response:** Returns a 200 OK response if the product is successfully deleted, or a 404 Not Found error if the product does not exist.

For more detailed information on each endpoint, including request and response examples, please refer to the [API documentation](http://localhost:PORT/swagger/index.html).
