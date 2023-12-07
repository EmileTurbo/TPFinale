using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class UI : MonoBehaviour
{
    public static int points;
    public static int nbMeteoriteDestroyed;
    public static int nbVaisseauDestroyed;
    public TextMeshProUGUI textPoints;
    public TextMeshProUGUI textMeteorite;
    public TextMeshProUGUI textVaisseau;
    public TextMeshProUGUI textTemps;
    public TextMeshProUGUI textGameOver;

    public GameObject Joueur;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        textPoints.text = "Points : " + points;
        textMeteorite.text = "Météorites détruites : " + nbMeteoriteDestroyed;
        textMeteorite.text = "Vaisseaux détruits : " + nbVaisseauDestroyed;

        if (Joueur == null )
        {
            textGameOver.gameObject.SetActive(true);
            textMeteorite.gameObject.SetActive(true);
            textVaisseau.gameObject.SetActive(true);
            textTemps.gameObject.SetActive(true);
        }
    }
}
