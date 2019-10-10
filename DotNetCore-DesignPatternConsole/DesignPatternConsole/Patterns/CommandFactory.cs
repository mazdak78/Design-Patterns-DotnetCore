using DesignPatternConsole.Patterns.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternConsole.Patterns.CommandFactory
{
    // based on stackflow page
    // https://stackoverflow.com/questions/8788366/using-the-command-and-factory-design-patterns-for-executing-queued-jobs

    public class CommandFactory
    {
        private readonly IDictionary<string, Func<ICommand>> _commands;

        public CommandFactory()
        {
            _commands = new Dictionary<string, Func<ICommand>>
                        {
                            {"COMMAND A", () => new InformGoup1Command(new Informable())},
                            {"COMMAND B", () => new InformGoup2Command(new Informable())}
                        };
        }

        public ICommand GetCommand(string jobKey)
        {
            Func<ICommand> command;
            _commands.TryGetValue(jobKey.ToUpper(), out command);
            return command();
        }
    }


}
