using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using CircleGame;

namespace CircleGame
{

    public class GameInstaller : MonoInstaller
    {

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<PathController>().AsSingle();
            InstallCircle();
        }

        void InstallCircle()
        {
            Container.Bind<MovableStateFactory>().AsSingle();
            Container.BindFactory<MovableWaitState, MovableWaitState.Factory>().WhenInjectedInto<MovableStateFactory>();
            Container.BindFactory<MovableMoveState, MovableMoveState.Factory>().WhenInjectedInto<MovableStateFactory>();
        }
    }
}