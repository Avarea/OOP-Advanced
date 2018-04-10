using BashSoft.Contracts;

namespace BashSoft
{
    using Static_data;

    class Launcher
    {
        static void Main()
        {
            Welcome.Message();
            IContentComparer tester = new Tester();
            IDirectoryManager ioManager = new IOManager();
            IDatabase repo = new StudentsRepository(new RepositoryFilter(), new RepositorySorter());
            
            IInterpreter currentInterpreter = new CommandInterpreter(tester,repo, ioManager);
            IReader reader = new InputReader(currentInterpreter);
            reader.StartReadingCommands();
        }
    }
}
