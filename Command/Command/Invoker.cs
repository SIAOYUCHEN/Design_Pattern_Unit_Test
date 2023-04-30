using System.Collections.Generic;

namespace Command
{
    public class Invoker
    {
        private List<Command> commandList = new List<Command>();

        public void AddCommand(Command command) {
            commandList.Add(command);
        }

        public void Execute(){
            foreach (var list in commandList)
            {
                list.Execute();
            }
        }
    }
}