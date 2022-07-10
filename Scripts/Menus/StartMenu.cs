using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    [SerializeField] GameObject Start;
    [SerializeField] GameObject Loading;

    public void StartGame()
    {
        Start.SetActive(false);
        Loading.SetActive(true);
        SceneManager.LoadScene(2);/*SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);*/
    }
}