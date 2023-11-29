using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody rb;
    private Vector3 moveDirection;
    public GameObject laserJoueur;

    [SerializeField]
    private Transform cannonPos;

    public float frequenceTire = 0.35f;
    private float frequenceTireLive;
    private bool peutTirer;


    private void Start()
    {
        frequenceTireLive = frequenceTire;
        rb = GetComponent<Rigidbody>();
    }


    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector3 (moveX, moveY, 0).normalized;
       
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed, 0);         

    }

    void Tire()
    {
        frequenceTire += Time.deltaTime;
        if(frequenceTire > frequenceTireLive)
        {
            peutTirer = true;
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            if(peutTirer)
            {
                peutTirer = false;
                frequenceTire = 0f;

                Instantiate(laserJoueur, cannonPos.position, Quaternion.identity);
            }
        }

    }
}
