using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemiGeneration : MonoBehaviour
{

    public GameObject[] meteorite;
    public GameObject mine;
    public GameObject vaisseauEnnemi;

    public int nbMeteorite;
    public int nbMine;
    public int nbVaisseau;

    public Vector3 spawnValues;

    public float startWait;

    public GameObject joueur;

    
    
  

    // Start is called before the first frame update
    void Start()
    {
        //Appel de fonctions qui font apparetre les obstacles
        StartCoroutine(SpawnMeteorite());
        StartCoroutine(SpawnMine());
        StartCoroutine(SpawnVaisseau());
    }
    void Update()
    {
        
    }

    IEnumerator SpawnMeteorite()
    {
        yield return new WaitForSeconds(startWait);

        do
        {
            for (int i = 0; i < nbMeteorite; i++)
            {
                Vector3 spawnPosition = new Vector3(spawnValues.x, Random.Range(-spawnValues.y, spawnValues.y), spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                //Instancie une météorite
                Instantiate(meteorite[Random.Range(0, meteorite.Length)], spawnPosition, spawnRotation);
            }
            yield return new WaitForSeconds(GestionGame.spawnWaitMeteorite);

        } while (joueur != null);

    }

    IEnumerator SpawnMine()
    {

        yield return new WaitForSeconds(startWait);

        do
        {
            for (int i = 0; i < nbMine; i++)
            {
                Vector3 spawnPosition = new Vector3(spawnValues.x, Random.Range(-spawnValues.y, spawnValues.y), spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                //Instancie une mine
                Instantiate(mine, spawnPosition, spawnRotation);
            }
            yield return new WaitForSeconds(GestionGame.spawnWaitMine);

        } while (joueur != null);

    }

    IEnumerator SpawnVaisseau()
    {

        yield return new WaitForSeconds(startWait);

        do
        {
            for (int i = 0; i < nbVaisseau; i++)
            {
                Vector3 spawnPosition = new Vector3(spawnValues.x, Random.Range(-spawnValues.y, spawnValues.y), spawnValues.z);
                Quaternion spawnRotation = Quaternion.Euler(0, 270, 90);
                //Instancie un vaisseau
                Instantiate(vaisseauEnnemi, spawnPosition, spawnRotation);
            }

            yield return new WaitForSeconds(GestionGame.spawnWaitVaisseau);

        } while (joueur != null);

    }

}
