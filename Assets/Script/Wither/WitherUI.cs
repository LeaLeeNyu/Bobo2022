using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WitherUI : MonoBehaviour
{
    [SerializeField] private Slider witherSlider;
    [SerializeField] private Wither wither;
    [SerializeField] private Image sliderImage;
    [SerializeField] private Image iconImage;
    [SerializeField] private Image boboImage;

    private void Start()
    {
        witherSlider.value = 1f;
    }

    private void Update()
    {
        witherSlider.value = 1 - wither.colorTime;
        Color leafColor = new Vector4(wither.leafColor.color.r, wither.leafColor.color.g, wither.leafColor.color.b, 1);
        sliderImage.color = leafColor;
        iconImage.color = leafColor;
        boboImage.color= leafColor;
    }
}
