using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnCin : MonoBehaviour
{
    private bool IsEnter = false;

    public GameObject CineSta;
    public GameObject CineOve;
    public GameObject TheTrigger;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (IsEnter)
        {
            CineSta.SetActive(true);
            CineOve.SetActive(false);
            TheTrigger.SetActive(true);
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

    }
}
