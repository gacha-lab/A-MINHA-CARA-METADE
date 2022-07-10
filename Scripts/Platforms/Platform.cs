using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{

    [SerializeField] private Transform Player1;
    [SerializeField] private Transform Player2;
    private void OnTriggerEnter2D(Collider2D collision) // Quando á uma colisao o player1 passa a ser Parent do objeto colidido.
    {
        if (collision.CompareTag("Player"))
        {
            Player1.parent = gameObject.transform;
            FindObjectOfType<Audio_Manager>().Play("Platform");
            Debug.Log("Test A");
        }

        if (collision.CompareTag("Player2"))
        {
            Player2.parent = gameObject.transform;
            FindObjectOfType<Audio_Manager>().Play("Platform");
            Debug.Log("Test B");
        }
        



    }
    private void OnTriggerExit2D(Collider2D collision) //se nao houver mais colisao passa a nao ser Parent
    {
        Player1.parent = null;
        Player2.parent = null;
    }
}
