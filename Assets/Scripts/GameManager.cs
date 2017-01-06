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
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public float force = -50f;

    private Button[] buttons;

    void Awake()
    {
        GetComponent<BrickGenerator>().GenerateBricks();
    }

    // Use this for initialization
    void Start()
    {
        var StartObj = GameObject.Find("StartObj/Ita");
        StartObj.GetComponent<Rigidbody>().AddForce(new Vector3(force, 0f, 0f));

        buttons = GameObject.Find("Canvas").GetComponentsInChildren<Button>(true);
        foreach (var b in buttons)
        {
            b.gameObject.SetActive(false);
        }
    }

    public void EnableButton()
    {
        foreach (var b in buttons)
        {
            b.gameObject.SetActive(true);
        }
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene("GameScene");
    }
}
