using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float m_Speed = 8f;
	public float m_MaxVelocity = 4f;
	public bool m_IsFaceRight = true;
    public GameObject m_GroundVerify;

	private SpriteRenderer m_SpriteRenderer;
	private Rigidbody2D m_Rigidbody;
	private Animator m_Animator;

	void Awake() {
		m_SpriteRenderer = GetComponent<SpriteRenderer> ();
		m_Rigidbody = GetComponent<Rigidbody2D> ();
		m_Animator = GetComponent<Animator> ();
	}
		
	// Use this for initialization
	void Start () {
		m_SpriteRenderer.flipX = !m_IsFaceRight;
	}
	
	// Update is called once per frame
	void Update() {
	}

	void FixedUpdate () {
        #if UNITY_STANDALONE
        MoveKeyboard ();
        #endif
        CharacterIsFalling();
    }

	void MoveKeyboard() {
		float forceX = 0f;
		float velocity = Mathf.Abs (m_Rigidbody.velocity.x);

		float directionHorizontal = Input.GetAxisRaw ("Horizontal");

		if (directionHorizontal > 0) {
			if (!m_IsFaceRight)
				TurnFace ();
				
			if (velocity < m_MaxVelocity)
				forceX = m_Speed;

			m_Animator.SetBool ("isRunning", true);
		} else if (directionHorizontal < 0) {
			if (m_IsFaceRight)
				TurnFace ();
				

			if (velocity < m_MaxVelocity)
				forceX = -m_Speed;

			m_Animator.SetBool ("isRunning", true);
		} else {
			m_Animator.SetBool ("isRunning", false);
		}

		m_Rigidbody.AddForce (new Vector2 (forceX, 0));
	}

    void CharacterIsFalling() {
        bool inGround = Physics2D.Linecast(
            transform.position,
            m_GroundVerify.transform.position,
            1 << LayerMask.NameToLayer("Ground"));
        if (!inGround) {
            m_Animator.SetBool("isFall", true);
        } else {
            m_Animator.SetBool("isFall", false);
        }
    }

	public void TurnFace() {
		m_SpriteRenderer.flipX = m_IsFaceRight;
		m_IsFaceRight = !m_IsFaceRight;
	}
}