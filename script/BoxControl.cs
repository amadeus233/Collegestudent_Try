using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxControl : MonoBehaviour
{
    private bool IsEnter=false;

    public GameObject Left;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(IsEnter)
        {
            Left.SetActive(true);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Button.SetActive(true);
        IsEnter = true;
        Debug.Log("Enter");
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        IsEnter = false;
    }
}
