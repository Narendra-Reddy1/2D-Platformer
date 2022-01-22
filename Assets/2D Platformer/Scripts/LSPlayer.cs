using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace Sovereign
{
    public class LSPlayer : MonoBehaviour
    {
        public static LSPlayer lsPlayerInstance;
        public float moveSpeed;

        public LevelSelect currentPoint;

        private void Awake()
        {
            lsPlayerInstance = this;
        }

        void Start()
        {

        }

        void Update()
        {
            LSPlayerMovement();

        }

        void LSPlayerMovement()
        {
            transform.position = Vector3.MoveTowards(transform.position, currentPoint.transform.position, moveSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, currentPoint.transform.position) < 0.1f)
            {

                if (Input.GetAxisRaw("Horizontal") > 0.5f)
                {
                    if (currentPoint.right != null)
                    { SetNextPoint(currentPoint.right); }
                }

                if (Input.GetAxisRaw("Horizontal") < -0.5f)
                {
                    if (currentPoint.left != null)
                    {
                        SetNextPoint(currentPoint.left);
                    }
                }

                if (Input.GetAxisRaw("Vertical") > 0.5f)
                {
                    if (currentPoint.up != null)
                    {
                        SetNextPoint(currentPoint.up);
                    }
                }

                if (Input.GetAxisRaw("Vertical") < -0.5f)
                {
                    if (currentPoint.down != null)
                    {
                        SetNextPoint(currentPoint.down);
                    }
                }
                CheckLevel();
            }
        }

        void CheckLevel()
        {
            if (currentPoint.isLevel)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    LSManager.lsManagerInstance.LoadLevel();
                }
            }
        }
        private void SetNextPoint(LevelSelect nextPoint)
        {
            currentPoint = nextPoint;
        }
    }
}