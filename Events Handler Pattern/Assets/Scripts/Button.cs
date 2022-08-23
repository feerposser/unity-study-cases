using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{

    public class OnMouseClickEventArgs : EventArgs
    {
        public int clicks;
    }

    public EventHandler<OnMouseClickEventArgs> OnMouseClickEvent;

    int clicks;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clicks++;
            OnMouseClickEvent?.Invoke(this, new OnMouseClickEventArgs { clicks = this.clicks });
        }
    }
}
