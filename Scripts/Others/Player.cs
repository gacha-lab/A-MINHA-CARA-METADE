using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{

	public int maxHealth = 100; //Definir vida do player
	public int currentHealth;   //Vida do player

	public HealthBar healthBar;

	
	void Start()
	{
		currentHealth = maxHealth;  //vida do player 
		healthBar.SetMaxHealth(maxHealth);
	}

	
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space)) 
		{
			TakeDamage(20);//dar dano o player
		}
	}


	void TakeDamage(int damage)
	{
		currentHealth -= damage;//Vida definida - a quantidade tirada

		healthBar.SetHealth(currentHealth); //amostrar na barra de vida

		if (currentHealth <= 0) //se a vida chegar a 0, volta ao ponto de inicio
        {
			LevelManager.instance.Respawn();
		}
	}
}
