using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class RationControl : MonoBehaviour
{
    private float z = 0;
    private bool IsEnter=false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0)&&IsEnter)
        {
            z += 90;
            transform.rotation = Quaternion.Euler(0, 0, z);
        }
    }
    private void OnMouseEnter()
    {
        IsEnter = true;
    }
    private void OnMouseExit()
    {
        IsEnter = false;
    }
}
