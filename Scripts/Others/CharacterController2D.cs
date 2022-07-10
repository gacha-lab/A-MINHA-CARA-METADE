using UnityEngine;
using UnityEngine.Events;

public class CharacterController2D : MonoBehaviour
{
	[SerializeField] private float m_JumpForce = 400f;                          // Quantidade de força adicionada quando o jogador salta
	[Range(0, 1)] [SerializeField] private float m_CrouchSpeed = .36f;          //Quantidade de maxSpeed ​​aplicada ao movimento quando se abaixa  //1 = 100%
	[Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;  // Suavizar o movimento
	[SerializeField] private bool m_AirControl = false;                         // Movimentar-se no ar 
	[SerializeField] private LayerMask m_WhatIsGround;                          // Ground do player
	[SerializeField] private Transform m_GroundCheck;                           // Verificar o collider acima dele se tiver
	[SerializeField] private Transform m_CeilingCheck;                          // Verificar o collider acima dele se tiver
	[SerializeField] private Collider2D m_CrouchDisableCollider;                // Quando se abaixa o collider é desativado

	const float k_GroundedRadius = .2f; //Raio do círculo de sobreposição
	private bool m_Grounded;            //Verificar se o player está no chao
	const float k_CeilingRadius = .2f; // Verificar se o Player pode ficar em pé
	private Rigidbody2D m_Rigidbody2D;
	private bool m_FacingRight = true;  //o lado que o player esta a olhar
	private Vector3 m_Velocity = Vector3.zero;

	[Header("Events")]
	[Space]

	public UnityEvent OnLandEvent;   //Criacao de 2 eventos

	[System.Serializable]
	public class BoolEvent : UnityEvent<bool> { }

	public BoolEvent OnCrouchEvent;
	private bool m_wasCrouching = false; //1-Evento Crouching

	private void Awake()
	{
		m_Rigidbody2D = GetComponent<Rigidbody2D>();

		if (OnLandEvent == null)
			OnLandEvent = new UnityEvent();

		if (OnCrouchEvent == null)
			OnCrouchEvent = new BoolEvent();
	}

	private void FixedUpdate()
	{
		bool wasGrounded = m_Grounded;
		m_Grounded = false;

		// O Player é aterrado se um circlecast para a posição de groundcheck atingir qualquer coisa designada como ground
		
		Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject)
			{
				m_Grounded = true;
				if (wasGrounded)
					OnLandEvent.Invoke();
			}
		}
	}


	public void Move(float move, bool crouch, bool jump)
	{
		//Verificar se o player se levanta
		if (!crouch)
		{
			//Se tiver um collider acima dele mantei-se abaixado
			if (Physics2D.OverlapCircle(m_CeilingCheck.position, k_CeilingRadius, m_WhatIsGround))
			{
				crouch = true;
			}
		}

		//controlar o player se estiver abaixado ou no ar
		if (m_Grounded || m_AirControl)
		{

			// If crouching
			if (crouch)
			{
				if (!m_wasCrouching)
				{
					m_wasCrouching = true;
					OnCrouchEvent.Invoke(true);
				}

				//reduzir a velociadade de agachar 
				move *= m_CrouchSpeed;

				//Desablita o box.collider se abaixar
				if (m_CrouchDisableCollider != null)
					m_CrouchDisableCollider.enabled = false;
			}
			else
			{
				// Ablita o box.collider quando está em pé
				if (m_CrouchDisableCollider != null)
					m_CrouchDisableCollider.enabled = true;

				if (m_wasCrouching)
				{
					m_wasCrouching = false;
					OnCrouchEvent.Invoke(false);
				}
			}

			// mover o player
			Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
			//Analisar e aplicar no player
			m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

			//Se a entrada estiver movendo o player para a direita e o player estiver voltado para a esquerda
			if (move > 0 && !m_FacingRight)
			{
				// ... flip o player
				Flip();
			}
			//Mover o player para a esquerda enquanto o ele estiver a ir para a direita
			else if (move < 0 && m_FacingRight)
			{
				// ... flip o player
				Flip();
			}
		}
		//Se o player saltar
		if (m_Grounded && jump)
		{
			//Dar uma forca vertical ao player
			m_Grounded = false;
			m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
		}
	}


	private void Flip()
	{
	
		m_FacingRight = !m_FacingRight;

		//Multiplicar escala x do player por -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}