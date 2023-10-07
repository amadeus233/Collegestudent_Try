using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
//using UnityEngine.InputSystem;

public class CharacterController2D : MonoBehaviour
{
    public AudioSource music;
    public AudioClip run;//这里我要给主角添加跳跃的音效
    public float jumpForce = 400f;                          // 弹跳力
    public bool canAirControl = false;                      // 在空中时，是否能控制
    public LayerMask groundMask;
    // 定义哪一个Layer是地面
    public Transform m_GroundCheck;                         // 用于判定地面的空物体
    bool rush;
    private Rigidbody2D myRigidbody;
    public float climbSpeed;
    //爬梯判定
    private BoxCollider2D myFeet; //定义小jio
    private bool isjumpupone;// 起跳的判定

    private bool isLadder;  //攀爬的动画器控制代码————————判定是否梯子
    private bool isClimbing;  // 攀爬的动画器控制代码————攀爬

    const float k_GroundedRadius = .1f; // 用于检测地面的小圆形的半径
    private bool m_Grounded;            // 当前是否在地面上
    private bool m_FacingRight = true;  // 玩家是否面朝右边
    private Vector3 m_Velocity = Vector3.zero;
    private bool panpa; //攀爬逻辑判定
    private Vector2 move;


    const float m_NextGroundCheckLag = 0.1f;    // 起跳后的一小段时间，不能再次起跳。防止连跳的一种解决方案
    float m_NextGroundCheckTime;            // 过了这个时间才可能落地、才能再次起跳
    Animator anim;  //角色动画切换  引用动画组件
    // 这个角色控制器，是依靠刚体驱动的
    private Rigidbody2D m_Rigidbody2D;
    //private PlayerInputActions controls;

    [Header("Events")]
    [Space]

    public UnityEvent OnLandEvent;
    public UnityEvent OnAirEvent;

    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> { }


    void Start()  //启动时实现一次
    {

        anim = GetComponent<Animator>();
        myFeet = GetComponent<BoxCollider2D>();
    }

    private void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();

        if (OnLandEvent == null)
            OnLandEvent = new UnityEvent();
        if (OnAirEvent == null)
            OnAirEvent = new UnityEvent();
        //给对象添加一个AudioSource组件
        music = gameObject.AddComponent<AudioSource>();
        //设置不一开始就播放音效
        music.playOnAwake = false;
        //加载音效文件，我把跳跃的音频文件命名为jump
        run = Resources.Load<AudioClip>("music/run");
    }

    private void FixedUpdate()
    {
        bool wasGrounded = m_Grounded;
        m_Grounded = false;

        // 检测与地面的碰撞
        if (Time.time > m_NextGroundCheckTime)
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, groundMask);
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject != gameObject)
                {
                    m_Grounded = true;
                    if (!wasGrounded)
                        OnLandEvent.Invoke();
                }
            }
        }
        if (wasGrounded && !m_Grounded)
        {

            OnAirEvent.Invoke();
        }
    }


    public void Move(float move, bool jump)
    {
        // 玩家在地面时，或者可以空中控制时，才能移动
        if (m_Grounded || canAirControl)
        {

            // 输入变量move决定横向速度
            m_Rigidbody2D.velocity = new Vector2(move, m_Rigidbody2D.velocity.y);

            // 面朝右时按左键，或面朝左时按右键，都会让角色水平翻转
            if (move > 0 && !m_FacingRight)
            {
                Flip();
            }
            else if (move < 0 && m_FacingRight)
            {
                Flip();
            }
        }

        // 在地面时按下跳跃键，就会跳跃
        if (m_Grounded && jump)
        {
            anim.SetBool("isjumpupone", true);  //尝试
            anim.SetBool("panpa", false);
            OnAirEvent.Invoke();
            m_Grounded = false;
            // 施加弹跳力
            m_Rigidbody2D.AddForce(new Vector2(0f, jumpForce));
            m_NextGroundCheckTime = Time.time + m_NextGroundCheckLag;
        }
    }

    void Update()
    {
        Climb();
        CheckLadder();
        if (Input.GetKey(KeyCode.D))
        {
            
            anim.SetBool("rush", true);
            anim.SetBool("panpa", false); ;
        }
        else anim.SetBool("rush", false); ;

        //  if (Input.GetKey(KeyCode.D))
        if(m_Grounded)
        {
            anim.SetBool("isjumpupone", false);

        }
        if ((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A)) && m_Grounded)//如果输入↑
        {
            //把音源music的音效设置为jump
            music.clip = run;
            //播放音效
            music.Play();
        }
        if (!Input.anyKey && music.isPlaying) //没有任何键按下并且声音是播放状态
        {
            music.Stop(); //停止播放声音
        }
    }
    //if (Input.GetKey(KeyCode.W))
    //  {
    //       anim.SetBool("panpa", true);
    void Climb()
    {

        float moveY = Input.GetAxis("Vertical");
        if (panpa)
        {
            m_Rigidbody2D.AddForce(new Vector2(0f, 40));
            m_NextGroundCheckTime = Time.time + m_NextGroundCheckLag;
            panpa = true;
            //myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, moveY * climbSpeed);

        }
        if (isLadder)
        {
            anim.SetBool("panpa", false); ;
            if (Input.GetKey(KeyCode.W))
            {
                anim.SetBool("panpa", true);
                // Vector2 playerVelocity = new Vector2(move.y * 10, myRigidbody.velocity.y);
                //  myRigidbody.velocity = playerVelocity;
                // myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, moveY * climbSpeed);
                m_Rigidbody2D.AddForce(new Vector2(0f, 3.5f));

                m_NextGroundCheckTime = Time.time + m_NextGroundCheckLag;

            }
            else anim.SetBool("panpa", false); ;
        }
    }
    private void Flip()
    {

        // true变false，false变true
        m_FacingRight = !m_FacingRight;

        // 缩放的x轴乘以-1，图片就水平翻转了
        transform.localScale = Vector3.Scale(transform.localScale, new Vector3(-1, 1, 1));
    }
    void CheckLadder()  //爬梯代码模块
    {

        isLadder = myFeet.IsTouchingLayers(LayerMask.GetMask("Ladder"));//  判定ladder

    }
    //音源AudioSource相当于播放器，而音效AudioClip相当于磁带
}
