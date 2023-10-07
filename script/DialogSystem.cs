using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour
{
    [Header("UI组件")]
    public Image headImage;
    public Text textLabel;

    [Header("文本文件")]
    public TextAsset textFile;
    public int index;
    public float textSpeed;

    [Header("头像")]
    public Sprite headPlayer;
    public Sprite headNPC;

    bool textFinished;  //文本是否显示完毕
    bool isTyping;  //是否在逐字显示

    List<string> textList = new List<string>();

    void Awake()
    {
        GetTextFromFile(textFile);
        gameObject.SetActive(false);
    }

    void OnEnable()
    {
        index = 0;  //对话框每次隐藏变为显示就重置对话
        textFinished = true;    //对话框每次隐藏变为显示状态变为文本已结束
        StartCoroutine(setTextUI());
    }

    void Update()
    {
        
        //如果按下F键并且对话全部结束后关闭对话框
        if (Input.GetKeyDown(KeyCode.R) && index == textList.Count)
        {
            gameObject.SetActive(false);
            return;
        }

        //按下F键，当前行文本完成就执行协程，当前行文本未完成就直接显示当前行文本
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (textFinished)
            {
                StartCoroutine(setTextUI());
            }
            else if (!textFinished)
            {
                isTyping = false;
            }
        }
    }

    void GetTextFromFile(TextAsset file)
    {
        //清空文本内容
        textList.Clear();

        //切割文本文件内容然后一行一行加到list集合中
        var lineDate = file.text.Split('\n');
        foreach (var line in lineDate)
        {
            textList.Add(line);
        }
    }

    IEnumerator setTextUI()
    {
        textFinished = false;   //进入文字显示状态
        textLabel.text = "";    //重置文本内容

        //判断文本文件里的内容
        switch (textList[index].Trim())
        {
            case "A":
                headImage.sprite = headPlayer;
                index++;
                break;
            case "B":
                headImage.sprite = headNPC;
                index++;
                break;
        }

        //每按一次F键播放一行文字
        int word = 0;
        while (isTyping && word < textList[index].Length - 1)
        {
            //逐字显示
            textLabel.text += textList[index][word];
            word++;
            yield return new WaitForSeconds(textSpeed);
        }
        //快速显示文本内容为本行内容
        textLabel.text = textList[index];

        isTyping = true;
        textFinished = true;
        index++;
    }
}