using LightControlLibrary.Scheduler;

namespace LightControlLibrary.Controller
{
    internal class LightController : ILightController
    {
        public int Id { get; private set; }

        public LightController(int id)
        {
            Id = id;
        }

        public void LightOff()
        {
            Console.WriteLine($"#{Id}\tLight Off");
        }

        public void LightOn()
        {
            Console.WriteLine($"#{Id}\tLight On");
        }
    }
}
