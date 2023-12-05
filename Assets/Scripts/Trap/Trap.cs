using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : Attack
{
    [Header("Trap Basic Parameters")]
    public bool isMove;
    public bool isDamage;

    [Header("Trap Movement")]
    public bool isVertical;
    public bool isHorizontal;
    public bool isLooping;
    public float verDistance;
    public float verSpeed;
    public float horDistance;
    public float horSpeed;

    private Vector3 startPosition;
    private Vector3 verDirection;
    private Vector3 horDirection;
    private Vector3 endPosition;
    private bool movingToEnd;

    void Start()
    {
        startPosition = transform.position;
        verDirection = Vector3.up * Mathf.Sign(verDistance); 
        horDirection = Vector3.right * Mathf.Sign(horDistance); 
        endPosition = startPosition + (isVertical ? verDirection * Mathf.Abs(verDistance) : horDirection * Mathf.Abs(horDistance));
        movingToEnd = true; 
    }

    void Update()
    {
        MoveTrap();
    }

    private void MoveTrap()
    {
        Vector3 targetPosition = movingToEnd ? endPosition : startPosition;
        float currentSpeed = isVertical ? verSpeed : horSpeed;
        Vector3 currentDirection = isVertical ? verDirection : horDirection;

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, currentSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
        {
            if (isLooping)
            {
                movingToEnd = !movingToEnd; 
            }
            else
            {
                transform.position = startPosition; 
            }
        }
    }

    protected override void OnTriggerStay2D(Collider2D other)
    {
        if (isDamage) { 
            other.GetComponent<Character>()?.TakeDamage(this);
        }
       
    }

}
