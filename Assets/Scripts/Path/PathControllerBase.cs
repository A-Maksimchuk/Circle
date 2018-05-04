using System;
using UnityEngine;
using Zenject;

namespace CircleGame
{
    public abstract class PathControllerBase : IInitializable, IDisposable, IPathController
    {

        public abstract void Initialize();
        public abstract Vector3 GetNextPoint();
        public abstract void ResetPath();
        public abstract Vector3[] GetAllPath();
        public abstract Vector3 DequeueNextPoint();
        public abstract void Dispose();
        public abstract bool HasNextPoint();
    }
}
