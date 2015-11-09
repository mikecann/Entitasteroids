using System.Collections.Generic;

namespace Entitas {
    public partial class Entity {
        public Assets.Entitasteroids.Scripts.Sources.Features.Score.ScoreComponent score { get { return (Assets.Entitasteroids.Scripts.Sources.Features.Score.ScoreComponent)GetComponent(ComponentIds.Score); } }

        public bool hasScore { get { return HasComponent(ComponentIds.Score); } }

        static readonly Stack<Assets.Entitasteroids.Scripts.Sources.Features.Score.ScoreComponent> _scoreComponentPool = new Stack<Assets.Entitasteroids.Scripts.Sources.Features.Score.ScoreComponent>();

        public static void ClearScoreComponentPool() {
            _scoreComponentPool.Clear();
        }

        public Entity AddScore(int newScore) {
            var component = _scoreComponentPool.Count > 0 ? _scoreComponentPool.Pop() : new Assets.Entitasteroids.Scripts.Sources.Features.Score.ScoreComponent();
            component.score = newScore;
            return AddComponent(ComponentIds.Score, component);
        }

        public Entity ReplaceScore(int newScore) {
            var previousComponent = hasScore ? score : null;
            var component = _scoreComponentPool.Count > 0 ? _scoreComponentPool.Pop() : new Assets.Entitasteroids.Scripts.Sources.Features.Score.ScoreComponent();
            component.score = newScore;
            ReplaceComponent(ComponentIds.Score, component);
            if (previousComponent != null) {
                _scoreComponentPool.Push(previousComponent);
            }
            return this;
        }

        public Entity RemoveScore() {
            var component = score;
            RemoveComponent(ComponentIds.Score);
            _scoreComponentPool.Push(component);
            return this;
        }
    }

    public partial class Matcher {
        static IMatcher _matcherScore;

        public static IMatcher Score {
            get {
                if (_matcherScore == null) {
                    _matcherScore = Matcher.AllOf(ComponentIds.Score);
                }

                return _matcherScore;
            }
        }
    }
}
