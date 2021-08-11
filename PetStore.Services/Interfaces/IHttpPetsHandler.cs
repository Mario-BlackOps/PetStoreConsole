namespace PetStore.Services.Interfaces
{
    public interface IHttpPetsHandler
    {
        string GetSerializedJson( string url, string key );
    }
}
