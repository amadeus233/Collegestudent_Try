using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storyboardinglast : MonoBehaviour
{
    // Start is called before the first frame update
    private bool IsEnter = false;

    public GameObject CineSta;
    public GameObject CineOve;
    public GameObject Tip;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (IsEnter)
        {
            IsEnter = false;
            CineSta.SetActive(true);
            CineOve.SetActive(false);
            Invoke("Show1", 2);
            Invoke("Show2", 5);
            
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
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
    void Show1()
    {
        Tip.SetActive(true);
    }
    void Show2()
    {
        Tip.SetActive(false);
    }
}

