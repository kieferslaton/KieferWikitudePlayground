using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARKit;
using Wikitude;

public class CycleController : MonoBehaviour
{

    [SerializeField] ImageTracker trackableToCycle;
    [SerializeField] GameObject[] objectsToCycle;

    private int index = 0;
    private ImageTrackable currentTrackable;

    Image backButtonImage;
    Image forwardButtonImage;

    void Awake()
    {

        Button backButton = GameObject.Find("ArrowBack").GetComponent<Button>();
        Button forwardButton = GameObject.Find("ArrowForward").GetComponent<Button>();

        backButtonImage = backButton.GetComponentInChildren<Image>();
        forwardButtonImage = forwardButton.GetComponentInChildren<Image>();

        backButtonImage.color = new Color(1f, 1f, 1f, 0.5f);

        currentTrackable = trackableToCycle.gameObject.AddComponent(typeof(ImageTrackable)) as ImageTrackable;
        currentTrackable.transform.SetParent(trackableToCycle.transform);
        currentTrackable.TargetPattern = "koala1";
        currentTrackable.Drawable = objectsToCycle[index];

    }

    public void OnBack()
    {
        if (index > 0)
        {
            index--;
            trackableToCycle.enabled = false;
            currentTrackable.Drawable = objectsToCycle[index];
            trackableToCycle.enabled = true;

            if (index == 0)
            {
                backButtonImage.color = new Color(1f, 1f, 1f, 0.5f);
            }

            if (index < objectsToCycle.Length - 1)
            {
                forwardButtonImage.color = new Color(1f, 1f, 1f, 1f);
            }
        }
    }

    public void OnForward()
    {
        if (index < objectsToCycle.Length - 1)
        {
            index++;
            trackableToCycle.enabled = false;
            currentTrackable.Drawable = objectsToCycle[index];
            trackableToCycle.enabled = true;

            if (index > 0)
            {
                backButtonImage.color = new Color(1f, 1f, 1f, 1f);
            }

            if (index == objectsToCycle.Length - 1)
            {
                forwardButtonImage.color = new Color(1f, 1f, 1f, 0.5f);
            }

        }
    }
}