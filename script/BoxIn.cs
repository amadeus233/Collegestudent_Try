using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxIn : MonoBehaviour
{
    private bool IsEnter = false;

    public GameObject left;
    public GameObject right;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(IsEnter)
        {
            left.SetActive(false);
            right.SetActive(false);
            this.gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        IsEnter = true;
    }
}
