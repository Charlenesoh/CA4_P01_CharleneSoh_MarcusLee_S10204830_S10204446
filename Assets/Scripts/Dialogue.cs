using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dialogue : MonoBehaviour
{

    public GameObject ui;

    public TMP_Text nameBox;
    public TMP_Text questBox;
    public TMP_Text questlist;

    public GameObject player;

    public int textLine;
    public string[] photoText1;
    public string[] photoText2;
    public string[] photoText3;
    public string[] boxText;

    public int photoCounter;

    public void Start()
    {
        photoCounter = 0;
        textLine = 0;
        nameBox.text = "Me";
    }

    void Update()
    {
        PhotoText1();
        if (photoCounter == 3)
        {
            BoxText();
        }
    }

    public void LineCounter()
    {
        textLine = textLine + 1;
    }
    public void PhotoText1()
    {
        if(photoCounter == 0)
        {
            questBox.text = photoText1[textLine];
            if(textLine == 4)
            {
                ui.SetActive(false);
                textLine = 0;
                photoCounter = photoCounter + 1;
                player.GetComponent<SamplePlayer>().rotationSpeed = 60;
                player.GetComponent<SamplePlayer>().moveSpeed = 5;
            }
        }
        if(photoCounter == 1)
        {
            questBox.text = photoText2[textLine];
            if(textLine == 3)
            {
                ui.SetActive(false);
                textLine = 0;
                photoCounter = photoCounter + 1;
                player.GetComponent<SamplePlayer>().rotationSpeed = 60;
                player.GetComponent<SamplePlayer>().moveSpeed = 5;
            }
        }
        if(photoCounter == 2)
        {
            questBox.text = photoText3[textLine];
            if(textLine == 4)
            {
                ui.SetActive(false);
                textLine = 0;
                photoCounter = photoCounter + 1;
                player.GetComponent<SamplePlayer>().rotationSpeed = 60;
                player.GetComponent<SamplePlayer>().moveSpeed = 5;
            }
        }
    }

    public void BoxText()
    {
        questBox.text = boxText[textLine];
        if (textLine == 7)
        {
            ui.SetActive(false);
            textLine = 0;
            player.GetComponent<SamplePlayer>().rotationSpeed = 60;
            player.GetComponent<SamplePlayer>().moveSpeed = 5;
        }
    }
}
