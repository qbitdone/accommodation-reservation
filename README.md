# Accommodation Reservation System

This is a simple .NET Core 6 application for managing accommodations. The goal was to implement Accommodation resource RESTful API over HTTP on the path: /api/accommodation

### Properties of Accommodation model:
    - Title (String, max 100 characters)
    - Subtitle (String, max 200 characters)
    - Description (String)
    - Type - one of the accommodation types (Room, Apartment, Mobile home)
    - Categorization (Integer 1-5 - mandatory)
    - PersonCount (Integer, min 1)
    - ImageUrl
    - FreeCancelation (boolean, default true)
    - Price (decimal, mandatory)

### Functionality:
  - Get all accommodations from the database
  - Insert new accommodation in the database
  - Update already existing accommodation in the database
  - Delete accommodation from the database


### Usage
  1. Clone the repo
  ```
git clone https://github.com/qbitdone/.net-staycation.git
  ``` 
  2. Open the application by clicking on .sln file <br />
  3. Press F5 to start the application
