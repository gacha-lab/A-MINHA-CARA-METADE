using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
	// variaveis publicas
	public Animator animator; //inicializar um animador
	public Transform Attack_Point;    //inserir um transform de um objeto, neste caso o attack_Point
	public LayerMask enemyLayers;     //layer chamada enemy

	public float AttackRange = 0.8f;   //inicializalas com valores como a area de ataque, dano do ataque, a velocidade do proximo ataque
	public int AttackDamage = 50;
	public float AttackRate = 4f;
	float nextAttackTime = 0f;



	void FixedUpdate()
	{

		if (Time.time >= nextAttackTime)
		{
			if (Input.GetKey(KeyCode.Q)) //quando faz input do botão do teclado para atacar.
			{
				Attack();
				nextAttackTime = Time.time + 1f / AttackRate; //tempo ataque
			}


		}


	}

	void Attack()
	{
		//animacao de ataque 
		animator.SetTrigger("Attack");
		// num circulo onde o epicentro é o attack_poin se houver uma colisão da layer inimigos, deteta-os e passa essa informação para a variável hitenemies

		Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(Attack_Point.position, AttackRange, enemyLayers);  //Formula  para dar hit ao enemys

		foreach (Collider2D Enemy in hitEnemies)
		{
			Enemy.GetComponent<enemy>().TakeDamage(AttackDamage);
		}
		/*Collider2D[] enemyCollider = Physics2D.OverlapCircleAll(Attack_Point.position, AttackRange, enemyLayers);
		foreach (Collider2D Enemy in hitEnemies)
		{
			Enemy.GetComponent<enemy>().TakeDamage(AttackDamage);
		}

		for (int i = 0; i < enemyCollider.Length; i++)
		{
			enemyCollider[i].SendMessage("EnemyHit", -15);
		}


		*/
		void OnDrawGizmosSelected() //Desenha um raio do ataque
		{
			if (Attack_Point == null)
				return;
			Gizmos.DrawWireSphere(Attack_Point.position, AttackRange);
			

		}
		
		foreach(Collider2D enemy in hitEnemies)
        {
			Debug.Log("Deu um hit ao " + enemy.name + ".");
        }
	}
}

