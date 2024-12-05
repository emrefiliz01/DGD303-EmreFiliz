using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotationSpeed = 5f;

    [SerializeField] private Text WINTEXT;
    [SerializeField] private Button NextLevelButton;
    [SerializeField] private LevelManager levelManager;

    public Transform leftEdge;
    public Transform rightEdge;
    public Transform topEdge;
    public Transform bottomEdge;

    private float targetRotationY = 0f;
    private Vector2 movement;

    private void Start()
    {
        NextLevelButton.onClick.AddListener(levelManager.NextLevel);
    }
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
        targetPosition.y = Mathf.Clamp(targetPosition.y, bottomEdge.position.y, topEdge.position.y);

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
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Win")
        {
            WINTEXT.gameObject.SetActive(true);
            NextLevelButton.gameObject.SetActive(true);

            Time.timeScale = 0;
        }
    }
    public void HideWinUI()
    {
        WINTEXT.gameObject.SetActive(false);
        NextLevelButton.gameObject.SetActive(false);
    }
}