using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CircleGame
{

    public interface IMovableObject
    {

        Vector3 GetPosition();
        void SetPosition(Vector3 position);
        void ChangeState(MovableObjectStates movableObjectState);

    }

    public enum MovableObjectStates
    {
        Moving,
        Waiting
    }
}

