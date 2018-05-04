using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace CircleGame
{
    public class PathController : PathControllerBase
    {
        private List<Vector3> _path;


        public override void Initialize()
        {
            _path = new List<Vector3>();
        }

        public override Vector3 GetNextPoint()
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

        public void AddPoint(Vector3 point)
        {
            _path.Add(point);
            Debug.Log(_path.Count);
        }

        public override void ResetPath()
        {
            _path.Clear();
        }

        public override Vector3[] GetAllPath()
        {
            return _path.ToArray();
        }

        public override Vector3 DequeueNextPoint()
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

        public override void Dispose()
        {
            _path.Clear();
        }

        public override bool HasNextPoint()
        {
            return _path.Count > 0;
        }


    }
}