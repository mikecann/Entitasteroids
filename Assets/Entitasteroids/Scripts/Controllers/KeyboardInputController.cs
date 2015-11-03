using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Entitasteroids.Scripts.Controllers
{
    public class KeyboardInputController : MonoBehaviour
    {
        public KeyCode turnLeft = KeyCode.LeftArrow;
        public KeyCode turnRight = KeyCode.RightArrow;
        public KeyCode accelerate = KeyCode.UpArrow;
        public KeyCode fire = KeyCode.Space;

        void Update()
        {
            var leftIsDown = Input.GetKey(turnLeft);
            var rightIsDown = Input.GetKey(turnRight);
            var accelerateIsDown = Input.GetKey(accelerate);
            var fireIsDown = Input.GetKey(fire);

            if (leftIsDown || rightIsDown || accelerateIsDown || fireIsDown)
                Pools.pool.CreateEntity()
                    .AddInput(accelerateIsDown, leftIsDown, rightIsDown, fireIsDown);
        }
    }
}
