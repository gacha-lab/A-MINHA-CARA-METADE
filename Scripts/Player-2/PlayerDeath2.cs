using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerDeath2 : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private void Start()

    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }
   
    public void Die2()
    {

        FindObjectOfType<Audio_Manager>().Play("PlayerDeath");

        rb.bodyType = RigidbodyType2D.Static;

        anim.SetTrigger("death2");
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}


