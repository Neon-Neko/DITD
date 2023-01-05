using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool smoothTransition = false;
    public float transitionSpeed = 10f;
    public float transitionRotationSpeed = 500f;

    Vector3 targetGridPos;
    Vector3 prevTargetGridPos;
    Vector3 targetRotation;

    private void Start()
    {
        targetGridPos = Vector3Int.RoundToInt(transform.position);
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        if (true)
        {

            prevTargetGridPos = targetGridPos;

            Vector3 targetPosition = targetGridPos;

            if (targetRotation.y > 270f && targetRotation.y < 361f) targetRotation.y = 0f;
            if (targetRotation.y < 0f) targetRotation.y = 270f;

            if (!smoothTransition)
            {
                transform.position = targetRotation;
                transform.rotation = Quaternion.Euler(targetRotation);
            }
        } else
        {

            targetGridPos = prevTargetGridPos;
        }
    }

    public void RotateLeft() { if (AtRest) if (AtRest) targetRotation -= Vector3.up * 90f; }
    public void RotateRight() { if (AtRest) if (AtRest) targetRotation += Vector3.up * 90f; }
    public void moveForward() { if (AtRest) targetGridPos += transform.forward; }
    public void moveBackwards() { if (AtRest) targetGridPos -= transform.forward; }
    public void moveLeft() { if (AtRest) targetGridPos -= transform.right; }
    public void moveRight() { if (AtRest) targetGridPos += transform.right; }
    bool AtRest
    {
        get
        {
            if ((Vector3.Distance(transform.position, targetGridPos) < 0.05f) &&
                    (Vector3.Distance(transform.eulerAngles, targetRotation) < 0.05))
                return true;

            else
                return false;


        }

    }
}