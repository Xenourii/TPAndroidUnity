using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var gameManager = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameManager>();
        gameManager.ZoomChangedEvent += OnZoomChanged;
    }

    private void OnZoomChanged(object sender, ZoomEventArgs zoomEvent)
    {
        Debug.Log($"zoom={zoomEvent.IsZoomed}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
