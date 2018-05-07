using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace CircleGame
{
    public class PathController : IPathController, IInitializable, IDisposable
    {
        private List<Vector3> _path;


        public virtual void Initialize()
        {
            _path = new List<Vector3>();
        }

        public virtual Vector3 GetNextPoint()
        {
            try
            {
                return _path[0];
            }
            catch (IndexOutOfRangeException ex)
            {
                Debug.LogError("Index out of range: 0");
                throw;
            }
        }

        public virtual void AddPoint(Vector3 point)
        {
            _path.Add(point);
        }

        public virtual void ResetPath()
        {
            _path.Clear();
        }

        public virtual Vector3[] GetAllPath()
        {
            return _path.ToArray();
        }

        public virtual Vector3 DequeueNextPoint()
        {
            try
            {
                var point = _path[0];
                _path.RemoveAt(0);
                return point;
            }
            catch (IndexOutOfRangeException ex)
            {
                Debug.LogError("Index out of range: 0");
                throw;
            }
        }

        public virtual void Dispose()
        {
            _path.Clear();
        }

        public virtual bool HasNextPoint()
        {
            return _path.Count > 0;
        }


    }
}