namespace WinTail;

/// <summary>
/// Actor responsible for serializing message writes to the console.
/// (write one message at a time, champ :)
/// </summary>
class ConsoleWriterActor : UntypedActor
{
    protected override void OnReceive(object message)
    {
        if (message is Messages.InputError msgErr)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(msgErr.Reason);
        }
        else if (message is Messages.InputSuccess msgSuccess)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(msgSuccess.Reason);
        }
        else
        {
            Console.WriteLine(message);
        }

        Console.ResetColor();
    }
}