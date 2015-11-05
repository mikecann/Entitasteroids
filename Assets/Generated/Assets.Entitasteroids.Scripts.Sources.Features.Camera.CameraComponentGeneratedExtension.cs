using System.Collections.Generic;

namespace Entitas {
    public partial class Entity {
        public Assets.Entitasteroids.Scripts.Sources.Features.Camera.CameraComponent camera { get { return (Assets.Entitasteroids.Scripts.Sources.Features.Camera.CameraComponent)GetComponent(ComponentIds.Camera); } }

        public bool hasCamera { get { return HasComponent(ComponentIds.Camera); } }

        static readonly Stack<Assets.Entitasteroids.Scripts.Sources.Features.Camera.CameraComponent> _cameraComponentPool = new Stack<Assets.Entitasteroids.Scripts.Sources.Features.Camera.CameraComponent>();

        public static void ClearCameraComponentPool() {
            _cameraComponentPool.Clear();
        }

        public Entity AddCamera(UnityEngine.Camera newCamera) {
            var component = _cameraComponentPool.Count > 0 ? _cameraComponentPool.Pop() : new Assets.Entitasteroids.Scripts.Sources.Features.Camera.CameraComponent();
            component.camera = newCamera;
            return AddComponent(ComponentIds.Camera, component);
        }

        public Entity ReplaceCamera(UnityEngine.Camera newCamera) {
            var previousComponent = hasCamera ? camera : null;
            var component = _cameraComponentPool.Count > 0 ? _cameraComponentPool.Pop() : new Assets.Entitasteroids.Scripts.Sources.Features.Camera.CameraComponent();
            component.camera = newCamera;
            ReplaceComponent(ComponentIds.Camera, component);
            if (previousComponent != null) {
                _cameraComponentPool.Push(previousComponent);
            }
            return this;
        }

        public Entity RemoveCamera() {
            var component = camera;
            RemoveComponent(ComponentIds.Camera);
            _cameraComponentPool.Push(component);
            return this;
        }
    }

    public partial class Matcher {
        static IMatcher _matcherCamera;

        public static IMatcher Camera {
            get {
                if (_matcherCamera == null) {
                    _matcherCamera = Matcher.AllOf(ComponentIds.Camera);
                }

                return _matcherCamera;
            }
        }
    }
}
