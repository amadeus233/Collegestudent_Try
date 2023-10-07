using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageDrap : MonoBehaviour
{
    Vector2 mousePos;
    Vector2 distance;
   // Rigidbody2D rb2D;

    private void Start()
    {
      //  rb2D = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseDown()
    {
        distance =new Vector2(transform.position.x, transform.position.y) - mousePos;
    }
    private void OnMouseDrag()
    {
        transform.position = mousePos + distance;
    //    rb2D.gravityScale = 0;
     //   rb2D.velocity = Vector2.zero;
    }









}



