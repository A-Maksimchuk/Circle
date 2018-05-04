using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CircleGame;
using Zenject;
using UnityEngine.EventSystems;
using System;

public class PointHandler : MonoBehaviour, IPointerClickHandler {

    PathController _pathController;
    Camera _mainCamera;

    [Inject]
    public void Constructor(PathController pathController, Camera mainCamera)
    {
        _pathController = pathController;
        _mainCamera = mainCamera;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _pathController.AddPoint(_mainCamera.ScreenToWorldPoint(Input.mousePosition));
    }
}
