using System.Collections.Generic;
using Mapbox.Unity.MeshGeneration.Interfaces;
using UnityEngine;
using UnityEngine.Video;
using System.Linq;
using UnityEngine.UI;

public class VideoPOI : MonoBehaviour, IFeaturePropertySettable
{
    public Vector3 videoPlayerPosition;
    public GameObject videoPlayerPrefab;
    public GameObject highlightSphere;
    public TextMesh textMesh;
    private static Dictionary<string, object> defaultProps = new Dictionary<string, object>()
    {
        //{ "videoUrl", "http://2115b16a.ngrok.io/videos/videoplayback1.mp4" },
    };
    private Dictionary<string, object> poiProperties = defaultProps;
    internal bool highlighted;
    private bool startedPlayback;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void Hightlight()
    {
        highlighted = true;
        highlightSphere.SetActive(true);
        textMesh.text = (string)poiProperties["name"];
        textMesh.gameObject.SetActive(true);
    }

    public void Unhightlight()
    {
        highlighted = false;
        textMesh.gameObject.SetActive(false);
        highlightSphere.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (highlighted)
        {
            highlightSphere.SetActive(true);
            textMesh.gameObject.SetActive(true);
        }
        else
        {
            highlightSphere.SetActive(false);
            textMesh.gameObject.SetActive(false);
        }

    }

    public void StartVideo()
    {
        if (!startedPlayback)
        {
            startedPlayback = true;
            var jsonString = JsonUtility.ToJson(poiProperties);
            Debug.Log("poiProperties: " + jsonString);
            string videoUrl = (string)poiProperties["videoUrl"];
            Debug.Log("Trying to play video: " + videoUrl);
            var videoPlayer = Instantiate(videoPlayerPrefab).GetComponent<VideoPlayer>();
            // videoPlayer.gameObject.transform.SetPositionAndRotation(videoPlayerPosition, videoPlayer.gameObject.transform.rotation);
            videoPlayer.gameObject.transform.SetPositionAndRotation(transform.position, videoPlayer.gameObject.transform.rotation);
            videoPlayer.url = videoUrl;
        }
    }

    public void Set(Dictionary<string, object> props)
    {
        var jsonString = JsonUtility.ToJson(props);
        Debug.Log("Props (" + props.Count  +"): " + jsonString);
        foreach (KeyValuePair<string, object> entry in props)
        {

            Debug.Log("Key: " + entry.Key);
            Debug.Log("Value: " + entry.Value);
        }
        poiProperties = poiProperties.Union(props).ToDictionary(k => k.Key, v => v.Value);
    }
}
