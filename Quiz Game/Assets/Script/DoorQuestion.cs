using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorQuestion : MonoBehaviour
{
    private enum OpenDirection { x, y, z}
    private OpenDirection direction = OpenDirection.y;
    private float openDistance = 3f;
    private float openSpeed = 2.0f;
    public Transform doorBody;
    bool open = false;
    Vector3 defaultDoorPosition;

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

    private void OnTriggerEnter(Collider enter)
    {
        if (enter.CompareTag("Player"))
        {
            open = true;
        }
    }

    private void OnTriggerExit(Collider exit)
    {
        if (exit.CompareTag("Player"))
        {
            open = false;
        }
    }
}
