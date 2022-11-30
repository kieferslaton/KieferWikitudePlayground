using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickTracker : MonoBehaviour
{
    private int clickCount = 0;

    public int GetClickCount()
    {
        return clickCount;
    }

    public void SetClickCount(int value)
    {
        clickCount = value;
    }

    public void Increment()
    {
        Debug.Log(clickCount);
        clickCount++;
        Debug.Log(clickCount);
        GetComponentInChildren<Text>().text = $"Click Count: {clickCount}";
    }
}
