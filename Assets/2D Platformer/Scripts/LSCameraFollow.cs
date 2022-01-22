using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sovereign
{
    public class LSCameraFollow : MonoBehaviour
    {

        [SerializeField] private Vector2 minPos, maxPos;

        [SerializeField] private Transform target;
        void Start()
        {

        }

        // Update is called once per frame
        void LateUpdate()
        {
            FollowTarget();
        }

        void FollowTarget()
        {
            float xPos = Mathf.Clamp(target.position.x, minPos.x, maxPos.x);
            float yPos = Mathf.Clamp(target.position.y, minPos.y, maxPos.y);
            transform.position = new Vector3(xPos, yPos, transform.position.z);

        }
    }
}