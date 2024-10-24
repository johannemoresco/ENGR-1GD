using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{

    public void changeScene()
    {
        SceneManager.LoadScene("2D Platformer");
    }
}
