using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void SwitchScene()
    {
        SceneManager.LoadScene(0); //Switch back to the overworld scene
    }
}
