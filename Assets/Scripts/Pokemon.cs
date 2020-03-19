using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pokemon : MonoBehaviour
{
    private GameManager _gameManager;
    private bool _isZoomedOnMe = false;
    private bool _isShinny = false;

    void Start()
    {
        _gameManager = Camera.main.GetComponent<GameManager>();
        _gameManager.Touch += OnTouchObject;
        _gameManager.ZoomChanged += OnZoomChangedEvent;
    }

    void OnTouchObject(object sender, TouchEventArgs touchEvent)
    {
        if (touchEvent.TouchedObject.GetInstanceID() == gameObject.GetInstanceID())
        {
            if (_isZoomedOnMe)
            {
                _isShinny = !_isShinny;
                _gameManager.OnPokemonChangeMaterials(tag, _isShinny);
            } else
            {
                _gameManager.OnPokemonZoom(gameObject);
            }
        }
    }

    void OnZoomChangedEvent(object sender, ZoomEventArgs zoomEvent)
    {
        _isZoomedOnMe = zoomEvent.IsZoomed && zoomEvent.ZoomPosition == transform.position;
        gameObject.SetActive(_isZoomedOnMe);
    }
}
