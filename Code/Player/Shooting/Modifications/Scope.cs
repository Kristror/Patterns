using UnityEngine;
namespace Asteroids.Modifications
{
    internal sealed class Scope : IScope
    {        
        public float Zoom { get; }
        public GameObject ScopeInstance { get; }

        public Scope(float zoom, GameObject scopeInstance)
        {
            Zoom = zoom;
            ScopeInstance = scopeInstance;
        }
    }
}