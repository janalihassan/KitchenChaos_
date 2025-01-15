using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private GameInput gameInput;
    private bool isWalking;
    void Update()
    {
        Vector2 InputVector = gameInput.GetMovementNormalized();

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
