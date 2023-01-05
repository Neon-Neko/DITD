using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PlayerInput : MonoBehaviour
{
    public KeyCode forward = KeyCode.W;
    public KeyCode back = KeyCode.S;
    public KeyCode left = KeyCode.A;
    public KeyCode right = KeyCode.D;
    public KeyCode turnLeft = KeyCode.Q;
    public KeyCode turnRight = KeyCode.E;

    PlayerController controller;

    private void Awake()
    {

        controller = GetComponent<PlayerController>();

    }

    private void Update()
    {
        if (Input.GetKeyDown(forward)) controller.moveForward();
        if (Input.GetKeyDown(back)) controller.moveBackwards();
        if (Input.GetKeyDown(left)) controller.moveLeft();
        if (Input.GetKeyDown(right)) controller.moveRight();
        if (Input.GetKeyDown(turnLeft)) controller.RotateLeft();
        if (Input.GetKeyDown(turnRight)) controller.RotateRight();
    }

}
