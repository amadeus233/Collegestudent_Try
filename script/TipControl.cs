using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipControl : MonoBehaviour
{
    private bool IsEnter = false;

    public GameObject Tip;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(IsEnter)
        {
            Tip.SetActive(true);
        }
        if(!IsEnter)
        {
            Tip.SetActive(false);
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
        //Button.SetActive(false);
        IsEnter = false;
        Debug.Log("Exit");
    }
}
