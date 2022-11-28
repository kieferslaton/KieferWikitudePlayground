using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Wikitude;

public class ColorPaletteController : MonoBehaviour
{
    [SerializeField] ImageTrackable trackableToChange;

    public void OnColorClicked(Button sender)
    {
        trackableToChange.enabled = false;
        Debug.Log(sender.GetComponentInChildren<Image>().color);
        trackableToChange.Drawable.gameObject.GetComponent<Renderer>().material.SetColor("_Color", sender.GetComponentInChildren<Image>().color);
        trackableToChange.enabled = true;
    }
}
