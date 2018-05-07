using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CircleGame
{

    public class MovableStateFactory
    {

        readonly MovableWaitState.Factory _waitingFactory;
        readonly MovableMoveState.Factory _movingFactory;

        public MovableStateFactory(
            MovableWaitState.Factory waitingFactory,
            MovableMoveState.Factory movingFactory
            )
        {
            _waitingFactory = waitingFactory;
            _movingFactory = movingFactory;
        }

        public MovableState CreateState(MovableObjectStates state)
        {
            switch (state)
            {
                case MovableObjectStates.Waiting:
                    {
                        return _waitingFactory.Create();
                    }
                case MovableObjectStates.Moving:
                    {
                        return _movingFactory.Create();
                    }
            }

            throw null;
        }


    }
}