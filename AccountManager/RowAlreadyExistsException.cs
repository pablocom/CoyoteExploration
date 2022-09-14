// See https://aka.ms/new-console-template for more information


using System.Runtime.Serialization;

namespace AccountManager;

[Serializable]
internal class RowAlreadyExistsException : Exception
{
    public RowAlreadyExistsException()
    {
    }

    public RowAlreadyExistsException(string? message) : base(message)
    {
    }

    public RowAlreadyExistsException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected RowAlreadyExistsException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}