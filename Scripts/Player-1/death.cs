using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class death : MonoBehaviour
{

    [SerializeField] private Transform Respawnpoint1;
    [SerializeField] private Transform Player;
    [SerializeField] private Transform Respawnpoint2;
    [SerializeField] private Transform Player2;


    private void OnTriggerEnter2D (Collider2D die)
    {
        if (die.tag == "Player") ///se o player tocar no collider com tag player ele morre e volta ao ponto inicial
        {
            Debug.Log(die.gameObject.name + " has died");
            Player.transform.position = Respawnpoint1.transform.position;
        }

        if (die.tag == "Player2") ///se o player tocar no collider com tag player ele morre e volta ao ponto inicial
        {
            Debug.Log(die.gameObject.name + " has died");
            Player2.transform.position = Respawnpoint1.transform.position;
        }
    }
}
