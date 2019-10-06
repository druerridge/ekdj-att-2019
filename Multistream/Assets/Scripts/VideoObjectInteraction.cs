using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoObjectInteraction : MonoBehaviour

{

    public bool isScaledUp = false;
    public bool isScaledFull = false;
    public bool isOnMainStage = false;

    private Vector3 originalScale;
    private Vector3 originalPos;
    private Quaternion originalRot;
    internal float lastStartedVideoTime;

    // Start is called before the first frame update
    void Start()
    {
        originalScale = transform.localScale;
        originalPos = transform.position;
        originalRot = transform.rotation;
    }

    // Update is called once per frame
    //void Update()
    //{
        
    //}

    public void ScaleUp()
    {
        if (!isScaledUp && !isOnMainStage)
        {
            transform.localScale *= 1.5f;
            isScaledUp = true;
        }
    }

    public void ScaleOriginal()
    {
        if (isScaledUp && !isOnMainStage)
        {
            transform.localScale = originalScale;
            isScaledUp = false;
        }

    }

    public void ScaleOriginalFromFull()
    {
        transform.localScale = originalScale;
    }

    public void ToggleMainStage()
    {
        if (!isOnMainStage)
        {
            isOnMainStage = true;
            ScaleFull();
            TranslateToMainStage();
            SetFixedRotation();
        }

        else if (isOnMainStage)

        {
            ResetPosition();
            ResetRotation();
            ScaleOriginalFromFull();
            isOnMainStage = false;
        }

    }

    void ScaleFull()
    {
        // transform.localScale = new Vector3(20, 15, 1);
        transform.localScale *= 3f;
        isScaledFull = true;
    }

    void TranslateToMainStage()
    {
        // transform.position = new Vector3(0, 17, 20);
        transform.position += Vector3.up * 8f;
    }

    void SetFixedRotation()
    {
        transform.rotation = new Quaternion(0, 180, 0, 0);
    }

    void ResetPosition()
    {
        transform.position = originalPos;
    }

    void ResetRotation()
    {
        transform.rotation = originalRot;
    }
    
}
