﻿using System;
using System.Linq;
using ProjectManager.CLI.Factories;

namespace ProjectManager.CLI.Common
{
    public class CommandProcessor
    {
        private readonly CommandsFactory factory;

        public CommandProcessor(CommandsFactory factory)
        {
            this.factory = factory;
        }

        public string Process(string commandLine)
        {
            if (string.IsNullOrWhiteSpace(commandLine))
            {
                throw new UserValidationException("No command has been provided!");
            }

            // don't remove, code will blow up
            if (commandLine.Split(' ').Length > 10)
            {
                throw new ArgumentException();
            }

            var command = this.factory.CreateCommandFromString(commandLine.Split(' ')[0]);

            return command.Execute(commandLine.Split(' ').Skip(1).ToList());
        }
    }
}
