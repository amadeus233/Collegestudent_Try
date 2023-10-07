using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform5 : MonoBehaviour
{
    public GameObject MovePlatform;
    public float speed;
    public Transform[] movePos;
    public GameObject Trigger;
    public GameObject Player;

    private bool IsEnter = false;
    private int i;
    private bool IsOpen = false;
    private Transform playerDefTransform;
    // Start is called before the first frame update
    void Start()
    {
        i = 1;
        playerDefTransform = GameObject.FindGameObjectWithTag("Player").transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
      
        if (Open())
        {
            Invoke("Show", 2);
        }
    }
    bool Open()
    {
        if (!Trigger.activeSelf)
        {
            IsOpen = true;
        }
        return IsOpen;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IsEnter = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        IsEnter = false;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        
        Player.transform.parent = MovePlatform.gameObject.transform;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.transform.parent = playerDefTransform;
        }
    }
    void Show()
    {
        MovePlatform.transform.position = Vector2.MoveTowards(MovePlatform.transform.position, movePos[i].position, speed * Time.deltaTime);
    }
}
