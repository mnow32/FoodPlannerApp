namespace FoodPlannerAPI.User;

public interface IUserContext
{
    CurrentUser? GetCurrentUser();
}