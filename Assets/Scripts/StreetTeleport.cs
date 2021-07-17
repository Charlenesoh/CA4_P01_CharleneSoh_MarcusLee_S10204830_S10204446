using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetTeleport : MonoBehaviour
{
    public Transform teleportTarget;
    public GameObject thePlayer;

    void OnTriggerEnter(Collider Street)
    {
        thePlayer.transform.position = teleportTarget.transform.position;
    }
}