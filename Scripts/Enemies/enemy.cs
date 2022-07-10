using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
	public int maxHealth = 100; // Variavel do tipo publica que define a quantidade de vida do enemy.
	public Animator animator; //Cria um animador no Inspector, para inserir uma animação.
	int currentHealth; //Vida currente.

	
	void Start()
	{
		currentHealth = maxHealth; // vida do enemy ao iniciar o jogo.
	}


	public void TakeDamage(int damage)// função para calcular a vida currente, após o ataque do player
	{
		currentHealth -= damage; //A vida currente do inimigo e subtraida pela quantidade de dano.

		animator.SetTrigger("Hurt"); //Faz a animacao começar quando leva dano.
		

		if (currentHealth <= 0) //Se a vida for 0 é chamado para uma função designada de "Die".
		{
			Die();
		}
	}
	
	void Die() //função chamada quando a vida currente é menor ou igual a 0.																			   
	{
		Debug.Log(gameObject.name + " morreu ");
// diz o nome do objeto e a palavra "morreu" para indicar ao programador que a função foi chamada e executada com sucesso.
		animator.SetBool("Dead", true); //a animação de morte do inimigo começa.

		FindObjectOfType<Audio_Manager>().Play("EnemyDeath");
// vai buscar um audio destinado de "EnemyDeath" ao script Audio Manager).		

		GetComponent<Collider2D>().enabled = false; //desabilita a colisão.
		//GetComponentInParent<Enemy_behaviour>().enabled = false;
		this.enabled = false;
		

	}
}


