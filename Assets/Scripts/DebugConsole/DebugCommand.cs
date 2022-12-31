using System;

public class DebugCommandBase
{
    private string commandId;
    private string commandDescription;
    private string commandFormat;

    public string CommandId { get => commandId; }
    public string CommandDescription { get => commandDescription; }
    public string CommandFormat { get => commandFormat; }

    public DebugCommandBase(string commandId, string commandDescription, string commandFormat)
    {
        this.commandId = commandId;
        this.commandDescription = commandDescription;
        this.commandFormat = commandFormat;
    }
}

public class DebugCommand : DebugCommandBase
{
    private Action command;

    public DebugCommand(string commandId, string commandDescription, string commandFormat, Action command) : base(commandId, commandDescription, commandFormat)
    {
        this.command = command;
    }

    public void Invoke()
    {
        command.Invoke();
    }
}

public class DebugCommand<T1> : DebugCommandBase
{
    private Action<T1> command;

    public DebugCommand(string commandId, string commandDescription, string commandFormat, Action<T1> command) : base(commandId, commandDescription, commandFormat)
    {
        this.command = command;
    }

    public void Invoke(T1 value)
    {
        command.Invoke(value);
    }
}

public class DebugCommand<T1, T2> : DebugCommandBase
{
    private Action<T1, T2> command;

    public DebugCommand(string commandId, string commandDescription, string commandFormat, Action<T1, T2> command) : base(commandId, commandDescription, commandFormat)
    {
        this.command = command;
    }

    public void Invoke(T1 value, T2 value2)
    {
        command.Invoke(value, value2);
    }
}
