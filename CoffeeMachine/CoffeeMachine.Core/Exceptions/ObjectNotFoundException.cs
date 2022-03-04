namespace CoffeeMachine.Core.Exceptions;

using System.Data;

/// <summary>
///     Это исключение возникает, когда запрошенный объект не найден в хранилище
/// </summary>
public sealed class ObjectNotFoundException : DataException
{
    public ObjectNotFoundException()
    {
    }

    public ObjectNotFoundException(string message)
        : base(message)
    {
    }
}