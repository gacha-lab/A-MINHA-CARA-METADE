using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    Rigidbody2D bulletRB;
    GameObject target1;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        bulletRB = GetComponent<Rigidbody2D>();
        //Encontrar o alvo
        target1 = GameObject.FindGameObjectWithTag("Player"); //target 
        //Vetor da velocidade da bala
        Vector2 moveDir = (target1.transform.position - transform.position).normalized * speed;
        //Velocidade a que o rigidbody da bala se dirige
        bulletRB.velocity = new Vector2(moveDir.x, moveDir.y);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player2" || collision.gameObject.tag == "Obstacle" || collision.gameObject.tag == "Default" || collision.gameObject.tag == "Player")   //colisao com a tag ** é direcionada á função destroy
        {
           // FindObjectOfType<Audio_Manager>().Play("Bullet");
            Destroy();

        }
        //if (collision.gameObject.tag == "Obstacle") //colisao com a tag ** é direcionada á função destroy
        //{

        //    Destroy();

        //}
        //if (collision.gameObject.tag == "Default") //colisao com a tag ** é direcionada á função destroy
        //{
        //    Destroy();
        //}
    }

    void Destroy()
    {
        Destroy(this.gameObject,0.5f);  //destroy a bullet
    }

}
