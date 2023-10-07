using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnBack : MonoBehaviour
{
    public GameObject MyPlayer;
    public float x;
    public float y;

    private bool IsEnter=false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if(IsEnter)
        {
            MyPlayer.GetComponent<Transform>().position = new Vector2(x, y);
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
