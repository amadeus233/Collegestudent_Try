using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderTrigger : MonoBehaviour
{
    private bool IsEnter = false;
    private Animator anim;
    private bool isOpened;

    public GameObject Thing;
    public GameObject ladder;
    public AudioClip PullRod;//������Ҫ�����������Ծ����Ч
    public AudioSource music;
    public GameObject Left;
    //public GameObject Button;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        isOpened = false;
    }
    private void Awake()
    {
        music = gameObject.AddComponent<AudioSource>();
        PullRod = Resources.Load<AudioClip>("music/PullRod");
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) 
        {
            Destroy(Thing);
            if(IsEnter && !isOpened)
            {
                ladder.SetActive(true);
                anim.SetTrigger("triggering");
                isOpened = true;
                Left.SetActive(false);
                music.clip = PullRod;
                music.Play();
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
}
