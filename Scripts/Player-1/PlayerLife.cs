using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    public float damageTimeout = 0.1f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
        }
        //if (collision.gameObject.CompareTag("Enemy"))
        //{
        //    FindObjectOfType<LifeCount>().LoseLife();

        //}

        //if (collision.gameObject.CompareTag("Enemy"))
        //{
        //    FindObjectOfType<LifeCount2>().LoseLife2();
        //}
    }
    private void Die()
    {
        FindObjectOfType<Audio_Manager>().Play("PlayerDeath");
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
        // saída do jogo com mensagem ou coisa assim
    }

    private void RestartLevel()
    {
       // SceneManager.LoadScene(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}