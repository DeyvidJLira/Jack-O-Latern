using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float m_Speed = 8f;
	public float m_MaxVelocity = 4f;
	public bool m_IsFaceRight = true;

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
		MoveKeyboard ();
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

			m_Animator.SetBool ("isWalking", true);
		} else if (directionHorizontal < 0) {
			if (m_IsFaceRight)
				TurnFace ();
				

			if (velocity < m_MaxVelocity)
				forceX = -m_Speed;

			m_Animator.SetBool ("isWalking", true);
		} else {
			m_Animator.SetBool ("isWalking", false);
		}

		m_Rigidbody.AddForce (new Vector2 (forceX, 0));
	}

	void TurnFace() {
		m_SpriteRenderer.flipX = m_IsFaceRight;
		m_IsFaceRight = !m_IsFaceRight;
	}
}