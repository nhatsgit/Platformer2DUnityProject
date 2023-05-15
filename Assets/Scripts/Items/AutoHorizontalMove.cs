using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoHorizontalMove : MonoBehaviour
{
    public float rightLandMark;
    public float leftLandMark;
    private bool isLeftDirection;
    public float moveSpeed;
    private void Start()
    {
        isLeftDirection = false;
    }
    private void Update()
    {
        if (this.transform.position.x >= rightLandMark)
        {
            isLeftDirection = true;
        }
        else if (this.transform.position.x<= leftLandMark)
        {
            isLeftDirection = false;
        }
        AutoMove(isLeftDirection);
    }
    private void AutoMove(bool IsLeftDirection)
    {
        if (isLeftDirection)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(leftLandMark - 0.1f,transform.position.y , 0), moveSpeed * Time.fixedDeltaTime);
        }
        else if (!isLeftDirection)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(rightLandMark + 0.1f,transform.position.y , 0), moveSpeed * Time.fixedDeltaTime);
        }
    }
}
