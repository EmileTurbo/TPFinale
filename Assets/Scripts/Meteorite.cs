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
        Move();
    }

    // Fonction qui destroy la météorite
    void DeactivateGameObject()
    {
        gameObject.SetActive(false);
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "LaserJoueur")
        {
            UI.points = UI.points + 10;
            UI.nbMeteoriteDestroyed = UI.nbMeteoriteDestroyed + 1;
            Instantiate(explosion, transform.position, transform.rotation);
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
