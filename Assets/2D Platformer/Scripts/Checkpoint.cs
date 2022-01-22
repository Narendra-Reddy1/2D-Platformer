using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sovereign
{
    public class Checkpoint : MonoBehaviour
    {

        private SpriteRenderer sr;
        public Sprite cpOn, cpOff;


        void Start()
        {
            sr = GetComponent<SpriteRenderer>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                CheckpointController.instance.DeactivateCheckpoint();
                sr.sprite = cpOn;
                CheckpointController.instance.SetRespawnPoint(transform.position);
            }
        }
        public void ResetCheckpoint()
        {
            sr.sprite = cpOff;
        }
    }
}