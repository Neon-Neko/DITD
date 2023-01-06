using UnityEngine;
using System.Collections;
 
public enum MoveDirections
{
    None,
    Forward,
    Right,
    Back,
    Left
}

public class PlayerMovement : MonoBehaviour
{

    public float gridSize = 5f;

    public float animationSpeed = 15f;

    public Vector3 position;
    public Quaternion rotation;

    public void Move(MoveDirections dir)
    {
        if (isAnimating())
            return;

        Vector3 moveDirection = Vector3.zero;

        switch (dir)
        {
            case MoveDirections.Forward:
                {
                    moveDirection = Vector3.forward;
                    break;
                }
            case MoveDirections.Right:
                {
                    moveDirection = -Vector3.left;
                    break;
                }
            case MoveDirections.Back:
                {
                    moveDirection = -Vector3.forward;
                    break;
                }
            case MoveDirections.Left:
                {
                    moveDirection = Vector3.left;
                    break;
                }
            default:
                {
                    Debug.LogWarning("Unknown direction");
                    break;
                }
        }
        Move(moveDirection);
    }

    private bool isAnimating()
    {
        if (transform.position != position)
            return true;
        if ((rotation.eulerAngles - transform.rotation.eulerAngles).sqrMagnitude > 0.1f)
            return true;
        else
            transform.rotation = rotation;
        return false;
    }

    public void Turn(bool left)
    {
        if (isAnimating())
            return;
        if (!left)
            rotation = rotation * Quaternion.Euler(0, 90, 0);
        else
            rotation = rotation * Quaternion.Euler(0, -90, 0);
    }

    private void Move(Vector3 dir)
    {
        //Translates direction from local to world
        Vector3 worldDirection = transform.TransformDirection(dir);


        if (isFreeTile(worldDirection))
        {
            position = worldDirection * gridSize + transform.position;
        }
    }


    private bool isFreeTile(Vector3 worldDirection)
    {

        RaycastHit hit;

        //Debug.DrawLine( transform.position, transform.position + worldDirection * gridSize, Color.red, 1f );

        if (Physics.Raycast(transform.position, worldDirection, out hit, gridSize))
        {
            Debug.Log("Bump " + hit.transform.name);
            return false;
        }
        else
            return true;
    }


    // Use this for initialization
    void Start()
    {
        position = transform.position;
        rotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, Time.deltaTime * 300f);
        transform.position = Vector3.MoveTowards(transform.position, position, Time.deltaTime * animationSpeed);
    }
}
