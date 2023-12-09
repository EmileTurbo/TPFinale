using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public static int nbMeteoriteDestroyed;
    public static int nbVaisseauDestroyed;

    public TextMeshProUGUI textPoints;
    public TextMeshProUGUI textMaxPoints;
    public TextMeshProUGUI textMeteorite;
    public TextMeshProUGUI textVaisseau;
    public TextMeshProUGUI textTemps;
    public TextMeshProUGUI textGameOver;
    public TextMeshProUGUI textManche;
    public TextMeshProUGUI textNiveau;
    public TextMeshProUGUI countdownText;

    public Button recommencer;
    public Button retourMenu;

    public GameObject Joueur;

    float currentTime = 0f;
    public float startingTime = 30f;




    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        //Mise a jours des scores
        textPoints.text = "Points : " + GestionGame.points + " / " + GestionGame.objectif;
        textMaxPoints.text = "Points Total : " + GestionGame.maxPoints;
        textMeteorite.text = "Météorites détruites : " + nbMeteoriteDestroyed;
        textVaisseau.text = "Vaisseaux détruits : " + nbVaisseauDestroyed;
        textManche.text = "Manche " + GestionGame.manche;
        textNiveau.text = "Niveau " + GestionGame.niveau;
        // Appel de la fonction Timer()
        Timer();

        if (Joueur == null )
        {
            StartCoroutine(GameOver());
        }
    }
    IEnumerator GameOver()
    {
        GestionGame.points = 0;
        currentTime = 0;

        textPoints.gameObject.SetActive(false);
        textMaxPoints.gameObject.SetActive(true);
        textGameOver.gameObject.SetActive(true);
        textMeteorite.gameObject.SetActive(true);
        textVaisseau.gameObject.SetActive(true);
        textTemps.gameObject.SetActive(true);
        recommencer.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        retourMenu.gameObject.SetActive(true);

        
        

    }

    public void RecommencerManche1()
    {
        GestionGame.niveau = 1;
        GestionGame.maxPoints = 0;
        //Recommence la manche 
        SceneManager.LoadScene(GestionGame.manche);
    }

    public void RetourMenu()
    {
        GestionGame.niveau = 1;
        GestionGame.maxPoints = 0;
        //Retourne au menu
        SceneManager.LoadScene(0);
    }

    void Timer()
    {
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString("0");

        if (currentTime <= 0)
        {
            //GameOver si le timer tombe à 0
            StartCoroutine(GameOver());
        }
    }
}
