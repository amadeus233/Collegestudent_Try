using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenAnimation : MonoBehaviour
{
    private bool IsEnter=false;
    private bool IsOpen = false;
    private Animator anim;

    public GameObject di;
    public GameObject shi;
    public GameObject nong;
    public GameObject gong;
    public GameObject shang;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(shi.activeSelf&&di.activeSelf&&nong.activeSelf&&gong.activeSelf&&shang.activeSelf)
        {
            if(!IsOpen)
            {
                anim.SetTrigger("Triggering");
                Invoke("Show", 1);
                IsOpen = true;
            }
        }
    }

    void Show()
    {
        this.transform.GetComponent<BoxCollider2D>().enabled = false;
    }

}
