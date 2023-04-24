using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour
{
    [SerializeField]private Transform targetPos;
    [SerializeField] private float beginFollowPointX;
    [SerializeField] private float endFollowPointX;
    [SerializeField] private float beginFollowPointY;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (targetPos.position.x > beginFollowPointX && targetPos.position.x < endFollowPointX)
        {
            CameraFollowX();
        }
        if (targetPos.position.y > beginFollowPointY)
        {
            CameraFollowY();
        }
    }
    public void CameraFollowY()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, targetPos.position.y, -10),10*Time.fixedDeltaTime);
    }
    public void CameraFollowX()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(targetPos.position.x, transform.position.y, -10), 10 * Time.fixedDeltaTime);
    }
}
