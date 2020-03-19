using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    GameManager gameManager;
    [SerializeField] private Vector3 _offset;
    private Vector3 _initialPosition;

    void Start()
    {
        gameManager = GetComponent<GameManager>();
        _initialPosition = transform.position;
        gameManager.ZoomChangedEvent += OnZoomChangedEvent;
    }

    void OnZoomChangedEvent(object sender, ZoomEventArgs zoomEvent)
    {
        if (zoomEvent.IsZoomed && zoomEvent.ZoomPosition is Vector3 zoomPosition)
        {
            gameObject.transform.position = _offset + zoomPosition;
        }
        else
        {
            gameObject.transform.position = _initialPosition;
        }
    }
}
