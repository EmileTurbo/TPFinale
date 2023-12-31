using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float speed = 10f;
    public float destroyTimer = 4f;

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

    // Fonction qui fait bouger le laser
    void Move()
    {
        Vector3 temp = transform.position;
        temp.x += speed * Time.deltaTime;
        transform.position = temp;
    }

    // Fonction qui destroy le laser
    void DeactivateGameObject()
    {
        gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
