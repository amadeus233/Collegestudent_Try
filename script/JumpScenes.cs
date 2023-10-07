using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JumpScenes : MonoBehaviour
{
    private bool IsEnter = false;

    public string str;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(IsEnter)
        {
            Skip();
        }
    }
    public void Skip()
    {
        SceneManager.LoadScene(str);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IsEnter = true;
    }
}
