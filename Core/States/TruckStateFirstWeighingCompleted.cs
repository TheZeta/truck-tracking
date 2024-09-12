using Core.Entities;
using Core.Enums;

namespace Core.States
{
    public class TruckStateFirstWeighingCompleted : ITruckState
    {
        public void Handle(Truck truck)
        {
            truck.SetState(TruckState.SecondWeighingCompleted);
            Console.WriteLine("Triggered");
        }
    }
}
