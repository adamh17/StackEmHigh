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
    public float yheight = 1.0f;

    public MoveCable mcScript;

    Vector3 cableTransform;
    GameObject cable;

    public Move mv;
    public MoveCable mc;
    public MoveClouds mcc;

    //float NewObjectWidth;
    //float OldObjectWidth;

    public GameManager gameManager;
    public Crossfade cf;

    public float timeBetweenTaps = 1.0f;
    float currentTime;

    AudioSource plankHit;
    int triggerTimes = 0;

    private void Start()
    {
        GameObject name = GameObject.Find("Plank of wood");
        cable = GameObject.FindGameObjectWithTag("cable");

        //OldObjectWidth = this.transform.localScale.x;
        //NewObjectWidth = OldObjectWidth * 764 / 1368 * Screen.width / Screen.height;

        plankHit = GameObject.FindObjectOfType<AudioSource>();
    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(1.0f);
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

        if (transform.position.y > yheight)
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
            gameManager.GameOver();
            cf.transitionLevel();
        }

        currentTime += Time.deltaTime;
        if (Input.GetMouseButtonDown(0) && currentTime >= timeBetweenTaps)
        {

            rigidbody22 = GetComponent<Rigidbody2D>();
            rigidbody22.gravityScale = 1;
            count += 1;

            currentTime = 0.0f;

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(triggerTimes == 0)
        {
            plankHit.Play();
            triggerTimes += 1;
        }
    }
}
