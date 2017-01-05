using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackTrigger : MonoBehaviour
{

    public float speed = 5.5f;

    public AudioClip audioClip;

    private GameObject root;

    private bool pushed = false;

    private CameraController camCon;

    private GameManager gameManager;

    private AudioSource audioSource;

    void Awake()
    {
        var parents = gameObject.GetComponentsInParent(typeof(Transform));
        root = parents[parents.Length - 1].gameObject;

        camCon = Camera.main.GetComponent<CameraController>();

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        audioSource = gameObject.GetComponent<AudioSource>();
    }

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
        if (!pushed)
        {
            audioSource.PlayOneShot(audioClip);
            var stop = root.name == "StartObj";
            camCon.moveCamera(root.transform.position + Vector3.right * speed, stop);
            if (stop)
            {
                gameManager.EnableButton();
            }
            pushed = !pushed;
        }
    }
}
