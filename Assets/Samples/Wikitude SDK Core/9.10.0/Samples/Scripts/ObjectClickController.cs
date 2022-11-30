using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Wikitude;

public class ObjectClickController : MonoBehaviour
{

    private ClickTracker tracker;

    void Awake()
    {
        tracker = GameObject.Find("Click Count").GetComponent<ClickTracker>();
    }

    void OnMouseDown()
    {
        tracker.Increment();
    }
}
