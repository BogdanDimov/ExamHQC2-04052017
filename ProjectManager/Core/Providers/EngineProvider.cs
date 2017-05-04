namespace ProjectManager.CLI.Core.Providers
{
    public class EngineProvider
    {
        private readonly Engine engine;

        public EngineProvider(Engine engine)
        {
            this.engine = engine;
        }

        public void Run()
        {
            this.engine.Start();
        }
    }
}
