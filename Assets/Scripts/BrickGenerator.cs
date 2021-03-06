﻿/*
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

public class BrickGenerator : MonoBehaviour
{

    public GameObject brick;

    public GameObject StartPosition;

    public int Count = 30;

    private Vector3 initialPositionOffset = new Vector3(0.005f, 0, 0);

    public void GenerateBricks()
    {
        var startPos = StartPosition.transform.position;
        var initialPosition = startPos + initialPositionOffset;
        GameObject StartObj = Instantiate(brick, initialPosition, Quaternion.identity);
        StartObj.name = "StartObj";

        for (int index = 1; index < Count; index++)
        {
            Instantiate(brick, startPos + Vector3.left * index, Quaternion.identity);
        }
    }
}
