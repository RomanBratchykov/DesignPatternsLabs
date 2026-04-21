namespace Lab2.Command
{
    public class TurnOnCommand : ICommand
    {
        private readonly Light _light;

        public TurnOnCommand(Light light)
        {
            _light = light;
        }

        public void Execute()
        {
            _light.TurnOn();
        }
    }
}
