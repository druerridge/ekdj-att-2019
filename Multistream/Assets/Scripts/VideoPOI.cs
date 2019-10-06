using System;
using System.Collections.Generic;
using Mapbox.Unity.MeshGeneration.Interfaces;
using UnityEngine;
using UnityEngine.Video;

public class VideoPOI : MonoBehaviour, IFeaturePropertySettable
{
    public string videoUrl;
    public Vector3 videoPlayerPosition;
    public GameObject videoPlayerPrefab;
    private static bool showedIt;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && !showedIt)
        {
            showedIt = true;
            Debug.Log("Happened");
            var videoPlayer = Instantiate(videoPlayerPrefab).GetComponent<VideoPlayer>();
            videoPlayer.gameObject.transform.SetPositionAndRotation(videoPlayerPosition, videoPlayer.gameObject.transform.rotation);
            videoPlayer.url = videoUrl;
            //videoPlayer.Play();
        }
    }

    public void Set(Dictionary<string, object> props)
    {
        var jsonString = JsonUtility.ToJson(props);
        Debug.Log("Props: " + jsonString);
    }
}
