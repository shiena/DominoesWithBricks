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

public class ForwardTrigger : MonoBehaviour
{

    public AudioClip audioClip;

    private CameraController camCon;

    private AudioSource audioSource;

    void Start()
    {
        camCon = Camera.main.GetComponent<CameraController>();

        audioSource = gameObject.GetComponent<AudioSource>();
    }

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
        audioSource.PlayOneShot(audioClip);
        camCon.moveCamera(transform.root.position);
        gameObject.GetComponent<Collider>().enabled = false;
    }
}
