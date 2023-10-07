using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortControl : MonoBehaviour
{
    public GameObject Ti;
    public GameObject Xia;
    public GameObject Da;
    public GameObject Tong;

    public GameObject Trigger;
    public GameObject Player;

    private Transform Tian;
    private Transform X;
    private Transform D;
    private Transform T;
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        Tian = Ti.GetComponent<Transform>();
        X = Xia.GetComponent<Transform>();
        D = Da.GetComponent<Transform>();
        T = Tong.GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        if(Tian.position.x>-4.95f&&Tian.position.x<-3.81f&&Tian.position.y>-3.58f&&Tian.position.y<-2.52f)
        {
            if(X.position.x>-3.4&&X.position.x<-2.31f&&X.position.y<-2.52f&&X.position.y>-3.58f)
            {
                if(D.position.x>-1.89f&&D.position.x<-0.68f&&D.position.y<-2.52f&&D.position.y>-3.58f)
                {
                    if(T.position.x>-0.26f&&T.position.x<0.9f&&T.position.y>-3.58f&&T.position.y<-2.52f)
                    {
                        Debug.Log("ERROR！！！");
                        Trigger.SetActive(false);
                        
                        Invoke("Show", 2);
                    }
                }
            }
        }
    }

    void Show()
    {

        Player.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
