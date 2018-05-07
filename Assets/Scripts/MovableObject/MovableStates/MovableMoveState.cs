using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace CircleGame
{
    public class MovableMoveState : MovableState
    {
        IMovableObject _movableObject;
        Settings _settings;
        IPathController _pathController;

        Vector3 _targetPosition;

        public MovableMoveState(IMovableObject movableObject, Settings settings, IPathController pathController)
        {
            _movableObject = movableObject;
            _settings = settings;
            _pathController = pathController;
            _targetPosition = _movableObject.GetPosition();
        }

        public override void Start()
        {
            _targetPosition = _movableObject.GetPosition();
        }

        public override void Update()
        {
            Move();
        }

        void Move()
        {
            var objectPosition = Vector3.MoveTowards(_movableObject.GetPosition(), _targetPosition, Mathf.Min(1.0f, _settings.moveSpeed * Time.deltaTime));
            _movableObject.SetPosition(objectPosition);
            if (Vector3.Distance(_movableObject.GetPosition(), _targetPosition) < _settings.inaccuracy)
            {
                if (_pathController.HasNextPoint())
                {
                    _targetPosition = _pathController.DequeueNextPoint();
                    _targetPosition.z = _movableObject.GetPosition().z;
                }
                else
                {
                    _movableObject.ChangeState(MovableObjectStates.Waiting);
                }
                
            }

        }

        [Serializable]
        public class Settings
        {
            public float moveSpeed;
            public float inaccuracy;
        }

        public class Factory : Factory<MovableMoveState>
        {
        }
    }
}
