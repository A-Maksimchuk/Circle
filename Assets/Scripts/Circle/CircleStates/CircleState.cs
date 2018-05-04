using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public abstract class CircleState : IDisposable
{

    public abstract void Update();

    public virtual void Start()
    {
        // optionally overridden
    }

    public virtual void Dispose()
    {
        // optionally overridden
    }

}
