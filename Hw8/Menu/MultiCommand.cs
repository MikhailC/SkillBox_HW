using System.Collections.Generic;

namespace Hw8
{
    public class MultiCommand:List<IMenuCommand>,IMenuCommand
    {
        private int _mainCommandIndex;

        //public List<IMenuCommand> Commands = new List<IMenuCommand>();
        public string Title => this[_mainCommandIndex].Title;

        public void Execute()
        {
            foreach (var c in this)
            {
                c.Execute(); 
            }
        }

        public  MultiCommand(int maincommandIndex)
        {
            _mainCommandIndex = maincommandIndex;
        }
    }
}