using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Playbutton : MonoBehaviour
{
    public GameObject bg;
    public void clicked()
    {
        bg.SetActive(true);
        Invoke("startnext", .5f);
    }
    void startnext()
    {
        SceneManager.LoadScene(1);
    }
}
