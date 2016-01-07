﻿using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    private Xbox360Wired_InputController controller;
    private CharacterController characterController;
    private Vector3 moveDirection = Vector3.zero;

    private float baseMaxMovementSpeed;
    public bool boost = false;
    public bool boostHalt;



    private float timeStampBoost;
    [SerializeField]
    private float boostCooldownPeriod;
    [SerializeField]
    private float rotationSpeed;
    [SerializeField]
    private float accelerationSpeed;
    [SerializeField]
    private float baseMovementSpeed;
    [SerializeField]
    private float maxMovementSpeed;
    [SerializeField]
    private float currentMaxMovementSpeed;
    [SerializeField]
    private float currentMovementSpeed;
    [SerializeField]
    private float BoostSpeed;
    [SerializeField]
    private float boostFallOff;

    // Use this for initialization
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        controller = GetComponent<Xbox360Wired_InputController>();
        baseMaxMovementSpeed = maxMovementSpeed; //sets where to fall back to when using the boost.
    }

    // Update is called once per frame
    void Update()
    {
        MoveCharacter();
    }

    private void MoveCharacter()
    {
        DynamicSpeedControl();
        Boost();
        if (controller.DeadZoneCheckLeft() == true)// only move if the controller is out of the deadzone
        {
            moveDirection = new Vector3(controller.leftStickX, 0, controller.leftStickY);
            moveDirection = transform.TransformDirection(moveDirection);

            if (currentMovementSpeed <= currentMaxMovementSpeed)// for acceleration of the movement
            {
                currentMovementSpeed = currentMovementSpeed + (accelerationSpeed * Time.deltaTime);
            }
            else if (currentMovementSpeed >= maxMovementSpeed)
            {
                currentMovementSpeed = Mathf.Clamp(currentMovementSpeed, 0, maxMovementSpeed);
            }
        }
        else// if the stick is not used deaccalerate
        {
            if (currentMovementSpeed >= 0)
            {
                currentMovementSpeed = currentMovementSpeed - (accelerationSpeed * Time.deltaTime); // for deccelerating of the movements
            }
            if (currentMovementSpeed <= 0)
            {
                currentMovementSpeed = 0;
            }
        }

        moveDirection.y -= 30 * Time.deltaTime; // gravity
        characterController.Move(moveDirection * currentMovementSpeed * Time.deltaTime);
    }

    private void DynamicSpeedControl()
    {
        if (controller.leftStickX >= .1f)
        {
            currentMaxMovementSpeed = maxMovementSpeed * controller.leftStickX; // do this so max movement speed is based on how far you push the stick
        }
        else if (controller.leftStickX <= -.1f)
        {
            currentMaxMovementSpeed = -maxMovementSpeed * controller.leftStickX; // multiplying by negatives makes positives
        }
        if (controller.leftStickY >= .1f)
        {
            currentMaxMovementSpeed = maxMovementSpeed * controller.leftStickY; // do this so max movement speed is based on how far you push the stick
        }
        else if (controller.leftStickY <= -.1f)
        {
            currentMaxMovementSpeed = -maxMovementSpeed * controller.leftStickY; // multiplying by negatives makes positives
        }
    }

    public void knockback()
    {

    }

    public void Boost() //maxspeed is changed by dynamic, doesn't work yet
    {
        if (boost && Time.time >= timeStampBoost) // boost the movement speed, set bool to false when boost is done
        {
            
            if (boostHalt == false)
            {
                timeStampBoost = Time.time + boostCooldownPeriod; // sets cooldown
                boostHalt = true;  //don't repeat this otherwise maxmove is stuck at 20
                maxMovementSpeed = BoostSpeed; // sets new max speed for boost;
            }
        }
        //maxMovementSpeed -= (Time.deltaTime * boostFallOff); // decreases speed over time
        if (maxMovementSpeed <= baseMaxMovementSpeed) // if the speed fell of back to the base amount set previous maxspeed to normal and bool to false
        {
            maxMovementSpeed = baseMaxMovementSpeed; // set max back to normal
            boost = false; // you aren't boosting anymore
            boostHalt = false;  //you can set the boost speed aain

        }
        else
        {
            //maxMovementSpeed = maxMovementSpeed * (Time.deltaTime * boostFallOff); // decreases speed over time
            maxMovementSpeed = maxMovementSpeed * boostFallOff;
        }

    }
}
