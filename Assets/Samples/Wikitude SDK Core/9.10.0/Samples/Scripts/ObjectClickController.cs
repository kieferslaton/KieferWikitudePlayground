using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectClickController : MonoBehaviour
{
    private int clickTrack = 0;
    void OnMouseDown()
    {
        clickTrack++;
        GameObject.Find("Click Count").GetComponentInChildren<Text>().text = $"Click Count: {clickTrack}";
    }
}
