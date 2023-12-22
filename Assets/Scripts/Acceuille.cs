using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Acceuille : MonoBehaviour
{
    public void ecranMenu()
    {
        SceneManager.LoadScene(1);
    }

    public void quitter()
    {
        Application.Quit();
    }
}
