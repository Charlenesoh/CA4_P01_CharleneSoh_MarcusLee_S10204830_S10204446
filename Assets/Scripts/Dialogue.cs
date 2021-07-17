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

    public GameObject street;
    public GameObject alley;
    public GameObject house;

    public int textLine;
    public int questLine;

    public string[] photoText1;
    public string[] photoText2;
    public string[] photoText3;
    public string[] boxText;
    public string[] boyText;
    public string[] album;
    public string[] toy;
    public string[] boy;


    public string[] quest;

    public int photoCounter;
    public int boxCounter;
    public int boyCounter;

    public void Start()
    {
        photoCounter = 0;
        boxCounter = 0;
        boyCounter = 0;
        textLine = 0;
        questLine = 0;
        nameBox.text = "Me";
    }

    void Update()
    {
        Quest();
        PhotoText1();
        if (photoCounter == 3)
        {
            BoxText();
        }
        if (boxCounter == 1)
        {
            BoyText();
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
                street.SetActive(true);
            }
        }
    }

    public void BoxText()
    {
        questBox.text = boxText[textLine];
        if(textLine == 5)
        {
            nameBox.text = "(Unknown)";
        }
        else
        {
            nameBox.text = "Me";
        }
        if (textLine == 7)
        {
            ui.SetActive(false);
            textLine = 0;
            boxCounter = boxCounter + 1;
            player.GetComponent<SamplePlayer>().rotationSpeed = 60;
            player.GetComponent<SamplePlayer>().moveSpeed = 5;
            questLine = questLine + 1;
        }
    }
    public void BoyText()
    {
        questBox.text = boyText[textLine];
        if (textLine == 3)
        {
            nameBox.text = "Small Boy";
        }
        else
        {
            nameBox.text = "Me";
        }
        if (textLine == 8)
        {
            ui.SetActive(false);
            textLine = 0;
            boyCounter = boyCounter + 1;
            player.GetComponent<SamplePlayer>().rotationSpeed = 60;
            player.GetComponent<SamplePlayer>().moveSpeed = 5;
            questLine = questLine + 1;
            alley.SetActive(true);
        }
    }

    public void Quest()
    {
        if (boxCounter >= 1)
        {
            questlist.text = quest[questLine];
        }
        if (photoCounter >= 3)
        {
            questlist.text = quest[questLine+1];
        }
        else
        {
            questlist.text = quest[questLine] + photoCounter + "/3";
        }
        
    }
}
