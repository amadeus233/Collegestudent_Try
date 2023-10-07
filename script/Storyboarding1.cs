using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storyboarding1 : MonoBehaviour
{
    private bool IsEnter = false;
    private bool IsStay = false;

    public GameObject CineSta;
    public GameObject CineOve;
    public Rigidbody2D Player;
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
        }
        if (IsStay)
        {
            Player.constraints = RigidbodyConstraints2D.FreezeAll;
            Invoke("Show2", 5);
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
    private void OnTriggerStay2D(Collider2D collision)
    {
        IsStay = true;
    }
    void Show2()
    {
        CineSta.SetActive(false);
        CineOve.SetActive(true);
        this.gameObject.SetActive(false);
        Player.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
}
