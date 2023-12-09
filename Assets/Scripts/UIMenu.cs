using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMenu : MonoBehaviour
{
    public TextMeshProUGUI textManche;

    // Update is called once per frame
    void Update()
    {
        textManche.text = "Manche choisis : " + GestionGame.manche;
    }

    public void clickManche1()
    {
        GestionGame.manche = 1;
    }
    public void clickManche2()
    {
        GestionGame.manche = 2;
    }
    public void clickManche3()
    {
        GestionGame.manche = 3;
    }
    public void clickManche4()
    {
        GestionGame.manche = 4;
    }

    public void Commencer()
    {
        //Charge la manche demandée
        SceneManager.LoadScene(GestionGame.manche);
    }

    public void quitter()
    {
        //Quitte l'application
        Application.Quit();
    }
}
