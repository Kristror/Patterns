using UnityEngine;

namespace Asteroids.Modifications
{
    internal interface IScope
    {
        float Zoom { get; }
        GameObject ScopeInstance { get; }
    }
}