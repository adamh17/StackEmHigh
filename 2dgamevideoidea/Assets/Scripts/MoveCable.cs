using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCable : MonoBehaviour
{

    public float moveSpeed = 2.0f;
    public bool moveRight = true;

    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (moveRight)
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(-Vector2.right * moveSpeed * Time.deltaTime);
        }

        if (transform.position.x >= 1.4f)
        {
            moveRight = false;
        }

        if (transform.position.x <= -1.4f)
        {
            moveRight = true;
        }
    }

    public void moveCable()
    {
        transform.localPosition = new Vector3(transform.position.x, transform.position.y + 0.2f, transform.position.z);
    }
}
