using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class logo : MonoBehaviour
{
    public GameObject go;
    public bool ison1 = false;
    // Start is called before the first frame update

    void Start()
    {
        Invoke("Setison", 3);
    }

    void Setison()
    {
        ison1 = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (ison1)
        {
            if (GetComponent<VideoPlayer>().isPlaying)
            {
                // Debug.Log("frame"+ (ulong)GetComponent<VideoPlayer>().frame);
                if ((ulong)GetComponent<VideoPlayer>().frame >= GetComponent<VideoPlayer>().frameCount - 1)
                {
                    Debug.Log("logo");
                    // GetComponent<VideoPlayer>().Pause();
                    go.gameObject.SetActive(false);

                    ison1 = false;
                    Destroy(this.go);
                }
            }

        }

    }
}
