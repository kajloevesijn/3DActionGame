using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour {
    private Xbox360Wired_InputController controller;
    private CharacterController characterController;
    private Vector3 moveDirection = Vector3.zero;
    [SerializeField]private float rotationSpeed;
    [SerializeField]private float movementSpeed;

    // Use this for initialization
    void Start () {
        characterController = GetComponent<CharacterController>();
        controller = GetComponent<Xbox360Wired_InputController>();
    }
	
	// Update is called once per frame
	void Update () {
        MoveCharacter();
	}

    private void MoveCharacter()
    {
        if (controller.DeadZoneCheckLeft() == true)// only move if the controller is out of the deadzone
        {
            moveDirection = new Vector3(controller.leftStickX, 0 , controller.leftStickY);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection.y -= 10 * Time.deltaTime;
            moveDirection *= movementSpeed;
            characterController.Move(moveDirection * Time.deltaTime);
        }

        //how can i move in a direction without changing the actual rotation of an object (using rigidbody) or rotate without affecting the child objects.
    }
}
