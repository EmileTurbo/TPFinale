using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemiGeneration : MonoBehaviour
{

    public GameObject[] meteorite;
    public GameObject mine;
    public GameObject vaisseauEnnemi;

    public int nbMeteorite = 20;
    public int nbMine = 15;
    public int nbVaisseau = 10;

    public Vector3 spawnValues;

    public float spawnWait;
    public float startWait;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnMeteorite());
    }
    void Update()
    {
        
    }

    IEnumerator SpawnMeteorite()
    {

        yield return new WaitForSeconds(startWait);

        for (int i = 0; i < nbMeteorite; i++)
        {
            Vector3 spawnPosition = new Vector3(spawnValues.x, Random.Range(-spawnValues.y, spawnValues.y), spawnValues.z);
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(meteorite[Random.Range(0,meteorite.Length)], spawnPosition, spawnRotation);
            yield return new WaitForSeconds(spawnWait);
        }

    }
}
