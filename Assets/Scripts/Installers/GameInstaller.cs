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
            Container.Bind<CircleStateFactory>().AsSingle();
            Container.BindFactory<CircleWaitState, CircleWaitState.Factory>().WhenInjectedInto<CircleStateFactory>();
            Container.BindFactory<CircleMoveState, CircleMoveState.Factory>().WhenInjectedInto<CircleStateFactory>();
        }
    }
}