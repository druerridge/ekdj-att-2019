using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbGuider : MonoBehaviour
{
    private bool shouldLerp = false;

    public float timeStartedLerping;
    public float lerpTime;

    public GameObject orbPrefab;
    public GameObject activeOrb;

    public Vector3 startPosition;
    public Vector3 endPosition;

    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    //// Update is called once per frame
    void Update()
    {
        // test
        //if (Input.GetKeyDown("space"))
        //{
        //    OrbFromPOItoTargetPanel(new Vector3(0, 0, 0), new Vector3(0, 2, 0));
        //}

        if (shouldLerp)
        {
            if (activeOrb.transform.position == endPosition)
            {
                shouldLerp = false;
                activeOrb.Destroy();
                return;
            }

            activeOrb.transform.position = Lerp(startPosition, endPosition, timeStartedLerping, lerpTime);
        }
    }

    public void OrbFromPOItoTargetPanel (Vector3 startPos, Vector3 endPos)
    {
        activeOrb = Instantiate(orbPrefab, startPos, Quaternion.identity);

        startPosition = startPos;
        endPosition = endPos;

        StartOrbLerp();
    }

    public void StartOrbLerp()
    {
        timeStartedLerping = Time.time;

        shouldLerp = true;
    }

    public Vector3 Lerp (Vector3 start, Vector3 end, float timeStartedLerping, float lerpTime = .5f)
    {
        float timeSinceStarted = Time.time - timeStartedLerping;

        float percentageComplete = timeSinceStarted / lerpTime;

        var result = Vector3.Lerp(start, end, percentageComplete);

        return result;
    }
}
