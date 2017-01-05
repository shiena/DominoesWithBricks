using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public float force = -50f;

    private Button[] buttons;

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
