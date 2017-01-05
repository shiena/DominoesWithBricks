using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public float force = -50f;

    private GameObject canvas;

    // Use this for initialization
    void Start()
    {
        var StartObj = GameObject.Find("StartObj/Ita");
        StartObj.GetComponent<Rigidbody>().AddForce(new Vector3(force, 0f, 0f));

        canvas = GameObject.Find("Canvas");
        var buttons = canvas.GetComponentsInChildren<Button>(true);
        foreach (var b in buttons)
        {
            b.gameObject.SetActive(false);
        }
    }

    public void EnableButton()
    {
        var buttons = canvas.GetComponentsInChildren<Button>(true);
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
