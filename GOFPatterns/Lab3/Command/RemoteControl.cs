using System;

namespace Lab2.Command
{
    public class RemoteControl
    {
        private ICommand _command;

        public void SetCommand(ICommand command)
        {
            _command = command;
        }

        public void PressButton()
        {
            if (_command == null)
            {
                Console.WriteLine("No command assigned.");
                return;
            }

            _command.Execute();
        }
    }
}
