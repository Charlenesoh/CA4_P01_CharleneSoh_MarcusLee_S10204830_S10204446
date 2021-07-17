/******************************************************************************
Author: Elyas Chua-Aziz

Name of Class: DemoPlayer

Description of Class: This class will control the movement and actions of a 
                        player avatar based on user input.

Date Created: 09/06/2021
******************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamplePlayer : MonoBehaviour
{
    /// <summary>
    /// The distance this player will travel per second.
    /// </summary>
    [SerializeField]
    public float moveSpeed;

    [SerializeField]
    public float rotationSpeed;

    [SerializeField]
    private float interactionDistance;

    /// <summary>
    /// The camera attached to the player model.
    /// Should be dragged in from Inspector.
    /// </summary>
    [SerializeField]
    private Camera playerCamera;

    private string currentState;

    private string nextState;


    public GameObject quest;
    public GameObject ui;
    public GameObject option;
    public GameObject map;
    public GameObject menu;

    public GameObject photo2;
    public GameObject photo3;
    public GameObject box;
    public GameObject boy;

    // Start is called before the first frame update
    void Start()
    {
        nextState = "Idle";
        rotationSpeed = 60;
    }

    // Update is called once per frame
    void Update()
    {
        if (nextState != currentState)
        {
            SwitchState();
        }

        CheckRotation();
        InteractionRaycast();
        ShowMap();
        ShowMenu();

        if (Input.GetKey(KeyCode.Tab))
        {
            quest.SetActive(true);
        }
        else
        {
            quest.SetActive(false);
        }
    }
    private void InteractionRaycast()
    {
        Debug.DrawLine(playerCamera.transform.position,
                    playerCamera.transform.position + playerCamera.transform.forward * interactionDistance);

        int layermask = 1 << LayerMask.NameToLayer("Interactable");

        RaycastHit hitinfo;
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward,
            out hitinfo, interactionDistance, layermask))
        {
            option.SetActive(true);
            // if my ray hits something, if statement is true
            // do stuff here
            if (Input.GetKeyDown(KeyCode.E))
            {
                hitinfo.transform.GetComponent<InteractableObject>().Interact();
                if (hitinfo.collider.tag == "Photo")
                {
                    rotationSpeed = 0;
                    moveSpeed = 0;
                    ui.SetActive(true);
                    GetComponent<Dialogue>().PhotoText1();
                    photo2.SetActive(true);
                }
                if (hitinfo.collider.tag == "Photo2") 
                {
                    moveSpeed = 0;
                    rotationSpeed = 0;
                    ui.SetActive(true);
                    GetComponent<Dialogue>().PhotoText1();
                    photo3.SetActive(true);
                }
                if (hitinfo.collider.tag == "Photo3") 
                {
                    moveSpeed = 0;
                    rotationSpeed = 0;
                    ui.SetActive(true);
                    GetComponent<Dialogue>().PhotoText1();
                    box.SetActive(true);
                }
                if (hitinfo.collider.tag == "box")
                {
                    moveSpeed = 0;
                    rotationSpeed = 0;
                    ui.SetActive(true);
                    GetComponent<Dialogue>().BoxText();
                    boy.SetActive(true);
                }
                if (hitinfo.collider.tag == "SmallBoy")
                {
                    moveSpeed = 0;
                    rotationSpeed = 0;
                    ui.SetActive(true);
                    GetComponent<Dialogue>().BoyText();
                }
            }
        }
        else
        {
            option.SetActive(false);
        }
    }

    private void ShowMap()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (map.activeSelf)
            {
                map.SetActive(false);
            }
            else
            {
                map.SetActive(true);
            }
        }
    }
    private void ShowMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (menu.activeSelf)
            {
                menu.SetActive(false);
                rotationSpeed = 60;
            }
            else
            {
                rotationSpeed = 0;
                menu.SetActive(true);
            }
        }
    }


    /// <summary>
    /// Sets the current state of the player
    /// and starts the correct coroutine.
    /// </summary>
    private void SwitchState()
    {
        StopCoroutine(currentState);

        currentState = nextState;
        StartCoroutine(currentState);
    }

    private IEnumerator Idle()
    {
        while(currentState == "Idle")
        {
            if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            {
                nextState = "Moving";
            }
            yield return null;
        }
    }

    private IEnumerator Moving()
    {
        while (currentState == "Moving")
        {
            if (!CheckMovement())
            {
                nextState = "Idle";
            }
            yield return null;
        }
    }

    private void CheckRotation()
    {
        Vector3 playerRotation = transform.rotation.eulerAngles;
        playerRotation.y += Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;

        transform.rotation = Quaternion.Euler(playerRotation);

        Vector3 cameraRotation = playerCamera.transform.rotation.eulerAngles;
        cameraRotation.x -= Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;

        playerCamera.transform.rotation = Quaternion.Euler(cameraRotation);
    }

    /// <summary>
    /// Checks and handles movement of the player
    /// </summary>
    /// <returns>True if user input is detected and player is moved.</returns>
    private bool CheckMovement()
    {
        Vector3 newPos = transform.position;

        Vector3 xMovement = transform.right * Input.GetAxis("Horizontal");
        Vector3 zMovement = transform.forward * Input.GetAxis("Vertical");

        Vector3 movementVector = xMovement + zMovement;

        if(movementVector.sqrMagnitude > 0)
        {
            movementVector *= moveSpeed * Time.deltaTime;
            newPos += movementVector;

            transform.position = newPos;
            return true;
        }
        else
        {
            return false;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        CollisionFunction(collision);
    }

    protected virtual void CollisionFunction(Collision collision)
    {
        Debug.Log("hi");
    }
}