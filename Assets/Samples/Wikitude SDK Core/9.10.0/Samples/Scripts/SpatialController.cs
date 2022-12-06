using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Wikitude;

public class SpatialController : MonoBehaviour
{

    [SerializeField] int incrementAmount;
    private string parameter;

    private int currentParamVal = 0;

    private Button decrement;
    private Button increment;

    public ImageTrackable trackableToChange;
    private ImageTracker parentTracker;

    private GameObject referenceObject;

    void Awake()
    {
        parentTracker = trackableToChange.transform.parent.gameObject.GetComponent<ImageTracker>();
        referenceObject = trackableToChange.Drawable;
        parameter = this.name;
        decrement = GameObject.Find("Decrement").GetComponent<Button>();
        decrement.onClick.AddListener(Decrement);
        increment = GameObject.Find("Increment").GetComponent<Button>();
        increment.onClick.AddListener(Increment);
        switch (parameter)
        {
            case "Scale":
                currentParamVal = (int)trackableToChange.Drawable.gameObject.transform.localScale.x;
                break;
            case "Position X":
                currentParamVal = (int)trackableToChange.Drawable.gameObject.transform.localPosition.x;
                break;
            case "Rotation Z":
                currentParamVal = (int)trackableToChange.Drawable.gameObject.transform.localRotation.z;
                break;
            default:
                Debug.Log("Can't update because we don't know that parameter. Talk to your developer.");
                break;
        }

        GetComponentInChildren<Text>().text = $"Current {parameter}: {currentParamVal}";
    }

    public void Decrement()
    {
        Debug.Log("Decrementing");
        currentParamVal -= incrementAmount;

        parentTracker.enabled = false;
        ImageTrackable newTrackable = parentTracker.gameObject.AddComponent(typeof(ImageTrackable)) as ImageTrackable;
        newTrackable.TargetPattern = trackableToChange.TargetPattern;
        switch (parameter)
        {
            case "Scale":
                referenceObject.transform.localScale = new Vector3(currentParamVal, currentParamVal, currentParamVal);
                break;
            case "Position X":
                referenceObject.transform.localPosition = new Vector3(currentParamVal, referenceObject.transform.localPosition.y, referenceObject.transform.localPosition.z);
                break;
            case "Rotation Z":
                referenceObject.transform.localPosition = new Vector3(referenceObject.transform.localRotation.x, referenceObject.transform.localRotation.y, currentParamVal);
                break;
            default:
                Debug.Log("Can't update because we don't know that parameter. Talk to your developer.");
                break;
        }
        Destroy(trackableToChange);
        newTrackable.Drawable = referenceObject;
        trackableToChange = newTrackable;
        GetComponentInChildren<Text>().text = $"Current {parameter}: {currentParamVal}";
        parentTracker.enabled = true;
        referenceObject = trackableToChange.Drawable;
        this.gameObject.transform.parent.gameObject.GetComponent<Multicontroller>().ResetTrackerRef(trackableToChange);

    }
    public void Increment()
    {
        Debug.Log("Incrementing");
        currentParamVal += incrementAmount;

        parentTracker.enabled = false;
        ImageTrackable newTrackable = parentTracker.gameObject.AddComponent(typeof(ImageTrackable)) as ImageTrackable;
        newTrackable.TargetPattern = trackableToChange.TargetPattern;
        switch (parameter)
        {
            case "Scale":
                referenceObject.transform.localScale = new Vector3(currentParamVal, currentParamVal, currentParamVal);
                break;
            case "Position X":
                referenceObject.transform.localPosition = new Vector3(currentParamVal, referenceObject.transform.localPosition.y, referenceObject.transform.localPosition.z);
                break;
            case "Rotation Z":
                referenceObject.transform.Rotate(new Vector3(referenceObject.transform.localRotation.x, referenceObject.transform.localRotation.y, currentParamVal), Space.Self);
                break;
            default:
                Debug.Log("Can't update because we don't know that parameter. Talk to your developer.");
                break;
        }
        Destroy(trackableToChange);
        newTrackable.Drawable = referenceObject;
        trackableToChange = newTrackable;
        GetComponentInChildren<Text>().text = $"Current {parameter}: {currentParamVal}";
        parentTracker.enabled = true;
        referenceObject = trackableToChange.Drawable;
        this.gameObject.transform.parent.gameObject.GetComponent<Multicontroller>().ResetTrackerRef(trackableToChange);
    }
}