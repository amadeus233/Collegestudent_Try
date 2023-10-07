using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EAppear : MonoBehaviour
{
    public GameObject Thing;

    private bool IsEnter = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)&&IsEnter)
            {
            Thing.SetActive(true);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IsEnter = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        IsEnter = false;
    }
}
