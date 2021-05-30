# Trip app
## Installation
Clone the repository:
```bash
git clone https://github.com/simuad/Tieto-Task
cd Tieto-Task/
```
Launch docker container:
```bash
docker-compose build
docker-compose up
```

Container runs on port 80

## Usage
Test with POST on [Postman](https://www.postman.com/).
```
http://localhost:80/trip
```

## Parameters
| Parameter      | Type        | Required| Default value|  
|----------------|-------------|---------|--------------|
| distance       | int         | yes     | -            |
| distancePerDay | int         | no      | 20           |
| numberOfPeople | int         | no      | 1            |
| mealsPerDay    | int         | no      | 1            |
| season         | string      | no      | -            |

All int parameters are higher than zero (>0).

Allowed season names are: "Spring", "spring", "Summer", "summer", "Autumn", "autumn", "Fall", "fall", "Winter", "winter".

## Example JSON and Responses

### Example 1:
```JSON
{
    "distance": 100,
    "distancePerDay": 30,
    "mealsPerDay": 2,
    "numberOfPeople": 2,
    "season": "Winter"
}
```
Response:
```JSON
{
    "tripDurationInDays": 4,
    "accomodationRequired": true,
    "tripItems": [
        {
            "name": "Coat",
            "quantity": 2
        },
        {
            "name": "Eating utensil set",
            "quantity": 2
        },
        {
            "name": "Refillable bottle",
            "quantity": 2
        },
        {
            "name": "Meal Ready to Eat",
            "quantity": 16
        }
    ]
}
```
### Example 2:
```JSON
{
    "distance": 20,
    "mealsPerDay": 1
}
```
Response:
```JSON
{
    "tripDurationInDays": 1,
    "accomodationRequired": false,
    "tripItems": [
        {
            "name": "Eating utensil set",
            "quantity": 1
        },
        {
            "name": "Refillable bottle",
            "quantity": 1
        },
        {
            "name": "Meal Ready to Eat",
            "quantity": 1
        }
    ]
}
```