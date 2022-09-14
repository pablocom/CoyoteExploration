# Coyote exploration

It allows you to write concurrency unit testing. Coyote will generate a rewritten Dll from the code you want to debug 
potential concurrency issues. Binary rewriting allows coyote to inject hooks and stubs in your production code. That allows
coyote to take control over the schedule of C# tasks while the test executes.

## Steps to run a test using coyote CLI:
```
> Add Microsoft.Coyote.SystematicTesting.Test attribute to the concurrency test
> dotnet tool install -g Microsoft.Coyote.CLI
> coyote rewrite .\YourDllContainingConcurrencyTests.dll
> coyote test .\YourDllContainingConcurrencyTests.dll -m TestConcurrentAccountCreation -i 100
```

The main advantage of coyote if that it there is an executiong that finds the concurrency bug, 
conditions for that to happen will be saved, so you can debug it easily having a deterministic execution plan.
