using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ictr : MonoBehaviour
{
    public virtual void Show() {

    }

    public virtual void Hide() {

    }

    public virtual void Show(Action<float> action,float inputVal, float time = 1f,float TargetVal = 1f)
    {
        if (action != null) {
            LeanTween.value(inputVal, TargetVal, time).setOnUpdate((float val) =>
            {
                action(val);
            });
        }
    }

    public virtual void Hide(Action<float> action, float inputVal,float time = 1f, float TargetVal = 0f)
    {
        if (action != null) {
            LeanTween.value(inputVal, TargetVal, time).setOnUpdate((float val) => {
                action(val);
            });
        }
    }

}
