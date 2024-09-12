using BlazorWasmClient.Shared.Enums;
using Core.Entities;

namespace Core.States
{
    public class TruckStateAwaitingFirstApproval : ITruckState
    {
        public void Handle(Truck truck)
        {
            truck.SetState(TruckState.AwaitingWeighing);
        }
    }
}
