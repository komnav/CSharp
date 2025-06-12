namespace RestaurantWeb.Exceptions;

public class ResourceWasNotDeletedException : Exception
{
    public ResourceWasNotDeletedException(string resourceName,
        params object[] resourceParams
    ) : base($"Resource {resourceName} was not created. Params: {string.Join(',', resourceParams)}')")
    {
    }
}