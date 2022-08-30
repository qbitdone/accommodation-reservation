# Accommodation Reservation System

This is .NET Core 6 Web API for managing accommodations, reservations and locations.

### Models 
## Accommodation:
    - Id (Integer)
    - Title (String)
    - Subtitle (String)
    - Description (String)
    - Type (String)
    - Categorization (Integer)
    - PersonCount (Integer)
    - ImageUrl (String)
    - FreeCancelation (boolean)
    - Price (decimal)
    - LocationId (integer)

## Location
    - Id (Integer)
    - Name (String)
    - Postal Code (String)
    - ImageUrl (String)
   
## Reservation
    - Id (Integer)
    - Email (String)
    - CheckIn (Date)
    - CheckOut (Date)
    - PersonCount (Integer)
    - Confirmed (boolean)
    - AccommodationId (Integer)

### Functionality:
## Accommodation endpoint
  - Get all accommodations from the database
  - Insert new accommodation in the database
  - Update already existing accommodation in the database
  - Delete accommodation from the database
  - Get accommodation recommendations
  - Get all accommodations for provided location
  
## Location endpoint
  - Get all locations from the database
  - Insert new location in the database
  - Update already existing location in the database
  - Delete location from the database
  
## Reservation endpoint
  - Get all reservations from the database
  - Insert new reservation in the database
  - Update already existing reservation in the database
  - Delete reservation from the database
 


### Usage
  1. Clone the repo
  ```
git clone https://github.com/qbitdone/.net-staycation.git
  ``` 
  2. Open the application by clicking on .sln file <br />
  3. Press F5 to start the application
