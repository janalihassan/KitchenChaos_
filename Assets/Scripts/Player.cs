using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour,IkitchenObjectParent
{
    public static Player Instance { get; private set; }

    public event EventHandler<OnSelectedCounterChangedEventArg> OnSelectedCounterChanged;
    public class OnSelectedCounterChangedEventArg : EventArgs
    {
        public BaseCounter selectedCounter;
    }

    [SerializeField] private float moveSpeed;
    [SerializeField] private GameInput gameInput;
    [SerializeField] private LayerMask interactionLayer;
    [SerializeField] private Transform kitchenObjectHoldPoint;



    private bool isWalking;
    private Vector3 lastInterAction;
    private BaseCounter selectedCounter;
    private KitchenObjects kitchenObjects;


    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("The Player has more then one instances");
        }
        Instance = this;
    }

    private void Start()
    {
        gameInput.OnInterAction += GameInput_OnInterAction;
    }

    private void GameInput_OnInterAction(object sender, System.EventArgs e)
    {
        if (selectedCounter != null)
        {
            selectedCounter.Interact(this);
        }

    }

    void Update()
    {
        HandleMovement();
        HandleInteraction();
    }

    public bool IsWalking()
    {
        return isWalking;
    }

    private void HandleInteraction()
    {
        Vector2 InputVector = gameInput.GetMovementNormalized();
        Vector3 moveDir = new Vector3(InputVector.x, 0f, InputVector.y);

        if (moveDir != Vector3.zero)
        {
            lastInterAction = moveDir;
        }

        float interactDistance = 2f;
        if (Physics.Raycast(transform.position, lastInterAction, out RaycastHit raycastHit, interactDistance, interactionLayer))
        {
            if (raycastHit.transform.TryGetComponent(out BaseCounter baseCounter))
            {
               SelectedCounter(baseCounter);
            }
            else
            {
                SelectedCounter(null);
            }
        }
        else
        {
            SelectedCounter(null);
        }

    }


    private void HandleMovement()
    {
        Vector2 InputVector = gameInput.GetMovementNormalized();
        Vector3 moveDir = new Vector3(InputVector.x, 0f, InputVector.y);
        float playerHeigt = 2f;
        float playerRadius = .7f;
        float moveDistance = Time.deltaTime * moveSpeed;




        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeigt, playerRadius, moveDir, moveDistance);

        if (!canMove)
        {
            Vector3 moveDirX = new Vector3(moveDir.x, 0f, 0f).normalized;
            canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeigt, playerRadius, moveDirX, moveDistance);

            if (canMove) // move in X Dir
            {
                moveDir = moveDirX;
            }
            else // move in z
            {
                Vector3 moveDirZ = new Vector3(0f, 0f, moveDir.z).normalized;
                canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeigt, playerRadius, moveDirZ, moveDistance);

                if (canMove)
                {
                    moveDir = moveDirZ;
                }
                else
                {
                    // Cant move
                }
            }
        }

        if (canMove)
        {
            transform.position += moveDir * moveDistance;
        }
        isWalking = moveDir != Vector3.zero;

        float RotationSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * RotationSpeed);
    }

    private void SelectedCounter(BaseCounter selectedCounter)
    {
        this.selectedCounter = selectedCounter;

        OnSelectedCounterChanged?.Invoke(this, new OnSelectedCounterChangedEventArg {
            selectedCounter = selectedCounter
        });
    }

    public Transform GetObjectFollowtransform()
    {
        return kitchenObjectHoldPoint;
    }

    public void SetKitchenObject(KitchenObjects kitchenObject)
    {
        this.kitchenObjects = kitchenObject;
    }
    public KitchenObjects GetKitchenObjects()
    {
        return kitchenObjects;
    }
    public void ClearKitchenObject()
    {
        kitchenObjects = null;
    }
    public bool HasKitchenObject()
    {
        return kitchenObjects != null;
    }
}
