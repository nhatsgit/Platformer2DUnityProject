using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RightMoveButton : Button
{
    public override void OnPointerDown(PointerEventData eventData)
    {
        //base.OnPointerDown(eventData);
        PlayerMoveByButtons.instance_.SetHorizontal(1);
    }
    public override void OnPointerUp(PointerEventData eventData)
    {
        //base.OnPointerUp(eventData);
        PlayerMoveByButtons.instance_.SetHorizontal(0);
    }
    
}
