
namespace AccountManager;

// See https://aka.ms/new-console-template for more information
public class AccountManager
{
    private readonly IDbCollection _accountCollection;

    public AccountManager(IDbCollection accountCollection)
    {
        _accountCollection = accountCollection;
    }

    public async Task<bool> CreateAccount(string accountName, string accountPayload)
    {
        if (await _accountCollection.DoesRowExist(accountName))
        {
            return false;
        }

        await _accountCollection.CreateRow(accountName, accountPayload);
        return true;
    }

    public async Task<string> GetAccount(string accountName)
    {
        if (!await _accountCollection.DoesRowExist(accountName))
        {
            return null;
        }

        return await _accountCollection.GetRow(accountName);
    }

    public async Task<bool> DeleteAccount(string accountName)
    {
        if (!await _accountCollection.DoesRowExist(accountName))
        {
            return false;
        }

        await _accountCollection.DeleteRow(accountName);
        return true;
    }
}
