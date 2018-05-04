using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CircleGame
{
    public enum CircleStates
    {
        Moving,
        Waiting
    }

    public class CircleStateFactory 
    {

        readonly CircleWaitState.Factory _waitingFactory;
        readonly CircleMoveState.Factory _movingFactory;

        public CircleStateFactory(
            CircleWaitState.Factory waitingFactory,
            CircleMoveState.Factory movingFactory
            )
        {
            _waitingFactory = waitingFactory;
            _movingFactory = movingFactory;
        }

        public CircleState CreateState(CircleStates state)
        {
            switch (state)
            {
                case CircleStates.Waiting:
                    {
                        return _waitingFactory.Create();
                    }
                case CircleStates.Moving:
                    {
                        return _movingFactory.Create();
                    }
            }

            throw null;
        }


    }
}