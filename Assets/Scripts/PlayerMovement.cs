using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotationSpeed = 5f;

    public Transform leftEdge;
    public Transform rightEdge;

    private float targetRotationY = 0f;
    private Vector2 movement;

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        movement = new Vector2(moveX, moveY).normalized;

        PlayerMove(moveX);
    }

    private void PlayerMove(float moveX)
    {
        Vector3 targetPosition = transform.position + (Vector3)movement * moveSpeed * Time.deltaTime;

        targetPosition.x = Mathf.Clamp(targetPosition.x, leftEdge.position.x, rightEdge.position.x);

        transform.position = targetPosition;

        if (moveX < 0)
        {
            targetRotationY = -30f;
        }
        else if (moveX > 0)
        {
            targetRotationY = 30f;
        }
        else
        {
            targetRotationY = 0f;
        }

        transform.rotation = Quaternion.RotateTowards(
            transform.rotation,
            Quaternion.Euler(0f, targetRotationY, 0f),
            rotationSpeed * Time.deltaTime);
    }
}