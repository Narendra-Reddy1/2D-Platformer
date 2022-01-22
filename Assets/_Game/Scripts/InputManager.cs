using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SwipeToLead
{
    public class InputManager : MonoBehaviour
    {
        public static InputManager instance { get; private set; }

        [SerializeField]   private Touch m_touch1;
        

        [SerializeField]private Vector2 m_touch1Pos;
        [SerializeField]private Vector2 m_touch2Pos;

        public Vector2 InitialTouchPos
        {
            get
            {
                return m_touch1Pos;
            }
        }
        public Vector2 TouchMovedPos { get { return m_touch2Pos; } }

        private void Awake()
        {
            instance = this;
        }

        private void Update()
        {
            GetInput();
        }

        private void GetInput()
        {
            if (Input.touchCount == 0)
                return;
            m_touch1 = Input.GetTouch(0);
            if (m_touch1.phase == TouchPhase.Began)
                m_touch1Pos = m_touch1.position;
            if (m_touch1.phase == TouchPhase.Moved)
                m_touch2Pos = m_touch1.position;
            if (m_touch1.phase == TouchPhase.Canceled)
                m_touch1 = Input.GetTouch(0);
        }




    }
}