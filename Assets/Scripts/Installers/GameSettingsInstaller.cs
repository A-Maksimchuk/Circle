using UnityEngine;
using System;
using Zenject;

namespace CircleGame
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "CircleGame/GameSettings")]
    public class GameSettingsInstaller : ScriptableObjectInstaller<GameSettingsInstaller>
    {

        public MovingSettings MovingState;

        [Serializable]
        public class MovingSettings
        {
            public MovableMoveState.Settings Move;
        }

        public override void InstallBindings()
        {
            Container.BindInstances(MovingState.Move);
        }
    }
}