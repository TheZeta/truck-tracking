using BlazorWasmClient.Shared.Enums;
using Core.States;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class Truck
    {
        public int Id { get; set; }
        public string Plate { get; set; }
        public int Weight { get; set; }
        public RawMaterialType RawMaterial { get; set; }
        public TruckState State { get; set; }

        [NotMapped]
        private ITruckState _state
        {
            get
            {
                return GetStateFromEnum(State);
            }
            set
            {
            }
        }

        public Truck()
        {
            SetState(TruckState.AwaitingWeighing);
        }

        public void SetState(TruckState newState)
        {
            State = newState;
            _state = GetStateFromEnum(newState);
        }

        public void Handle()
        {

            _state.Handle(this);
        }

        private ITruckState GetStateFromEnum(TruckState state)
        {
            return state switch
            {
                TruckState.AwaitingFirstApproval => new TruckStateAwaitingFirstApproval(),
                TruckState.AwaitingWeighing => new TruckStateAwaitingWeighing(),
                TruckState.AwaitingFinalApproval => new TruckStateAwaitingFinalApproval(),
                TruckState.Completed => new TruckStateCompleted(),
                _ => throw new ArgumentOutOfRangeException(nameof(state), state, null)
            };
        }
    }
}
