using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
namespace CircleGame
{
    public class Tail : MonoBehaviour
    {

        [SerializeField]
        LineRenderer _lineRenderer;

        Circle _circle;
        List<Vector3> _positions;

        [Inject]
        public void Construct(Circle circle)
        {
            _circle = circle;
            _positions = new List<Vector3>();
        }

        void RedrawLine()
        {
            _positions.Add(_circle.Position);
            _lineRenderer.positionCount = _positions.Count;
            _lineRenderer.SetPositions(_positions.ToArray());
            
        }

        
        void Update()
        {
            if(_circle.GetState()==CircleStates.Moving)
                RedrawLine();
        }
    }
}