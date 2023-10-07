using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GossipArrayControl : MonoBehaviour
{
    public GameObject BgOut;
    public GameObject BgIn;
    public GameObject MyPoint;
    public AudioClip GossipArray;//这里我要给主角添加跳跃的音效
    public AudioSource music;
    public GameObject CinSta;
    public GameObject CinOve;
    public GameObject Tip;
    public Rigidbody2D Player;
    public GameObject Triggering;

    private Transform OutSide;
    private Transform InSide;
    private Transform Point;
    private bool IsEnter=false;
    private bool IsOpened = true;
    // Start is called before the first frame update
    void Start()
    {
        OutSide = BgOut.GetComponent<Transform>();
        InSide = BgIn.GetComponent<Transform>();
        Point = MyPoint.GetComponent<Transform>();
    }
    private void Awake()
    {
        music = gameObject.AddComponent<AudioSource>();
        GossipArray = Resources.Load<AudioClip>("music/GossipArray");
    }
    // Update is called once per frame
    void Update()
    {
        MoveControl();
       // if (IsOpened)
        {
            if (CheckAngle(OutSide.transform.localEulerAngles.z) && CheckAngle(InSide.transform.localEulerAngles.z))
            {
                Tip.SetActive(false);
                CinSta.SetActive(false);
                CinOve.SetActive(true);
                Player.constraints = RigidbodyConstraints2D.FreezeRotation;
                Triggering.SetActive(false);
                IsOpened = false;
                
            }
        }
    }
    void MoveControl()
    {
        if (!CheckAngle(InSide.transform.localEulerAngles.z)&&IsEnter)
        {
            if (Input.GetKey(KeyCode.W))
            {
                InSide.RotateAround(Point.position, Vector3.forward, -0.25f);
                //OutSide.RotateAround(Point.position, Vector3.forward, 0.1f);
                   // music.clip = GossipArray;
                    //播放音效
                   // music.Play();
            }
            if (Input.GetKey(KeyCode.S))
            {
                InSide.RotateAround(Point.position, Vector3.back, -0.25f);
              //  OutSide.RotateAround(Point.position, Vector3.back, 0.1f);
                  // music.clip = GossipArray;
                    //播放音效
                  // music.Play();
            }
           /* if (!Input.anyKey && music.isPlaying) //没有任何键按下并且声音是播放状态
            {
                music.Stop(); //停止播放声音
            }*/
        }
        if (!CheckAngle(OutSide.transform.localEulerAngles.z)&&IsEnter)
        {
            if (Input.GetKey(KeyCode.Q))
            {
                OutSide.RotateAround(Point.position, Vector3.forward, -0.3f);
                //InSide.RotateAround(Point.position, Vector3.forward, 0.1f);
                  // music.clip = GossipArray;
                    //播放音效
                   // music.Play();

            }
            if (Input.GetKey(KeyCode.E))
            {
                OutSide.RotateAround(Point.position, Vector3.back, -0.3f);
                ///InSide.RotateAround(Point.position, Vector3.back, 0.1f);
                    //music.clip = GossipArray;
                    //播放音效
                 //  music.Play();
            }
           /* if (!Input.anyKey && music.isPlaying) //没有任何键按下并且声音是播放状态
            {
                music.Stop(); //停止播放声音
            }*/
        }

    }
    public bool CheckAngle(float angle)
    {
        if (angle > 360)
            angle = angle % 360;
        if (angle < -360)
            angle = (angle * -1) % 360;
        if (angle < 5.0f && angle > -0.5f)
            return true;
        else
            return false;
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
