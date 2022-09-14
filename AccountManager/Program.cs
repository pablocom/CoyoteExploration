using Xunit;

namespace AccountManager;

public static class Program
{
    public static async Task Main(string[] args)
    {
        await TestConcurrentAccountCreation();
    }

    public static async Task TestAccountCreation()
    {
        var db = new InMemoryDbCollection();
        var accountManager = new AccountManager(db);

        string accountName = "MyAccount";
        string accountPayload = "...";

        var result = await accountManager.CreateAccount(accountName, accountPayload);
        Assert.True(result);

        result = await accountManager.CreateAccount(accountName, accountPayload);
        Assert.False(result);
    }

    [Microsoft.Coyote.SystematicTesting.Test]
    public static async Task TestConcurrentAccountCreation()
    {
        var db = new InMemoryDbCollection();
        var accountManager = new AccountManager(db);

        string accountName = "MyAccount";
        string accountPayload = "...";

        var task1 = accountManager.CreateAccount(accountName, accountPayload);
        var task2 = accountManager.CreateAccount(accountName, accountPayload);

        await Task.WhenAll(task1, task2);

        Assert.True(task1.Result ^ task2.Result);
    }
}