using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace CircleGame
{

    public class Circle : MonoBehaviour
    {

        CircleState _state = null;
        CircleStateFactory _stateFactory;
        CircleStates _circleState;

        [Inject]
        public void Construct(CircleStateFactory stateFactory)
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
            ChangeState(CircleStates.Waiting);
        }

        public void Update()
        {
            _state.Update();
        }

        public CircleStates GetState()
        {
            return _circleState;
        }

        public void ChangeState(CircleStates state)
        {
            if (_state != null)
            {
                _state.Dispose();
                _state = null;
            }
            _circleState = state;
            _state = _stateFactory.CreateState(state);
            _state.Start();
        }
    }
}