using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakePlankFall : MonoBehaviour
{
    private Rigidbody2D rigidbody22;

    public GameObject plank;
    public Transform spawnPoint;

    public float moveSpeed = 2.0f;
    public bool moveRight = true;

    private void Start()
    {
        GameObject name = GameObject.Find("Plank of wood");
    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(2.0f);
        if(name == "Plank of wood")
        {
            rigidbody22 = GetComponent<Rigidbody2D>();
            rigidbody22.gravityScale = 0;
            Instantiate(plank, spawnPoint.position, transform.rotation);
        }
    }

    void Begin()
    {
        StartCoroutine(waiter());
    }

    void Update()
    {
        if(name.Contains("Plank of wood (1)"))
        {
            if (moveRight)
            {
                transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
            }
            else
            {
                transform.Translate(-Vector2.right * moveSpeed * Time.deltaTime);
            }

            if (transform.position.x >= 1.7f)
            {
                moveRight = false;
            }

            if (transform.position.x <= -1.7f)
            {
                moveRight = true;
            }
        }
        

        //if (Input.touchCount > 0)
        if (Input.GetMouseButtonDown(0))
        {

            rigidbody22 = GetComponent<Rigidbody2D>();
            rigidbody22.gravityScale = 1;
            Begin();
        }
    }
}
