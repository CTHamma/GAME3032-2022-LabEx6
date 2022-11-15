using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuStateManager : MonoBehaviour
{
    public GameObject MainMenu, Credits;

    private void Awake()
    {
        MainMenu.SetActive(true);
        Credits.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        GameObject MainMenu = GameObject.Find("MainMenu");
        GameObject Credits = GameObject.Find("Credits");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToCredits()
    {
        Credits.SetActive(true);
        MainMenu.SetActive(false);
        Debug.Log("Loading Credits");
    }

    public void GoToMainMenu()
    {
        MainMenu.SetActive(true);
        Credits.SetActive(false);
        Debug.Log("Loading Menu");
    }

    public void NewGame()
    {
        SceneManager.LoadScene(1); // Go to Overworld
        Debug.Log("Let's Play!");
    }

    public void OnApplicationQuit()
    {
        Application.Quit();
        //if (EditorApplication.isPlaying)
        //{
        //    UnityEditor.EditorApplication.isPlaying = false;
        //}
        Debug.Log("Goodbye");
    }
}
