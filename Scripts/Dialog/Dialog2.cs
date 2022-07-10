using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Dialog2 : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;

    public GameObject continueButton;
    public GameObject continueButtonClear;

    void Start()
    {
        StartCoroutine(Type());
    }

    void Update()
    {
        if(textDisplay.text == sentences[index])
        {
            continueButton.SetActive(true);
            continueButtonClear.SetActive(true);
        }
        
            
        

    }
    IEnumerator Type()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
   
    public void NextSentence()
    {
       

        continueButton.SetActive(false);
        continueButtonClear.SetActive(false);
        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
            FindObjectOfType<Audio_Manager>().Play("Button");
        }
        else
        {
            textDisplay.text = "";
            continueButton.SetActive(false);
        }
    }

    public void ClearThis()
    {
        continueButtonClear.SetActive(false);
        continueButton.SetActive(false);

        if (index < sentences.Length - sentences.Length)   //não precisa deste codiog, pois desabilito o butao de Next
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
            FindObjectOfType<Audio_Manager>().Play("Button");
        }
        else
        {
            textDisplay.text = "";
            continueButtonClear.SetActive(false);
        }
    }
    

    
}
