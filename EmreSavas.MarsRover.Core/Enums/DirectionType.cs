using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EmreSavas.MarsRover.Core.Enums
{
    public enum DirectionType
    {
        [Display(Name = "N")]
        North,
        [Display(Name = "S")]
        South,
        [Display(Name = "E")]
        East,
        [Display(Name = "W")]
        West
    }
}
