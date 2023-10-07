using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveplatform2 : MonoBehaviour
{
    public GameObject MovePlatform;
    public float speed;
    public Transform[] movePos;
    public AudioClip PullRod;//这里我要给主角添加跳跃的音效
    public AudioSource music;
    public GameObject Player;

    public GameObject CineSta;
    public GameObject CineOve;

    public GameObject Thing;

    private Rigidbody2D PR;
    private int i;
    private bool IsEnter = false;
    private bool IsOpen = false;
    private Transform playerDefTransform;
    private Animator anim;
    private bool isOpened = false;
    // Start is called before the first frame update
    void Start()
    {
        PR = Player.GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        i = 1;
        playerDefTransform = GameObject.FindGameObjectWithTag("Player").transform.parent;
    }
    private void Awake()
    {
        music = gameObject.AddComponent<AudioSource>();
        PullRod = Resources.Load<AudioClip>("music/PullRod");
    }
    // Update is called once per frame
    void Update()
    {
        if (IsEnter && !isOpened&&Open())
        {
            anim.SetTrigger("triggering");
            isOpened = true;
            music.clip = PullRod;
            music.Play();
        }
        if (IsEnter&&Open())
        {
            MovePlatform.transform.position = Vector2.MoveTowards(MovePlatform.transform.position, movePos[i].position, speed * Time.deltaTime);
            Invoke("Show", 5.7f);
            
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        IsEnter = true;
    }
    bool Open()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            IsOpen = true;
            CineSta.SetActive(true);
            CineOve.SetActive(false);
            PR.constraints = RigidbodyConstraints2D.FreezeAll;
            Destroy(Thing);
        }
        return IsOpen;
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
        CineOve.SetActive(true);
        CineSta.SetActive(false);
        PR.constraints = RigidbodyConstraints2D.FreezeRotation;
        
    }
}
