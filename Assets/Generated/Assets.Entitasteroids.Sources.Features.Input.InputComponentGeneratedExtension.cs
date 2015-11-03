using System.Collections.Generic;

namespace Entitas {
    public partial class Entity {
        public Assets.Entitasteroids.Sources.Features.Input.InputComponent input { get { return (Assets.Entitasteroids.Sources.Features.Input.InputComponent)GetComponent(ComponentIds.Input); } }

        public bool hasInput { get { return HasComponent(ComponentIds.Input); } }

        static readonly Stack<Assets.Entitasteroids.Sources.Features.Input.InputComponent> _inputComponentPool = new Stack<Assets.Entitasteroids.Sources.Features.Input.InputComponent>();

        public static void ClearInputComponentPool() {
            _inputComponentPool.Clear();
        }

        public Entity AddInput(bool newAccelerate, bool newTurnLeft, bool newTurnRight, bool newFire) {
            var component = _inputComponentPool.Count > 0 ? _inputComponentPool.Pop() : new Assets.Entitasteroids.Sources.Features.Input.InputComponent();
            component.accelerate = newAccelerate;
            component.turnLeft = newTurnLeft;
            component.turnRight = newTurnRight;
            component.fire = newFire;
            return AddComponent(ComponentIds.Input, component);
        }

        public Entity ReplaceInput(bool newAccelerate, bool newTurnLeft, bool newTurnRight, bool newFire) {
            var previousComponent = hasInput ? input : null;
            var component = _inputComponentPool.Count > 0 ? _inputComponentPool.Pop() : new Assets.Entitasteroids.Sources.Features.Input.InputComponent();
            component.accelerate = newAccelerate;
            component.turnLeft = newTurnLeft;
            component.turnRight = newTurnRight;
            component.fire = newFire;
            ReplaceComponent(ComponentIds.Input, component);
            if (previousComponent != null) {
                _inputComponentPool.Push(previousComponent);
            }
            return this;
        }

        public Entity RemoveInput() {
            var component = input;
            RemoveComponent(ComponentIds.Input);
            _inputComponentPool.Push(component);
            return this;
        }
    }

    public partial class Matcher {
        static IMatcher _matcherInput;

        public static IMatcher Input {
            get {
                if (_matcherInput == null) {
                    _matcherInput = Matcher.AllOf(ComponentIds.Input);
                }

                return _matcherInput;
            }
        }
    }
}
