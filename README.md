# BP Meter - ASP.NET Project

## Overview
The **BP Meter** project is a web-based application developed using **ASP.NET Core MVC**. It allows users to manage and monitor blood pressure (BP) measurements. The application features validation checks, temporary data storage using **ViewData** and **TempData**, and implements sorting and filtering functionalities to improve user interaction and data management.

## Features
- **Validation:** Ensures that user input is valid before submission, with proper error handling for incorrect data types and missing fields.
- **Temporary Data Storage:** Utilized **ViewData** and **TempData** to store messages temporarily, such as success or error notifications, to enhance the user experience.
- **Sorting and Filtering:** Implemented sorting and filtering features to allow users to organize and view BP measurements according to different criteria.
- **User Interface:** Designed a user-friendly interface with **Bootstrap** for styling and responsive layout.

## Technologies Used
- **ASP.NET Core MVC**
- **C#**
- **Entity Framework Core**
- **Bootstrap**
- **HTML/CSS**
- **JavaScript**

## Setup Instructions
1. Clone this repository to your local machine:

    ```bash
    git clone https://github.com/Khanna-01/BP-meter.git
    ```

2. Navigate to the project directory:

    ```bash
    cd BP-meter
    ```

3. Install the required NuGet packages:

    ```bash
    dotnet restore
    ```

4. Update the database:

    ```bash
    dotnet ef database update
    ```

5. Run the application:

    ```bash
    dotnet run
    ```

6. Open the application in your browser at **http://localhost:5000**.

## Usage
- **Create a New BP Measurement:** Navigate to the "Create" page and enter BP measurement data. The system will validate the inputs before saving.
- **View BP Measurements:** The "Index" page displays all BP measurements. You can sort and filter the data based on different parameters.
- **Edit or Delete Measurements:** You can update or delete existing records from the "Edit" and "Delete" pages.

## Contributing
Feel free to fork the project and make contributions. If you encounter any issues or have suggestions, please open an issue or submit a pull request.

## License
This project is licensed under the **MIT License**.
