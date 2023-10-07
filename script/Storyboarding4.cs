using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storyboarding4 : MonoBehaviour
{
    private bool IsEnter = false;

    public GameObject CineSta;
    public GameObject CineOve;
    public GameObject TheLast;

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
            TheLast.SetActive(true);
            
            this.gameObject.SetActive(false);
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