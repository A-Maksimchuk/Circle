using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using CircleGame;

[RequireComponent(typeof(Slider))]
public class SpeedController : MonoBehaviour {

    Slider _slider;
    MovableMoveState.Settings _settings;

    [Inject]
    public void Constructor(MovableMoveState.Settings settings)
    {
        _settings = settings;
        _slider = GetComponent<Slider>();
        _slider.value = _settings.moveSpeed;
        _slider.onValueChanged.AddListener(SetCircleSpeed);
    }
	
	void SetCircleSpeed(float f)
    {
        _settings.moveSpeed = f;
    }
}
