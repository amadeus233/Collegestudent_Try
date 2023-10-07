using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class skip : MonoBehaviour
{
    public void Skip()
    {
        SceneManager.LoadScene("Taoist");
    }
}

