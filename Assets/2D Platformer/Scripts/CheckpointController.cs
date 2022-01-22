using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sovereign
{
    public class CheckpointController : MonoBehaviour
    {
        public static CheckpointController instance;

        private Checkpoint[] checkpoints;

        public Vector3 spawnPoint;

        private void Awake()
        {
            instance = this;
        }
        // Start is called before the first frame update
        void Start()
        {
            checkpoints = FindObjectsOfType<Checkpoint>();
            spawnPoint = PlayerController.instance.transform.position;
        }

        public void DeactivateCheckpoint()
        {
            for (int i = 0; i < checkpoints.Length; i++)
            {
                checkpoints[i].ResetCheckpoint();
            }
        }

        public void SetRespawnPoint(Vector3 respawnPoint)
        {
            this.spawnPoint = respawnPoint;
        }


    }
}