using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CircleGame
{
    public interface IPathController
    {

        Vector3 GetNextPoint();
        void ResetPath();
        Vector3[] GetAllPath();
        Vector3 DequeueNextPoint();
        bool HasNextPoint();
    }
}