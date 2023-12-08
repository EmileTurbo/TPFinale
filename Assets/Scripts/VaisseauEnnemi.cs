using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VaisseauEnnemi : MonoBehaviour
{
    public float speed = -8f;
    public float destroyTimer = 20f;
    public GameObject explosion;
    
    [SerializeField]
    private GameObject laserEnnemi;

    [SerializeField]
    private Transform cannonPos;
    [SerializeField]
    private Transform cannonPos2;

    public float frequenceTire = 0.35f;
    private float frequenceTireLive;
    private bool peutTirer;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DeactivateGameObject", destroyTimer);
        frequenceTireLive = frequenceTire;
    }

    // Update is called once per frame
    void Update()
    {
        // Appel de la fonction Move()
        Move();
        // Appel de la fonction Tire()
        Tire();
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
            UI.points = UI.points + 30;
            UI.nbVaisseauDestroyed = UI.nbVaisseauDestroyed + 1;
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

    void Tire()
    {
        frequenceTire += Time.deltaTime;

        // Vérification du temps entre les tirs
        if (frequenceTire > frequenceTireLive)
        {
            peutTirer = true;
        }

        if (peutTirer)
        {
            peutTirer = false;
            // Reset tu délais entre les tirs
            frequenceTire = 0f;

            //Instancie un laser à la position
            Instantiate(laserEnnemi, cannonPos.position, Quaternion.identity);
            //Instancie un laser à la position
            Instantiate(laserEnnemi, cannonPos2.position, Quaternion.identity);

        }

    }

}
