using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardTrigger : MonoBehaviour
{

    private GameObject root;

    private bool pushed = false;

    private CameraController camCon;

    void Awake()
    {
        var parents = gameObject.GetComponentsInParent(typeof(Transform));
        root = parents[parents.Length - 1].gameObject;

        camCon = Camera.main.GetComponent<CameraController>();
    }

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
        if (!pushed)
        {
            camCon.moveCamera(root.transform.position);
            pushed = !pushed;
        }
    }
}
