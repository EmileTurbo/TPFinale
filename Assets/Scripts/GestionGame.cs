using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GestionGame : MonoBehaviour
{
    public static int points;
    public static int maxPoints;
    public static int manche = 1;
    public static int niveau = 1;

    public int scoreObjectif1;
    public int scoreObjectif2;
    public int scoreObjectif3;

    public static float spawnWaitMeteorite = 1f;
    public static float spawnWaitMine = 3f;
    public static float spawnWaitVaisseau = 5f;

    public static int objectif;


    // Update is called once per frame
    void Update()
    {
        if(niveau == 1)
        {
            objectif = scoreObjectif1;
            spawnWaitMeteorite = 1.5f;
            spawnWaitMine = 3f;
            spawnWaitVaisseau = 5f;
        }

        if (niveau == 2)
        {
            objectif = scoreObjectif2;
            spawnWaitMeteorite = 1f;
            spawnWaitMine = 2.5f;
            spawnWaitVaisseau = 4f;
        }

        if (niveau == 3)
        {
            objectif = scoreObjectif3;
            spawnWaitMeteorite = 0.75f;
            spawnWaitMine = 2f;
            spawnWaitVaisseau = 3f;
        }

        if (niveau == 4)
        {
            //Augmente la manche et passe a la manche suivante
            niveau = 1;
            manche++;
            SceneManager.LoadScene(manche);
        }

        if (points >= objectif)
        {
            //Augmente le niveau si l'objectif est atteinte
            points = 0;
            niveau++;
            SceneManager.LoadScene(manche);
            
        }
    }
}
