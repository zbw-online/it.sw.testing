namespace LightControlLibrary.Scheduler
{
    public class LightScheduler
    {
        protected class Schedule(DateTime time, int id, bool on)
        {
            public DateTime Timestamp => time;
            public int ControllerId => id;
            public bool On => on;

            public Schedule? Next;
        }

        private readonly Utils.LinkedList<ILightController> _controllers = new();

        private readonly DateTime _current = DateTime.Now;
        private Schedule? _head;

        public void AddController(ILightController controller)
        {
            _controllers.Add(controller);
        }

        public void RemoveController(ILightController controller)
        {
            _controllers.Remove(controller);
        }

        public void AddSchedule(DateTime time, int id, bool on)
        {
            _head = new Schedule(time, id, false);
        }

        public void RemoveSchedule(DateTime time, int id)
        {
            ref var origin = ref _head;
            while (origin != null)
            {
                if ((origin.Timestamp == time)
                    && (origin.ControllerId == id))
                {
                    origin = ref origin.Next;
                }
            }
        }

        public void NextTick()
        {
            _current.AddSeconds(1);
            
            while (_head!.Timestamp < _current)
            {
                var controller = _controllers.Get(c => c.Id == _head.ControllerId);

                if (_head.On)
                {
                    controller!.LightOn();
                }
                else
                {
                    controller!.LightOff();
                }

                _head = _head.Next;
            }
        }
    }
}
