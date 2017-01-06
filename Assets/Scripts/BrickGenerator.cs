using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickGenerator : MonoBehaviour
{

    public GameObject brick;

    public Vector3 StartPosition;

    public int Count = 29;

    // Use this for initialization
    void Start()
    {
        for (int index = 0; index < Count; index++)
        {
            Instantiate(brick, StartPosition + Vector3.left * index, Quaternion.identity);
        }
    }
}
