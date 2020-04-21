using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniGame_Fire : MonoBehaviour
{
    public Slider sliderJauge;

    public bool playing = false;

    float jaugeCoef = 1f;

    Transform flame = null;
    Transform smoke = null;

    float particleSize = 1f;


    void Start()
    {
        sliderJauge.gameObject.SetActive(false);
    }

    public void LaunchMiniGame(GameObject go)
    {
        playing = true;

        sliderJauge.gameObject.SetActive(true);
        sliderJauge.value = 0f;

        particleSize = 1f;

        flame = go.transform.Find("Flame");
        smoke = go.transform.Find("black_smoke");
    }

    void Update()
    {
        if (playing)
        {
            if (sliderJauge.value < 0.25f)
            {
                jaugeCoef = 1.6f;
            }
            else if (sliderJauge.value < 0.5f)
            {
                jaugeCoef = 1.1f;
            }
            else if (sliderJauge.value < 0.75f)
            {
                jaugeCoef = 0.7f;
            }
            else
            {
                jaugeCoef = 0.4f;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                sliderJauge.value += 0.1f * jaugeCoef;
            }

            sliderJauge.value -= 0.001f * (1.65f - jaugeCoef);

            if (sliderJauge.value > 0.5f)
                particleSize -= 0.002f;

            flame.localScale = Vector3.one * particleSize;
            smoke.localScale = Vector3.one * particleSize;

            if (particleSize <= 0f)
            {
                playing = false;
                sliderJauge.gameObject.SetActive(false);
            }
        }
    }
}
