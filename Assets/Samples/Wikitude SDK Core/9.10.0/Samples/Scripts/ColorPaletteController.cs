using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Wikitude;

public class ColorPaletteController : MonoBehaviour
{
    [SerializeField] ImageTrackable trackableToChange;

    private ImageTracker trackableParent;
    private GameObject referenceObject;

    void Awake()
    {
        trackableParent = trackableToChange.transform.parent.gameObject.GetComponent<ImageTracker>();
        referenceObject = trackableToChange.Drawable;
    }

    public void OnColorClicked(Button sender)
    {
        Debug.Log(GetComponentInChildren<Image>().color);
        trackableToChange.enabled = false;
        ImageTrackable newTrackable = trackableParent.gameObject.AddComponent(typeof(ImageTrackable)) as ImageTrackable;
        newTrackable.TargetPattern = trackableToChange.TargetPattern;
        referenceObject.gameObject.GetComponent<Renderer>().material.SetColor("_Color", sender.GetComponentInChildren<Image>().color);
        Destroy(trackableToChange);
        newTrackable.Drawable = referenceObject;
        trackableToChange = newTrackable;
        trackableToChange.enabled = true;
    }
}
