using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Meteorite : MonoBehaviour
{
    public float speed = -8f;
    public float destroyTimer = 10f;
    public GameObject explosion;
    

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DeactivateGameObject", destroyTimer);
    }

    // Update is called once per frame
    void Update()
    {
        // Appel de la fonction Move()
        Move();
    }

    // Fonction qui destroy la météorite
    void DeactivateGameObject()
    {
        //Destroy la météorite quand elle est hors jeux
        gameObject.SetActive(false);
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "LaserJoueur")
        {
            //Ajoute des points
            GestionGame.points = GestionGame.points + 10;
            GestionGame.maxPoints = GestionGame.maxPoints + 10;
            //Ajoute au compteur de météorites détruites
            UI.nbMeteoriteDestroyed = UI.nbMeteoriteDestroyed + 1;
            //Instantie une explosion
            Instantiate(explosion, transform.position, transform.rotation);
            //Destroy le laser et la météorite
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

    void Move()
    {
        Vector3 temp = transform.position;
        temp.x += speed * Time.deltaTime;
        transform.position = temp;
    }
}
