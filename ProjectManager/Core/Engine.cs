using System;
using Bytes2you.Validation;
using ProjectManager.CLI.Common;

namespace ProjectManager.CLI.Core
{
    public class Engine
    {
        private readonly FileLogger logger;
        private readonly CommandProcessor processor;

        public Engine(FileLogger logger, CommandProcessor processor)
        {
            // validate clauses
            Guard.WhenArgument(logger, "Engine Logger provider").IsNull().Throw();
            Guard.WhenArgument(processor, "Engine Processor provider").IsNull().Throw();

            this.logger = logger;
            this.processor = processor;
        }

        public void Start()
        {
            for (;;)
            {
                // read from console
                var cls = Console.ReadLine();

                if (cls.ToLower() == "exit")
                {
                    Console.WriteLine("Program terminated.");
                    break;
                }

                try
                {
                    var executionResult = this.processor.Process(cls);
                    Console.WriteLine(executionResult);
                }
                catch (UserValidationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Opps, something happened. :(");
                    this.logger.LogErrorMessage(ex.Message);
                }
            }
        }
    }
}
