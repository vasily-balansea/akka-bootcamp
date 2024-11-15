namespace WinTail;

static class Program
{
    public static ActorSystem MyActorSystem;

    static void Main()
    {
        // initialize MyActorSystem
        MyActorSystem = ActorSystem.Create("MyActorSystem");

        IActorRef consoleWriterActor = MyActorSystem.ActorOf(Props.Create<ConsoleWriterActor>(), "consoleWriterActor");

        //Props validationActorProps = Props.Create(() => new ValidationActor(consoleWriterActor));
        IActorRef validationActor = MyActorSystem.ActorOf(Props.Create(() => new ValidationActor(consoleWriterActor)), "validationActor");

        //Props consoleReaderProps = Props.Create<ConsoleReaderActor>(validationActor);
        IActorRef consoleReaderActor = MyActorSystem.ActorOf(Props.Create<ConsoleReaderActor>(validationActor), "consoleReaderActor");

        // tell console reader to begin
        consoleReaderActor.Tell(ConsoleReaderActor.StartCommand);

        // blocks the main thread from exiting until the actor system is shut down
        MyActorSystem.WhenTerminated.Wait();
    }
}