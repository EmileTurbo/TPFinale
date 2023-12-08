using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 60f;
    public float maxPosX;
    public float minPosX;
    public float maxPosY;
    public float minPosY;
    private Rigidbody rb;
    private Vector3 moveDirection;

    [SerializeField]
    private GameObject laserJoueur;

    [SerializeField]
    private Transform cannonPos;

    public float frequenceTire = 0.35f;
    private float frequenceTireLive;
    private bool peutTirer;

    Transform myTransform;

    public GameObject explosionPlayer;
    public GameObject explosion;


    private void Start()
    {
        myTransform = GetComponent<Transform>();
        frequenceTireLive = frequenceTire;
        rb = GetComponent<Rigidbody>();
    }


    // Update is called once per frame
    void Update()
    {

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
     
        moveDirection = new Vector3 (moveX, moveY, 0).normalized;
       
        // Appel de la fonction Tire()
        Tire();

        myTransform.position = new Vector3(Mathf.Clamp(myTransform.position.x, minPosX, maxPosX), Mathf.Clamp(myTransform.position.y, minPosY, maxPosY),myTransform.position.z);
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed, 0) * Time.deltaTime;         

    }

    //Fonction pour tiré
    void Tire()
    {
        frequenceTire += Time.deltaTime;

        // Vérification du temps entre les tirs
        if(frequenceTire > frequenceTireLive)
        {
            peutTirer = true;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if(peutTirer)
            {
                peutTirer = false;
                // Reset tu délais entre les tirs
                frequenceTire = 0f; 

                //Instancie un laser à la position
                Instantiate(laserJoueur, cannonPos.position, Quaternion.identity);
            }
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Instantiate(explosionPlayer, transform.position, transform.rotation);
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(other.gameObject);
            Destroy(gameObject);
            
        }
    }
}
