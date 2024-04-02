using Playground.Exceptions;

namespace Playground.Clients;

public class RestDatabaseClient
{
    public static readonly Dictionary<Guid, object> Database = [];

    public void StoreObject(Guid id, object obj)
    {
        Database[id] = obj;
    }

    internal T? GetObject<T>(Guid id)
        where T : class
    {
        if (!Database.TryGetValue(id, out var obj))
        {
            return null;
        }

        return obj as T ?? throw new InternalServerErrorException($"Object with id {id} cannot be converted from type {obj!.GetType().Name} to {typeof(T).Name}");
    }
}
