using ProjectManager.CLI.Common;
using ProjectManager.CLI.Core;
using ProjectManager.CLI.Core.Providers;
using ProjectManager.CLI.Data;
using ProjectManager.CLI.Factories;

namespace ProjectManager.CLI
{
    public class Startup
    {
        public static void Main()
        {
            var fileLogger = new FileLogger();
            var database = new Database();
            var modelsFactory = new ModelsFactory();
            var commandsFactory = new CommandsFactory(database, modelsFactory);
            var commandProcessor = new CommandProcessor(commandsFactory);
            var engine = new Engine(fileLogger, commandProcessor);
            var engineProvider = new EngineProvider(engine);
            engineProvider.Run();
        }
    }
}
