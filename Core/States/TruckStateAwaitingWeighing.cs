using BlazorWasmClient.Shared.Enums;
using Core.Entities;

namespace Core.States
{
    public class TruckStateAwaitingWeighing : ITruckState
    {
        public void Handle(Truck truck)
        {
            truck.SetState(TruckState.AwaitingFinalApproval);
        }
    }
}
