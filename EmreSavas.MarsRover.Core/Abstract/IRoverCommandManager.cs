namespace EmreSavas.MarsRover.Core.Abstract
{
    public interface IRoverCommandManager
    {
        IRover Rover { get; set; }
        void AddCommand(ICommand command);
        void ProcessCommands();
    }
}
