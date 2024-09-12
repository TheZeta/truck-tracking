﻿using Core.Entities;
using Core.Enums;

namespace Core.States
{
    public class TruckStateSecondWeighingCompleted : ITruckState
    {
        public void Handle(Truck truck)
        {
            truck.SetState(TruckState.Completed);
            truck.IsVisibleOnList = false;
        }
    }
}
