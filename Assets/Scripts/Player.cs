using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    private bool isWalking;
    void Update()
    {
        Vector2 InputVector = new Vector2(0,0);
        if (Input.GetKey(KeyCode.W))
        {
            InputVector.y = +1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            InputVector.y = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            InputVector.x = +1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            InputVector.x = -1;
        }
        InputVector = InputVector.normalized;

        Vector3 moveDir = new Vector3(InputVector.x,0f, InputVector.y);
        transform.position += moveDir * moveSpeed * Time.deltaTime;

        isWalking = moveDir != Vector3.zero;

        float RotationSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward,moveDir,Time.deltaTime * RotationSpeed);
    }

    public bool IsWalking()
    {
        return isWalking;
    }
}
