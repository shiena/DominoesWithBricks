using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public float smoothing = 5.0f;

    private Vector3 targetPos;
    private Vector3 offset;

    private bool stop = false;

    // Use this for initialization
    void Start()
    {
        targetPos = GameObject.Find("StartObj").transform.position;
        offset = transform.position - targetPos;
    }

    // Update is called once per frame
    void Update()
    {
        if (!stop)
        {
            var nextPos = targetPos + offset;
            nextPos.y = transform.position.y;
            transform.position = Vector3.Lerp(transform.position, nextPos, smoothing * Time.deltaTime);
        }
    }

    public void moveCamera(Vector3 pos, bool stop = false)
    {
        targetPos = pos;
        this.stop = stop;
    }
}
