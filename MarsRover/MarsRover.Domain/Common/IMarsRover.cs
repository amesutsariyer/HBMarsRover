namespace MarsRover.Domain.Common
{
    public interface IMarsRover
    {

        DeploymentPoint DeploymentPoint { get; set; }
        Movement Movement { get; set; }
    }


}
