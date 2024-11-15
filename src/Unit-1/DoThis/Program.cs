﻿namespace WinTail;

static class Program
{
    public static ActorSystem MyActorSystem;

    static void Main()
    {
        // initialize MyActorSystem
        MyActorSystem = ActorSystem.Create("MyActorSystem");

        // time to make your first actors!
        var consoleWriterActor = MyActorSystem.ActorOf(Props.Create(() => new ConsoleWriterActor()), "consoleWriterActor");
        var consoleReaderActor = MyActorSystem.ActorOf(Props.Create(() => new ConsoleReaderActor(consoleWriterActor)), "consoleReaderActor");

        // tell console reader to begin
        consoleReaderActor.Tell(ConsoleReaderActor.StartCommand);

        // blocks the main thread from exiting until the actor system is shut down
        MyActorSystem.WhenTerminated.Wait();
    }
}