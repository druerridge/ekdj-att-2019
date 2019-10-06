using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    private List<VideoPOI> highlightedPOIs = new List<VideoPOI>();
    private float maxDistance = 250.0f;
    private float radius = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (VideoPOI videoPOI in highlightedPOIs)
        {
            videoPOI.highlighted = false;
        }

        RaycastHit[] raycastHits = Physics.SphereCastAll(gameObject.transform.position, radius, gameObject.transform.forward, maxDistance);

        // highlight
        foreach (var raycastHit in raycastHits)
        {
            VideoPOI videoPOI = raycastHit.transform.gameObject.GetComponent<VideoPOI>();
            if (videoPOI)
            {
                videoPOI.highlighted = true;
                highlightedPOIs.Add(videoPOI);
            }
        }

        // click
        if (Input.GetKey(KeyCode.Space))
        {
            foreach (var raycastHit in raycastHits)
            {
                VideoPOI videoPOI = raycastHit.transform.gameObject.GetComponent<VideoPOI>();
                if (videoPOI)
                {
                    videoPOI.StartVideo();
                }
            }
        }
    }
}
