using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform4 : MonoBehaviour
{
    public GameObject MovePlatform;
    public float speed;
    public Transform[] movePos;
    public GameObject Trigger;
    public GameObject Player;
    public GameObject JG;
    public GameObject Exit;

    public GameObject CineSta;
    public GameObject CineOve;
    public GameObject Thing;

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
        if(IsEnter)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                JG.SetActive(true);
                Player.SetActive(false);
                Destroy(Thing);
            }
        }
        if(Open())
        {
            Invoke("Show", 2);
        }
    }
    bool Open()
    {
        if (!Trigger.activeSelf)
        {
            IsOpen = true;
            Player.transform.parent = MovePlatform.gameObject.transform;
            Exit.SetActive(true);
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
    void Show()
    {
        CineSta.SetActive(true);
        CineOve.SetActive(false);
        MovePlatform.transform.position = Vector2.MoveTowards(MovePlatform.transform.position, movePos[i].position, speed * Time.deltaTime);
    }
}
