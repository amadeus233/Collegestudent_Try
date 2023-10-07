using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearControl : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Poem;
    public GameObject Player;
    public GameObject HighLight;


    private bool IsEnter=false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(IsEnter)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                Poem.SetActive(true);
                Player.SetActive(false);
            }
        }
        if(Poem.activeSelf)
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
                Poem.SetActive(false);
                Player.SetActive(true);
                HighLight.SetActive(false);
            }
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
