// See https://aka.ms/new-console-template for more information


using System.Collections.Concurrent;

namespace AccountManager;

public interface IDbCollection
{
    Task CreateRow(string accountName, string accountPayload);
    Task DeleteRow(string accountName);
    Task<bool> DoesRowExist(string accountName);
    Task<string> GetRow(string accountName);
}

public class InMemoryDbCollection : IDbCollection
{
    private readonly ConcurrentDictionary<string, string> _collection = new();
    public Task CreateRow(string accountName, string accountPayload)
    {
        return Task.Run(() =>
        {
            var result = _collection.TryAdd(accountName, accountPayload);
            if (!result)
                throw new RowAlreadyExistsException();
        });
    }

    public Task DeleteRow(string accountName)
    {
        return Task.Run(() =>
        {
            var result = _collection.TryRemove(accountName, out string? value);
            if (!result)
                throw new RowAlreadyExistsException();

            return result;
        });
    }

    public Task<bool> DoesRowExist(string accountName)
    {
        return Task.Run(() =>
        {
            return _collection.ContainsKey(accountName);
        });
    }

    public Task<string> GetRow(string accountName)
    {
        return Task.Run(() =>
        {
            var result = _collection.TryGetValue(accountName, out string? value);
            if (!result)
                throw new RowAlreadyExistsException();

            return value!;
        });
    }
}