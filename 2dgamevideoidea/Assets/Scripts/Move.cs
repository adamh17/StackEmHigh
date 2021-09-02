using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public void moveUp()
    {
        transform.localPosition = new Vector3(transform.position.x, transform.position.y + 0.15f, transform.position.z);
    }
}
