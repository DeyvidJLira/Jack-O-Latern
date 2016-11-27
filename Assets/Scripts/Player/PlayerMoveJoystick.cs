using UnityEngine;
using System.Collections;

public class PlayerMoveJoystick : MonoBehaviour {

    public float m_Speed = 8f;
    public float m_MaxVelocity = 4f;

    private PlayerMovement m_PlayerMovement;
    private Rigidbody2D m_Rigidbody;
    private Animator m_Animator;
    private bool m_IsMoveLeft, m_IsMoveRight;

    void Awake() {
        m_PlayerMovement = GetComponent<PlayerMovement>();
        m_Rigidbody = GetComponent<Rigidbody2D>();
        m_Animator = GetComponent<Animator>();
    }    

    void FixedUpdate() {
        if(m_IsMoveLeft) {
            MoveLeft();
        }

        if(m_IsMoveRight) {
            MoveRight();
        }
    }

    public void SetMoveLeft(bool isMoveLeft) {
        m_IsMoveLeft = isMoveLeft;
        m_IsMoveRight = !m_IsMoveLeft;
    }

    public void StopMoving() {
        m_IsMoveLeft = m_IsMoveRight = false;
        m_Animator.SetBool("isRunning", false);
    }

    void MoveLeft() {
        float forceX = 0f;
        float velocity = Mathf.Abs(m_Rigidbody.velocity.x);

        if (m_PlayerMovement.m_IsFaceRight)
            m_PlayerMovement.TurnFace();


        if (velocity < m_MaxVelocity)
            forceX = -m_Speed;

        m_Animator.SetBool("isRunning", true);

        m_Rigidbody.AddForce(new Vector2(forceX, 0));
    }

    void MoveRight() {
        float forceX = 0f;
        float velocity = Mathf.Abs(m_Rigidbody.velocity.x);

        if (!m_PlayerMovement.m_IsFaceRight)
            m_PlayerMovement.TurnFace();

        if (velocity < m_MaxVelocity)
            forceX = m_Speed;

        m_Animator.SetBool("isRunning", true);

        m_Rigidbody.AddForce(new Vector2(forceX, 0));
    }

}
