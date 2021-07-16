using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    void Start()
    {
        //3:4 aspect ratio
        //if (Camera.main.aspect >= 0.75)
          //  Camera.main.orthographicSize = 6.6f;

        // 10:16 aspect ratio
        //else if (Camera.main.aspect >= 0.62)
          //  Camera.main.orthographicSize = 7.1f;

        //else if (Camera.main.aspect >= 0.62)
          //  Camera.main.orthographicSize = 10.0f;
    }

    // Update is called once per frame
    public void moveUp()
    {
        transform.localPosition = new Vector3(transform.position.x, transform.position.y + 0.2f, transform.position.z);
    }
}
