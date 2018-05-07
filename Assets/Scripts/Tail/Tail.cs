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

        IMovableObject _movableObject;
        Vector3 _lastPosition;


        [Inject]
        public void Construct(IMovableObject movableObject)
        {
            _movableObject = movableObject;
            _lastPosition = _movableObject.GetPosition();
        }



        void RedrawLine()
        {
            if (Vector3.Distance(_lastPosition, _movableObject.GetPosition())>_minVertexDistance)
            {
                _lastPosition = _movableObject.GetPosition();
                _lineRenderer.positionCount = _lineRenderer.positionCount + 1;
                _lineRenderer.SetPosition(_lineRenderer.positionCount - 1, _lastPosition);
            }
        }

        
        void Update()
        {
                RedrawLine();
        }
    }
}