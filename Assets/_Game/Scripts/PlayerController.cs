using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SwipeToLead
{
    public class PlayerController : MonoBehaviour
    {
        private Vector2 m_moveDirection;
        private Camera m_camera;
        [SerializeField] private Vector2 m_groundCheckSize = new Vector2(.1f, .1f);
        [SerializeField] private LayerMask m_groundCheckLayer;
        [SerializeField] private Transform m_groundCheckPoint;
        [SerializeField]private Rigidbody2D m_rigidbody2D;

        private bool m_isGrounded = true;
        [SerializeField]private float m_moveForce = 10f;

        private void Awake()
        {
            CheckDependencies();
        }

        private void Update()
        {
            if (m_isGrounded)
                GetInputDirection();

            CheckSurroundings();
            UpdatePlayerPose();
        }

        private void FixedUpdate()
        {
            ApplyMovement();
        }

        private void CheckDependencies()
        {
            m_camera = Camera.main;
            if (!m_rigidbody2D)
                m_rigidbody2D = GetComponent<Rigidbody2D>();


        }

        private void GetInputDirection()
        {
            m_moveDirection = m_camera.ScreenToWorldPoint(InputManager.instance.TouchMovedPos) - m_camera.ScreenToWorldPoint(InputManager.instance.InitialTouchPos);
                
                m_moveDirection.Normalize();
                if (Mathf.Abs(m_moveDirection.x) <= .75f)
                    m_moveDirection.x = 0f;
                if (Mathf.Abs(m_moveDirection.y) <= .75f)
                    m_moveDirection.y = 0f;

            Debug.Log(m_moveDirection + "Mag" + m_moveDirection.SqrMagnitude());


        }

        private void UpdatePlayerPose()
        {
            float xValue = 0f;
            if (m_moveDirection.y > 0)
                 xValue= 180f;
            if (m_moveDirection.y < 0)
                xValue = 0f;

            transform.rotation = Quaternion.Euler(xValue, 0f, 90 * Mathf.RoundToInt(m_moveDirection.x));
            
        }

        private void ApplyMovement()
        {
            m_rigidbody2D.velocity = m_moveDirection *m_moveForce;
            //    m_rigidbody2D.AddForce(m_moveDirection * -m_moveForce ,ForceMode2D.Impulse);
        }

        private void CheckSurroundings()
        {
            m_isGrounded = Physics2D.BoxCast(m_groundCheckPoint.position, m_groundCheckSize, 0f, -transform.up,.25f,m_groundCheckLayer.value);
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireCube(m_groundCheckPoint.position, m_groundCheckSize);
        }

    }
}