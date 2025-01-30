using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Golf
{
    public class LevelController : MonoBehaviour
    {
        public SpawnerStone spawner;
        public float delayMax = 2f;
        public float delayMin = 0.5f;
        public float delayStep = 0.1f;

        private float m_delay = 0.5f;
        private float m_lastSpawnedTime = 0;
        public int score = 0;
        public int hightScore = 0;

        private void Start()
        {
            m_lastSpawnedTime = Time.time;
            RefreshDelay();
        }

        private void OnStickHit()
        {
            score++;
            hightScore = Mathf.Max(hightScore, score);
            Debug.Log($"score: {score} - hightScore: {hightScore}");
        }

        private void OnEnable()
        {
            GameEvents.onStickHit += OnStickHit;
        }

        private void OnDisable()
        {
            GameEvents.onStickHit -= OnStickHit;
        }

        private void GameOver()
        {
            Debug.Log("Game OVER!!!");
            enabled = false;
        }

        public void RefreshDelay()
        {
            m_delay = UnityEngine.Random.Range(delayMin, delayMax);
            delayMax = Mathf.Max(delayMin, delayMax - delayStep);
        }

        private void Update()
        {
            if (Time.time >= m_lastSpawnedTime + m_delay)
            {
                spawner.Spawn();
                m_lastSpawnedTime = Time.time;
                RefreshDelay();
            }
        }
    }
}