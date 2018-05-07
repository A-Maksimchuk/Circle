using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace CircleGame
{

    public class Circle : MonoBehaviour, IMovableObject
    {

        MovableState _state = null;
        MovableStateFactory _stateFactory;

        [Inject]
        public void Construct(MovableStateFactory stateFactory)
        {
            _stateFactory = stateFactory;
        }

        public Vector3 Position
        {
            get { return transform.position; }
            set { transform.position = value; }
        }

        public void Start()
        {
            ChangeState(MovableObjectStates.Waiting);
        }

        public void Update()
        {
            _state.Update();
        }

        public Vector3 GetPosition()
        {
            return transform.position;
        }

        public void ChangeState(MovableObjectStates state)
        {
            if (_state != null)
            {
                _state.Dispose();
                _state = null;
            }
            _state = _stateFactory.CreateState(state);
            _state.Start();
        }

        public void SetPosition(Vector3 position)
        {
            
            transform.position = position;

        }

    }
}