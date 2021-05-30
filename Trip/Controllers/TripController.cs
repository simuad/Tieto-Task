using Microsoft.AspNetCore.Mvc;
using Trip.Models;

namespace Trip.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TripController : ControllerBase
    {
        [HttpPost]
        public ActionResult<TripCheckList> PostTripData(TripData tripData)
        {
            // Create object to hold items
            TripCheckList checkList = new();

            // Check if valid values were received
            if (tripData.Distance <= 0 || tripData.DistancePerDay <= 0)
            {
                return BadRequest("Distances in trip cannot be lower or equal to zero!");
            }

            if (tripData.NumberOfPeople <= 0)
            {
                return BadRequest($"Number of people cannot be lower or equal to zero (Received {tripData.NumberOfPeople})!");
            }

            if (tripData.MealsPerDay <= 0)
            {
                return BadRequest($"Meals per day cannot be lower or equal to zero (Received {tripData.NumberOfPeople})!");
            }

            // Calculate trip duration and check if a place to stay the night is needed
            checkList.TripDurationInDays = GetTripDuration(tripData);
            checkList.AccomodationRequired = checkList.TripDurationInDays > 1;

            // If season is specified add season specific item to checklist
            if (tripData.Season != null)
            {
                Item seasonalItem = GetSeasonalItem(tripData.Season, tripData.NumberOfPeople);

                if (seasonalItem == null)
                {
                    return BadRequest($"Invalid season name '{tripData.Season}'!");
                }
                else
                {
                    checkList.TripItems.Add(seasonalItem);
                }
            }

            // Add Items related to eating
            FoodInformation(ref checkList, tripData.NumberOfPeople, tripData.MealsPerDay, checkList.TripDurationInDays);

            return Ok(checkList);
        }

        private static int GetTripDuration(TripData tripData)
        {
            // Lowest trip day duration is 1
            if (tripData.Distance < tripData.DistancePerDay)
            {
                return 1;
            }
            else
            {
                int returnedDistance = tripData.Distance / tripData.DistancePerDay;
                
                // Check if last day is not whole
                if (tripData.Distance % tripData.DistancePerDay > 0)
                {
                    returnedDistance++;
                }

                return returnedDistance;
            }
        }

        private static Item GetSeasonalItem(string season, int numOfPeople)
        {
            switch (season)
            {
                case "Spring":
                case "spring":
                    return new Item("Waterproof boots", numOfPeople);
                case "Summer":
                case "summer":
                    return new Item("Sun Hat", numOfPeople);
                case "Autumn":
                case "autumn":
                case "Fall":
                case "fall":
                    return new Item("Umbrella", numOfPeople);
                case "Winter":
                case "winter":
                    return new Item("Coat", numOfPeople);
                default:
                    // Unknown season / typo
                    return null;
            }
        }

        private static void FoodInformation(ref TripCheckList checkList, int numberOfPeople, int mealsPerDay, int days)
        {
            checkList.TripItems.Add(new Item("Eating utensil set", numberOfPeople));
            checkList.TripItems.Add(new Item("Refillable bottle", numberOfPeople));
            checkList.TripItems.Add(new Item("Meal Ready to Eat", numberOfPeople * mealsPerDay * days));
        }
    }
}
