using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storyboarding2 : MonoBehaviour
{
    private bool IsEnter = false;
    private bool IsStay = false;
    private bool Isopen = true;

    public GameObject CineSta;
    public GameObject CineOve;
    public GameObject Ladder;
    public GameObject Tip;
    public Rigidbody2D Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if (!Ladder.activeInHierarchy)
        {
            if (IsEnter)
            {
                
                CineSta.SetActive(true);
                CineOve.SetActive(false);
            }
            if (Isopen&&IsStay)
            {
                Invoke("Show", 5);
                Isopen = false;
            }
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
    void Show()
    {
        CineSta.SetActive(false);
        CineOve.SetActive(true);
        this.gameObject.SetActive(false);
        Tip.SetActive(false);
        Player.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
}
