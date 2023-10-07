using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenThedoor : MonoBehaviour
{
    public GameObject JG;
    public GameObject J1;
    public GameObject J2;
    public GameObject J3;
    public GameObject J4;
    public GameObject J5;
    public GameObject J6;
    public GameObject J7;
    public GameObject J8;
    public GameObject J9;
    public GameObject Player;
    public GameObject AirWall;
    public GameObject MovePlatform;
    public Transform[] movePos;
    public float speed;

    public GameObject CineSta;
    public GameObject CineOve;
    public GameObject Thing;

    private Rigidbody2D PR;

    private bool open = true;
    private Transform K1;
    private Transform K2;
    private Transform K3;
    private Transform K4;
    private Transform K5;
    private Transform K6;
    private Transform K7;
    private Transform K8;
    private Transform K9;
    private bool IsEnter;
    private bool IsOpened=true;
    private int i;
   
    // Start is called before the first frame update
    void Start()
    {
        PR = Player.GetComponent<Rigidbody2D>();
        i = 1;
        K1 = J1.GetComponent<Transform>();
        K2 = J2.GetComponent<Transform>();
        K3 = J3.GetComponent<Transform>();
        K4 = J4.GetComponent<Transform>();
        K5 = J5.GetComponent<Transform>();
        K6 = J6.GetComponent<Transform>();
        K7 = J7.GetComponent<Transform>();
        K8 = J8.GetComponent<Transform>();
        K9 = J9.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(IsEnter&&Input.GetKeyDown(KeyCode.E)&&IsOpened)
        {
            JG.SetActive(true);
            Player.SetActive(false);
            IsOpened = false;
            Destroy(Thing);
        }
       // if(Input.GetKeyDown(KeyCode.F))
        if(CheckAngle(K1.transform.localEulerAngles.z)&& CheckAngle(K2.transform.localEulerAngles.z) && CheckAngle(K3.transform.localEulerAngles.z) && CheckAngle(K4.transform.localEulerAngles.z) && CheckAngle(K5.transform.localEulerAngles.z) && CheckAngle(K6.transform.localEulerAngles.z) && CheckAngle(K7.transform.localEulerAngles.z) && CheckAngle(K8.transform.localEulerAngles.z) && CheckAngle(K9.transform.localEulerAngles.z))
        {
            if (open)
            {
                Invoke("Show1", 1);
                MovePlatform.transform.position = Vector2.MoveTowards(MovePlatform.transform.position, movePos[i].position, speed * Time.deltaTime);
                Invoke("Show2", 7);
                open = false;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IsEnter = true;
        Debug.Log("Enter");
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        IsEnter = false;
        Debug.Log("Exit");
    }
    public bool CheckAngle(float angle)
    {
        if (angle > 360)
            angle = angle % 360;
        if (angle < -360)
            angle = (angle * -1) % 360;
        if (angle>-0.5f&&angle<0.5f)
            return true;
        else
            return false;
    }
    void Show1()
    {
        
        PR.constraints = RigidbodyConstraints2D.FreezeAll;
        CineSta.SetActive(true);
        CineOve.SetActive(false);
        JG.SetActive(false);
        Player.SetActive(true);
        AirWall.SetActive(false);
       
        
    }
    void Show2()
    {
        PR.constraints = RigidbodyConstraints2D.FreezeRotation;
        CineOve.SetActive(true);
        CineSta.SetActive(false);
        
    }
}
