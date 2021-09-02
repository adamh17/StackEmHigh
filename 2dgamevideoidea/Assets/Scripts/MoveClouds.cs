using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MoveClouds : MonoBehaviour
{

    public MakePlankFall mk;
    public void moveClouds()
    {
        transform.localPosition = new Vector3(transform.position.x, transform.position.y + 0.15f, transform.position.z);

        mk.yheight = mk.yheight + 0.15f;
    }
}