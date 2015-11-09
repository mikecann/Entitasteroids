using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entitas;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Entitasteroids.Scripts.Controllers
{
    public class HudController : MonoBehaviour
    {
        public Text levelTxt;
        public Text scoreTxt;
        public Text livesTxt;
        public Text gameOverTxt;

        void Start()
        {
            var levels = Pools.pool.GetGroup(Matcher.Level);
            var scores = Pools.pool.GetGroup(Matcher.Score);
            var lives = Pools.pool.GetGroup(Matcher.Lives);

            levelTxt.text = (levels.GetSingleEntity().level.level + 1) + "";
            scoreTxt.text = scores.GetSingleEntity().score.score + "";
            livesTxt.text = lives.GetSingleEntity().lives.lives + "";

            levels.OnEntityAdded += OnLevelChanged;
            scores.OnEntityAdded += OnScoreChanged;
            lives.OnEntityAdded += OnLivesChanged;

            gameOverTxt.gameObject.SetActive(false);
        }

        private void OnLivesChanged(Group @group, Entity entity, int index, IComponent component)
        {
            livesTxt.text = "" + entity.lives.lives;

            if (entity.lives.lives == 0)
                gameOverTxt.gameObject.SetActive(true);
        }

        private void OnScoreChanged(Group @group, Entity entity, int index, IComponent component)
        {
            scoreTxt.text = "" + entity.score.score;
        }

        private void OnLevelChanged(Group @group, Entity entity, int index, IComponent component)
        {
            levelTxt.text = ""+ (entity.level.level + 1);
        }
    }
}
