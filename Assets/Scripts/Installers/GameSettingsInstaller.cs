using UnityEngine;
using System;
using Zenject;

namespace CircleGame
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "CircleGame/GameSettings")]
    public class GameSettingsInstaller : ScriptableObjectInstaller<GameSettingsInstaller>
    {

        public CircleSettings Circle;

        [Serializable]
        public class CircleSettings
        {
            public CircleMoveState.Settings Move;
        }

        public override void InstallBindings()
        {
            Container.BindInstances(Circle.Move);
        }
    }
}