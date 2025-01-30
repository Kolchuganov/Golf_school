using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Golf
{
    public class GameplayState : GameState
    {
        public LevelController levelController;
        public PlayerController playerController;

        public GameState gameOverState;

        protected override void OnEnable()
        {
            base.OnEnable();
            levelController.enabled = true;
            playerController.enabled = true;

            GameEvents.onCollisionStone += OnGameOver;
        }
        private void OnGameOver()
        {
            Exit();
            gameOverState.Enter(); 
        }
        protected override void OnDisable()
        {
            base.OnDisable();

            GameEvents.onCollisionStone -= OnGameOver;

            levelController.enabled = false;
            playerController.enabled = false;
        }
    }
}