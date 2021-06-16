using UnityEngine;

namespace Asteroids
{
    internal interface IAmmunition
    {
        Rigidbody Rigidbody { get; }
        float TimeToDestroy { get; }
    }
}