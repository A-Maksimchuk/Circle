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
        [SerializeField]
        float _minVertexDistance;

        Circle _circle;
        Vector3 _lastPosition;


        [Inject]
        public void Construct(Circle circle)
        {
            _circle = circle;
            _lastPosition = _circle.Position;
        }



        void RedrawLine()
        {
            if (Vector3.Distance(_lastPosition, _circle.Position)>_minVertexDistance)
            {
                _lastPosition = _circle.Position;
                _lineRenderer.positionCount = _lineRenderer.positionCount + 1;
                _lineRenderer.SetPosition(_lineRenderer.positionCount - 1, _lastPosition);
            }
        }

        
        void Update()
        {
            if(_circle.GetState()==CircleStates.Moving)
                RedrawLine();
        }
    }
}