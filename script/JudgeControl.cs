using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudgeControl : MonoBehaviour
{
    public GameObject Thing;
    public GameObject zhong;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collider2D)
    {
            zhong.SetActive(true);
    }
}
