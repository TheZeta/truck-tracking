using Core.Enums;
using Core.States;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class Truck
    {
        public int Id { get; set; }
        public string LicensePlate { get; set; }
        public int ClaimedRawMaterialWeight { get; set; }
        public RawMaterialType RawMaterial { get; set; }
        public int FirstWeighing { get; set; }
        public int SecondWeighing { get; set; }
        public TruckState State { get; set; }
        public bool IsVisibleOnList { get; set; }

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
                TruckState.AwaitingWeighing => new TruckStateAwaitingWeighing(),
                TruckState.FirstWeighingCompleted => new TruckStateFirstWeighingCompleted(),
                TruckState.SecondWeighingCompleted => new TruckStateSecondWeighingCompleted(),
                TruckState.Completed => new TruckStateCompleted(),
                _ => throw new ArgumentOutOfRangeException(nameof(state), state, null)
            };
        }
    }
}
