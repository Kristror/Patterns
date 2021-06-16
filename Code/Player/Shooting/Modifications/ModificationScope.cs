using UnityEngine;

namespace Asteroids.Modifications
{
    internal sealed class ModificationScope : ModificationWeapon
    {
        private readonly IScope _scope;
        private readonly float _oldZoom;
        private readonly Vector3 _scopePosition;
        private readonly Camera _camera;
        private GameObject _scopeInstaince;

        public ModificationScope(Camera camera, IScope scope)
        {
            _camera = camera;
            _oldZoom = camera.fieldOfView;
            _scope = scope;
        }

        protected override Weapon AddModification(Weapon weapon)
        {
            _camera.fieldOfView = _scope.Zoom;
            _scopeInstaince = Object.Instantiate(_scope.ScopeInstance, _scopePosition, Quaternion.identity);
            return weapon;
        }
        protected override void RemoveModification()
        {
            Object.Destroy(_scopeInstaince);
            _camera.fieldOfView = _oldZoom;
        }
    }
}