namespace CoffeeMachine.Core.Exceptions;

using System.Data;

public sealed class ObjectAlreadyExistsException : DataException
{
    public ObjectAlreadyExistsException()
    {
    }

    public ObjectAlreadyExistsException(string message)
        : base(message)
    {
    }
}