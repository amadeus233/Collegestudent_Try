using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform3 : MonoBehaviour
{
    public float speed;
    public Transform[] movePos;
    public GameObject TheMiddle;

    private int i;
    // Start is called before the first frame update
    void Start()
    {
        i = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(!TheMiddle.activeSelf)
        {
            Debug.Log("false");
            transform.position = Vector2.MoveTowards(transform.position, movePos[i].position, speed * Time.deltaTime);
        }

    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.transform.parent = gameObject.transform;
        }
    }
}
