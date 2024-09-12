using BlazorWasmClient.Shared.Enums;
using Core.Entities;

namespace Core.States
{
    public class TruckStateFirstWeighingCompleted : ITruckState
    {
        public void Handle(Truck truck)
        {
            truck.SetState(TruckState.SecondWeighingCompleted);
        }
    }
}
