using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporting : MonoBehaviour
{
    public Transform teleportTarget;
    public GameObject thePlayer;

    public void Teleport()
    {
        thePlayer.transform.position = teleportTarget.transform.position;
    }
    void OnTriggerEnter(Collider alley)
    {
        thePlayer.transform.position = teleportTarget.transform.position;
    }
}