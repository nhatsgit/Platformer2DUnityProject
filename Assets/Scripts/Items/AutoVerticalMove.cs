using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoVerticalMove : MonoBehaviour
{
    public float upperLandMark;
    public float lowerLandMark;
    private bool isDownDirection;
    public float moveSpeed;
    private void Start()
    {
        isDownDirection=false;
    }
    private void Update()
    {
            if (this.transform.position.y >= upperLandMark)
            {
                isDownDirection=true;
            }
            else if (this.transform.position.y <= lowerLandMark)
            {
                isDownDirection=false;
            }
            AutoMove(isDownDirection);
    }
    private void AutoMove(bool IsDownDirection)
    {
        if (isDownDirection)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, lowerLandMark-0.1f, 0), moveSpeed * Time.fixedDeltaTime);
        }
        else if(!isDownDirection)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, upperLandMark+0.1f, 0), moveSpeed * Time.fixedDeltaTime);
        }
    }
}
