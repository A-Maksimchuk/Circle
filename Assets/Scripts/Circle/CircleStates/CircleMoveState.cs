using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace CircleGame
{
    public class CircleMoveState : CircleState
    {
        Circle _circle;
        Settings _settings;
        PathController _pathController;

        Vector3 _targetPosition;

        public CircleMoveState(Circle circle, Settings settings, PathController pathController)
        {
            _circle = circle;
            _settings = settings;
            _pathController = pathController;
            _targetPosition = _circle.Position;
        }

        public override void Start()
        {
            _targetPosition = _circle.Position;
        }

        public override void Update()
        {
            Move();
        }

        void Move()
        {
            _circle.Position = Vector3.MoveTowards(_circle.Position, _targetPosition, Mathf.Min(1.0f, _settings.moveSpeed * Time.deltaTime));
            if(Vector3.Distance(_circle.Position, _targetPosition) < _settings.inaccuracy)
            {
                if (_pathController.HasNextPoint())
                {
                    _targetPosition = _pathController.DequeueNextPoint();
                    _targetPosition.z = _circle.Position.z;
                }
                else
                {
                    Debug.Log("No points");
                    _circle.ChangeState(CircleStates.Waiting);
                }
                
            }

        }

        [Serializable]
        public class Settings
        {
            public float moveSpeed;
            public float inaccuracy;
        }

        public class Factory : Factory<CircleMoveState>
        {
        }
    }
}
