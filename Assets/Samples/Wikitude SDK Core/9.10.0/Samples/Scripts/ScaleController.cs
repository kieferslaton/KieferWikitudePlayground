using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Wikitude;

public class ScaleController : MonoBehaviour
{
    [SerializeField] ImageTrackable trackableToScale;

    private int currentScale;
    private ImageTracker trackableParent;
    private GameObject referenceObject;

    void Awake()
    {
        currentScale = (int)trackableToScale.Drawable.gameObject.transform.localScale.x;
        GetComponentInChildren<Text>().text = $"Current Scale: {currentScale}";
        trackableParent = trackableToScale.transform.parent.gameObject.GetComponent<ImageTracker>();
        referenceObject = trackableToScale.Drawable;
        Debug.Log(trackableParent);
    }

    public void Decrement()
    {
        Debug.Log("decrementing");
        if (currentScale > 1)
        {
            currentScale--;
            /* For whatever reason, it doesn't update in real time if you try to just adjust the scale on the Drawable directly, 
            even though that works for color adjustment. So what I'm doing here is completely destroying the old trackable,
            instantiating a new trackable that has a Drawable with the new scale, and adding the new trackable in. */
            trackableParent.enabled = false;
            ImageTrackable newTrackable = trackableParent.gameObject.AddComponent(typeof(ImageTrackable)) as ImageTrackable;
            newTrackable.TargetPattern = trackableToScale.TargetPattern;
            referenceObject.transform.localScale -= new Vector3(1f, 1f, 1f);
            Destroy(trackableToScale);
            newTrackable.Drawable = referenceObject;
            trackableToScale = newTrackable;
            GetComponentInChildren<Text>().text = $"Current Scale: {currentScale}";
            trackableParent.enabled = true;
        }
    }
    public void Increment()
    {
        Debug.Log("incrementing");
        if (currentScale < 10)
        {
            currentScale++;
            trackableParent.enabled = false;
            ImageTrackable newTrackable = trackableParent.gameObject.AddComponent(typeof(ImageTrackable)) as ImageTrackable;
            newTrackable.TargetPattern = trackableToScale.TargetPattern;
            referenceObject.transform.localScale += new Vector3(1f, 1f, 1f);
            Destroy(trackableToScale);
            newTrackable.Drawable = referenceObject;
            trackableToScale = newTrackable;
            GetComponentInChildren<Text>().text = $"Current Scale: {currentScale}";
            trackableParent.enabled = true;
        }
    }
}
