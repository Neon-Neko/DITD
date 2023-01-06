using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour
{

    PlayerMovement playerMovement;

    // Use this for initialization
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.W))
            playerMovement.Move(MoveDirections.Forward);
        if (Input.GetKeyDown(KeyCode.S))
            playerMovement.Move(MoveDirections.Back);
        if (Input.GetKeyDown(KeyCode.A))
            playerMovement.Move(MoveDirections.Left);
        if (Input.GetKeyDown(KeyCode.D))
            playerMovement.Move(MoveDirections.Right);

        if (Input.GetKeyDown(KeyCode.Q))
            playerMovement.Turn(true);
        if (Input.GetKeyDown(KeyCode.E))
            playerMovement.Turn(false);
    }

    public void MoveForward()
    {
        playerMovement.Move(MoveDirections.Forward);
    }
    public void MoveBack()
    {
        playerMovement.Move(MoveDirections.Back);
    }
    public void MoveLeft()
    {
        playerMovement.Move(MoveDirections.Left);
    }
    public void MoveRight()
    {
        playerMovement.Move(MoveDirections.Right);
    }
    public void TurnRight()
    {
        playerMovement.Turn(false);
    }
    public void TurnLeft()
    {
        playerMovement.Turn(true);
    }
}