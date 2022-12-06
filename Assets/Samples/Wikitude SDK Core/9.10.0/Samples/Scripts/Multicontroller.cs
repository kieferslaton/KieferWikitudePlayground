using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Wikitude;

public class Multicontroller : MonoBehaviour
{
    private int currentControllerIndex = 0;
    private SpatialController[] controllers;
    private Button backArrow;
    private Button forwardArrow;

    private Image backImage;

    private Image forwardImage;

    [SerializeField] ImageTrackable drawableParent;

    void Awake()
    {
        controllers = GetComponentsInChildren<SpatialController>(true);

        controllers[currentControllerIndex].trackableToChange = drawableParent;

        backArrow = GameObject.Find("Back Arrow").GetComponentInChildren<Button>();
        backImage = backArrow.GetComponentInChildren<Image>();
        backArrow.onClick.AddListener(onBack);
        forwardArrow = GameObject.Find("Forward Arrow").GetComponentInChildren<Button>();
        forwardImage = forwardArrow.GetComponentInChildren<Image>();
        forwardArrow.onClick.AddListener(onForward);
    }

    private void onBack()
    {
        if (currentControllerIndex > 0)
        {
            controllers[currentControllerIndex].gameObject.SetActive(false);
            currentControllerIndex--;
            Debug.Log(drawableParent);
            controllers[currentControllerIndex].trackableToChange = drawableParent;
            controllers[currentControllerIndex].gameObject.SetActive(true);

            if (currentControllerIndex == 0)
            {
                backImage.color = new Color(1f, 1f, 1f, 0.5f);
            }

            if (currentControllerIndex < controllers.Length - 1)
            {
                forwardImage.color = new Color(1f, 1f, 1f, 1f);
            }

        }
    }

    private void onForward()
    {
        if (currentControllerIndex < controllers.Length - 1)
        {
            controllers[currentControllerIndex].gameObject.SetActive(false);
            currentControllerIndex++;
            Debug.Log(drawableParent);
            controllers[currentControllerIndex].trackableToChange = drawableParent;
            controllers[currentControllerIndex].gameObject.SetActive(true);


            if (currentControllerIndex == controllers.Length - 1)
            {
                forwardImage.color = new Color(1f, 1f, 1f, 0.5f);
            }

            if (currentControllerIndex > 0)
            {
                backImage.color = new Color(1f, 1f, 1f, 1f);
            }
        }
    }

    public void ResetTrackerRef(ImageTrackable trackable)
    {
        drawableParent = trackable;
    }
}
