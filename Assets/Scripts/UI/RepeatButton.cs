using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class RepeatButton : MonoBehaviour {

    private Action e;
    private Action r;
    private Action p;

    private bool shouldTriggerEvent = false;

	void Update () {
        if(shouldTriggerEvent)
        {
            if (e != null)
                e();
        }
	}

    public void OnPointerDown()
    {
        shouldTriggerEvent = true;
        if (p != null)
            p();
    }

    public void OnPointerUp()
    {
        shouldTriggerEvent = false;
        if (r != null)
            r();
    }

    public void SetRepeatActionAction(Action action)
    {
        e = action;
    }

    public void SetReleaseAction(Action rel)
    {
        r = rel;
    }

    public void SetPressAction(Action pre)
    {
        p = pre;
    }
}
