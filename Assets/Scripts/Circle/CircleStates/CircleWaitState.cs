using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace CircleGame
{
    public class CircleWaitState : CircleState
    {
        PathController _pathController;
        Circle _circle;

        public CircleWaitState(PathController pathController, Circle circle)
        {
            _pathController = pathController;
            _circle = circle;
        }

        public override void Update()
        {
            if (_pathController.HasNextPoint())
                _circle.ChangeState(CircleStates.Moving);
        }

        public class Factory : Factory<CircleWaitState>
        {
        }
    }
}