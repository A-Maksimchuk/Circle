using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace CircleGame
{
    public class MovableWaitState : MovableState
    {
        PathController _pathController;
        IMovableObject _movableObject;

        public MovableWaitState(PathController pathController, IMovableObject movableObject)
        {
            _pathController = pathController;
            _movableObject = movableObject;
        }

        public override void Update()
        {
            if (_pathController.HasNextPoint())
                _movableObject.ChangeState(MovableObjectStates.Moving);
        }

        public class Factory : Factory<MovableWaitState>
        {
        }
    }
}