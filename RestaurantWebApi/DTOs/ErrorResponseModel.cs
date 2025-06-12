namespace RestaurantWeb.DTOs;

public record ErrorResponseModel(
    int Code,
    string Message,
    Dictionary<string, object> Details = null
);