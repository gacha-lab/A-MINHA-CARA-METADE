using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour  //nao funciona direito
{
    private Rigidbody2D rb;
    private Animator anim;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
       
    }

                                                                        //public void OnCollisionEnter2D(Collision2D collision) // quando um collider trigger tem colisao com a tag definida,
                                                                        //{                                                       //  destroi o player e volta ao ponto inicial
                                                                        //    if (collision.gameObject.CompareTag("Enemy"))
                                                                        //    {
           
                                                                        //        Die();
                                                                        //    }
                                                                        //}
    public void Die()
    {
   
        FindObjectOfType<Audio_Manager>().Play("PlayerDeath");
        
        rb.bodyType = RigidbodyType2D.Static;
        
        anim.SetTrigger("death");
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
