using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public void LoadSceneOnClick(int SceneIndex)
    {
        SceneManager.LoadScene(SceneIndex);
    }
    //Makes it so that the next scene is loaded after the button is pressed when the script is attached to the button

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}


