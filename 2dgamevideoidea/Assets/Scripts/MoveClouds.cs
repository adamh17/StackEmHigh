using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveClouds : MonoBehaviour
{
    public void moveClouds()
    {
        transform.localPosition = new Vector3(transform.position.x, transform.position.y + 0.2f, transform.position.z);
    }
}