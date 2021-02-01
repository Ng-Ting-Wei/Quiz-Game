using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorQuestion : MonoBehaviour
{
    private enum OpenDirection { x, y, z}
    private OpenDirection direction = OpenDirection.y;
    private float openDistance = 3f;
    private float openSpeed = 2.0f;
    public Transform doorBody;
    private bool open = false;
    private bool istriggered = false;
    Vector3 defaultDoorPosition;
    private int questionNumber;
    public Text question;

    private void Start()
    {
        if (doorBody)
        {
            defaultDoorPosition = doorBody.localPosition;
        }
    }

    private void Update()
    {
        if (!doorBody)
            return;
        if (direction == OpenDirection.x)
        {
            doorBody.localPosition = new Vector3(Mathf.Lerp(doorBody.localPosition.x, defaultDoorPosition.x + (open ? openDistance : 0),
                Time.deltaTime * openSpeed), doorBody.localPosition.y, doorBody.localPosition.z);
        }
        else if (direction == OpenDirection.y)
        {
            doorBody.localPosition = new Vector3(doorBody.localPosition.x, Mathf.Lerp(doorBody.localPosition.y,
                defaultDoorPosition.y + (open ? openDistance : 0), Time.deltaTime * openSpeed), doorBody.localPosition.z);
        }
        else if (direction == OpenDirection.z)
        {
            doorBody.localPosition = new Vector3(doorBody.localPosition.x, doorBody.localPosition.y, Mathf.Lerp(doorBody.localPosition.z,
                defaultDoorPosition.z + (open ? openDistance : 0), Time.deltaTime * openSpeed));
        }
    }

    private void questionRandom()
    {
        if (istriggered == true)
        {
            questionNumber = Random.Range(0, 6);
            switch (questionNumber)
            {
                case 5:
                    question.text = "Which BC did Rome's implement a national army?";
                    //print("Which BC did Rome's implement a national army?");
                    //550 BC
                    break;
                case 4:
                    question.text = "During the early days of the roman army, which king implemented a Rome's national army?";
                    //print("During the early days of the roman army, which king implemented a Rome's national army?");
                    //king Servius Tullius
                    break;
                case 3:
                    question.text= "During the early days of the roman army, what were the roman light cavalry called?";
                    //print("During the early days of the roman army, what were the roman light cavalry called?");
                    //Equites Celeres
                    break;
                case 2:
                    question.text = "Which Bc did Rome conquered Gaul?";
                    //print("Which Bc did Rome conquered gaul");
                    //121 BC
                    break;
                case 1:
                    question.text = "What was rome's form of government before becoming an empire?";
                    //print("What was rome's form of government before becoming an empire");
                    //Republic
                    break;
                case 0:
                    question.text = "Which BC did Rome conquered the seas in the Mediterranean?";
                    //print("Which BC did Rome conquered the seas in the Mediterranean");
                    //264 B.C. to 146 B.C.
                    break;
            }
        }
    }

    private void OnTriggerEnter(Collider enter)
    {
        if (enter.CompareTag("Player"))
        {
            istriggered = true;
            open = true;
        }
        questionRandom();
    }

    private void OnTriggerExit(Collider exit)
    {
        if (exit.CompareTag("Player"))
        {
            istriggered = false;
            open = false;
        }
        question.text = "";
    }
}
