using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickCheck4 : MonoBehaviour
{
    private bool IsEnter = false;

    public GameObject Di;
    public GameObject Shi;
    public GameObject Nong;
    public GameObject Shan;

    public GameObject Back1;
    public GameObject Back2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (IsEnter && Di.activeSelf && Shi.activeSelf && Nong.activeSelf && !Shan.activeSelf)
            {
                Back1.SetActive(true);
                Back2.SetActive(true);
            }
        }
    }
    private void OnMouseEnter()
    {
        IsEnter = true;
        Debug.Log("Enter");
    }
    private void OnMouseExit()
    {
        IsEnter = false;
        Debug.Log("Exit");
    }
}
