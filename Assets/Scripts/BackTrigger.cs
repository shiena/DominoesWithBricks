/*
 * Copyright 2017 Mitsuhiro Koga
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

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

    void Start()
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
