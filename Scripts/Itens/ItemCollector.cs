using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int cherries = 0;
    private int diamonds = 0;
    [SerializeField] private Text CherriesText;
    [SerializeField] private Text DiamondsText;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("cherry"))
        {
            //FindObjectOfType<LifeCount>().AddLife();
            //FindObjectOfType<LifeCount>().AddLife();
            Destroy(collision.gameObject);
            cherries++;
            CherriesText.text = " " + cherries;
            FindObjectOfType<Audio_Manager>().Play("Chearries");
            
        }
            if (collision.gameObject.CompareTag("diamonds"))
            {
                Destroy(collision.gameObject);
                diamonds++;
                DiamondsText.text = " " + diamonds;
                FindObjectOfType<Audio_Manager>().Play("Diamonds");
            }    
    }
}
