using System.Collections.Generic;

namespace Entitas {
    public partial class Entity {
        public Assets.Entitasteroids.Sources.Features.Resources.ViewComponent view { get { return (Assets.Entitasteroids.Sources.Features.Resources.ViewComponent)GetComponent(ComponentIds.View); } }

        public bool hasView { get { return HasComponent(ComponentIds.View); } }

        static readonly Stack<Assets.Entitasteroids.Sources.Features.Resources.ViewComponent> _viewComponentPool = new Stack<Assets.Entitasteroids.Sources.Features.Resources.ViewComponent>();

        public static void ClearViewComponentPool() {
            _viewComponentPool.Clear();
        }

        public Entity AddView(UnityEngine.GameObject newGameObject) {
            var component = _viewComponentPool.Count > 0 ? _viewComponentPool.Pop() : new Assets.Entitasteroids.Sources.Features.Resources.ViewComponent();
            component.gameObject = newGameObject;
            return AddComponent(ComponentIds.View, component);
        }

        public Entity ReplaceView(UnityEngine.GameObject newGameObject) {
            var previousComponent = hasView ? view : null;
            var component = _viewComponentPool.Count > 0 ? _viewComponentPool.Pop() : new Assets.Entitasteroids.Sources.Features.Resources.ViewComponent();
            component.gameObject = newGameObject;
            ReplaceComponent(ComponentIds.View, component);
            if (previousComponent != null) {
                _viewComponentPool.Push(previousComponent);
            }
            return this;
        }

        public Entity RemoveView() {
            var component = view;
            RemoveComponent(ComponentIds.View);
            _viewComponentPool.Push(component);
            return this;
        }
    }

    public partial class Matcher {
        static IMatcher _matcherView;

        public static IMatcher View {
            get {
                if (_matcherView == null) {
                    _matcherView = Matcher.AllOf(ComponentIds.View);
                }

                return _matcherView;
            }
        }
    }
}
