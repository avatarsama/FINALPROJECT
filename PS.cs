using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PS : MonoBehaviour
{
    public Text winText;
    private ParticleSystem starField;
    public float sRate = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        starField = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        var emission = starField.emission;
        var starSpeed = starField.main;
        emission.rateOverTime = sRate;

        if (winText.text == "You win! Game created by Samantha Barrizonte!")
        {
            StartCoroutine(sfSpeed());
        }

        IEnumerator sfSpeed()
        {
            yield return new WaitForSeconds(1);
            starSpeed.simulationSpeed += 1;
        }
    }
}
