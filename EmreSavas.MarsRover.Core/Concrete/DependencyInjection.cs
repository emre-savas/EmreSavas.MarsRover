using EmreSavas.MarsRover.Core.Abstract;
using EmreSavas.MarsRover.Core.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace EmreSavas.MarsRover.Core.Concrete
{
    public class DependencyInjection
    {
        public static ServiceProvider Configure()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddTransient<ICommand, TurnLeftCommand>();
            services.AddTransient<ICommand, TurnRightCommand>();
            services.AddTransient<ICommand, MoveCommand>();
            services.AddTransient<IRoverCommandManager, RoverCommandManager>();
            services.AddTransient<IRoverPosition, RoverPosition>();
            services.AddTransient<IRover, Rover>();
            services.AddTransient<IPlateauGrid, PlateauGrid>();

            return services.BuildServiceProvider();
        }
    }
}
