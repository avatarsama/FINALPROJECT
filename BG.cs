using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BG : MonoBehaviour
{
    public float scrollSpeed;
    public float tileSizeZ;
    public Text winText;

    private Vector3 startPosition;
   

    // Start is called before the first frame update
    void Start()
    {
       startPosition = transform.position; 
    }

    // Update is called once per frame
    void Update()
    {
       float newPosition = Mathf.Repeat (Time.time * scrollSpeed, tileSizeZ);
        transform.position = startPosition + Vector3.forward * newPosition;

        if (winText.text == "You win! Game created by Samantha Barrizonte!")
        {
            StartCoroutine(bgSpeed());
        }

        IEnumerator bgSpeed()
        {
            yield return new WaitForSeconds(1);
            scrollSpeed += -0.002f;
        }
    }
}
