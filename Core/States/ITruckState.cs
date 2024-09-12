using Core.Entities;

namespace Core.States
{
    public interface ITruckState
    {
        void Handle(Truck truck);
    }
}
