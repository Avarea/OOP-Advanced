using System;
using System.Linq;
using System.Reflection;
using P03_BarraksWars.Core.Command;
using _03BarracksFactory.Contracts;

namespace P03_BarraksWars.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private IServiceProvider serviceProvider;

        public CommandInterpreter(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public IExecutable InterpretCommand(string[] data, string commandName)
        {
            Assembly assembly = Assembly.GetCallingAssembly();
            Type commandType = assembly.GetTypes().FirstOrDefault(c => c.Name.ToLower() == commandName + "command");

            if (commandType == null)
            {
                throw new ArgumentException("Invalid Command");
            }

            if (!typeof(IExecutable).IsAssignableFrom(commandType))
            {
                throw new ArgumentException($"{commandName} is Not a Command!");
            }

            FieldInfo[] fieldsToInject = commandType
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(f => f.CustomAttributes
                    .Any(ca => ca.AttributeType == typeof(InjectAttribute))).ToArray();

            object[] injectArgs = fieldsToInject
                .Select(f => this.serviceProvider.GetService(f.FieldType)).ToArray();

            object[] ctorArgs = new object[] {data}.Concat(injectArgs).ToArray();

            IExecutable instance = (IExecutable)Activator.CreateInstance(commandType, ctorArgs);

            return instance;
        }


    }
}
