using UnityEngine;
using UnityEngine.UI;
using Wikitude;

public class SizeSlider : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] ImageTrackable trackableToScale;

    void Start()
    {
        _slider.onValueChanged.AddListener((v) => trackableToScale.Drawable.gameObject.transform.localScale = new Vector3(v * 10, v * 10, v * 10));
    }
}
