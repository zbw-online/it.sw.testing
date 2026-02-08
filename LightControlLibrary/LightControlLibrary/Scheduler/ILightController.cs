namespace LightControlLibrary.Scheduler
{
    public interface ILightController
    {
        public int Id { get; }

        public void LightOn();

        public void LightOff();
    }
}
