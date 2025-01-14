using UnityEngine;

public class GeckoMovement : MonoBehaviour
{
    public float moveSpeed = 0.5f;
    public float turnSpeed = 90f;

    public void MoveForward()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    public void MoveBackward()
    {
        transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
    }

    public void TurnLeft()
    {
        transform.Rotate(0, -turnSpeed * Time.deltaTime, 0);
    }

    public void TurnRight()
    {
        transform.Rotate(0, turnSpeed * Time.deltaTime, 0);
    }
}
