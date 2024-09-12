using Core.Entities;
using Core.Enums;

namespace Core.States
{
    public class TruckStateAwaitingWeighing : ITruckState
    {
        public void Handle(Truck truck)
        {
            truck.SetState(TruckState.FirstWeighingCompleted);
            Console.WriteLine("Hello");
        }
    }
}
