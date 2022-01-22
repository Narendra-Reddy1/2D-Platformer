using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sovereign
{
    public class FollowPlayer : MonoBehaviour
    {

        public static FollowPlayer instance;

        public Transform target;
        public Transform farBackground, middleBackground;
        private Vector2 lastPos;

        //private float lastXpos;

        public float minHeight;
        public float maxHeight;
        public bool stopFollow;


        private void Awake()
        {
            instance = this;
        }

        // Start is called before the first frame update
        void Start()
        {

            lastPos = transform.position;
        }

        // Update is called once per frame
        void Update()
        {

            if (!stopFollow)
            {
                transform.position = new Vector3(target.position.x, Mathf.Clamp(target.position.y, minHeight, maxHeight), transform.position.z);



                //---------Parallax for depth------------------------
                Vector2 amountToMove = new Vector2(transform.position.x - lastPos.x, transform.position.y - lastPos.y);

                farBackground.position += new Vector3(amountToMove.x, amountToMove.y, 0f);
                middleBackground.position += new Vector3(amountToMove.x, amountToMove.y, 0f) * .5f;
                //lastXpos = transform.position.x;
                lastPos = transform.position;
            }
        }
    }
}