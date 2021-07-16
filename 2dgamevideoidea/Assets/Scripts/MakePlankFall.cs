using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MakePlankFall : MonoBehaviour
{
    private Rigidbody2D rigidbody22;
    public GameObject plank;
    public Transform spawnPoint;

    public float moveSpeed = 2.0f;
    public int count = 0;

    public MoveCable mcScript;

    Vector3 cableTransform;
    GameObject cable;

    public Move mv;
    public MoveCable mc;
    public MoveClouds mcc;

    float NewObjectWidth;
    float OldObjectWidth;

    private void Start()
    {
        GameObject name = GameObject.Find("Plank of wood");
        cable = GameObject.FindGameObjectWithTag("cable");

        OldObjectWidth = this.transform.localScale.x;
        //print (OldObjectWidth);
        NewObjectWidth = OldObjectWidth * 764 / 1368 * Screen.width / Screen.height;
        //this.transform.localScale.x = NewObjectWidth ;
        print(NewObjectWidth);

    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(2.0f);
        if(name == "Plank of wood")
        {
            rigidbody22 = GetComponent<Rigidbody2D>();
            rigidbody22.gravityScale = 0;
            Instantiate(plank, cableTransform, transform.rotation);
        }
    }

    void Begin()
    {
        StartCoroutine(waiter());
    }

    void Update()
    {

        bool moveRight = mcScript.moveRight;

        cableTransform = new Vector3(cable.transform.position.x, cable.transform.position.y - 1.58f, cable.transform.position.z);

        if (transform.position.y > 1)
        {
            if (moveRight)
            {
                transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
            }
            else
            {
                transform.Translate(-Vector2.right * moveSpeed * Time.deltaTime);
            }

            if (transform.position.x >= 0.5f)
            {
                moveRight = mcScript.moveRight;
            }

            if (transform.position.x <= -0.5f)
            {
                moveRight = mcScript.moveRight;

            }
        }

        if(transform.position.y < -5)
        {
            SceneManager.LoadScene("EndScreen");
        }
        

        //if (Input.touchCount > 0)
        if (Input.GetMouseButtonDown(0))
        {
            rigidbody22 = GetComponent<Rigidbody2D>();
            rigidbody22.gravityScale = 1;
            count += 1;

            if (count == 11)
            {
                mv.moveUp();
                mc.moveCable();
                mcc.moveClouds();
                count = 0;
            }
            Begin();
        }
    }
    public static float GetScreenToWorldHeight
    {
        get
        {
            Vector2 topRightCorner = new Vector2(1, 1);
            Vector2 edgeVector = Camera.main.ViewportToWorldPoint(topRightCorner); var height = edgeVector.y * 2;
            return height;
        }
    }
    public static float GetScreenToWorldWidth
    {
        get
        {
            Vector2 topRightCorner = new Vector2(1, 1);
            Vector2 edgeVector = Camera.main.ViewportToWorldPoint(topRightCorner); var width = edgeVector.x * 2;
            return width;
        }
    }
}
