using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleSlider : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Slider>().onValueChanged.AddListener(OnSliderValueChanged);
    }

    private void OnSliderValueChanged(float value)
    {
        player.GetComponent<MainHero>().movementSpeed = value;

    }

    // Update is called once per frame
    void Update()
    {

    }
}
