using BlazorWasmClient.Shared.Enums;
using Core.Entities;

namespace Core.States
{
    internal class TruckStateAwaitingFinalApproval : ITruckState
    {
        public void Handle(Truck truck)
        {
            truck.SetState(TruckState.Completed);
            truck.IsVisibleOnList = false;
        }
    }
}
