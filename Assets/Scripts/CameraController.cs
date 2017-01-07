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

public class CameraController : MonoBehaviour
{

    public float smoothing = 0.1f;

    private Vector3 targetPos;
    private Vector3 offset;

    private bool stop = false;

    private Vector3 velocity = Vector3.zero;

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
            transform.position = Vector3.SmoothDamp(transform.position, nextPos, ref velocity, smoothing);
        }
    }

    public void moveCamera(Vector3 pos, bool stop = false)
    {
        targetPos = pos;
        this.stop = stop;
    }
}
