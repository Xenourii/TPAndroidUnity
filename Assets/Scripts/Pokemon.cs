using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pokemon : MonoBehaviour
{
    [SerializeField] private Vector3 _rotation;
    private Quaternion _initialRotation;
    private GameManager _gameManager;
    private bool _isZoomedOnMe = false;
    private bool _isShinny = true;

    void Start()
    {
        _gameManager = Camera.main.GetComponent<GameManager>();
        _gameManager.Touch += OnTouchObject;
        _gameManager.ZoomChanged += OnZoomChangedEvent;
        _initialRotation = transform.rotation;
    }

    private void Update()
    {
        if (!_isZoomedOnMe)
        {
            transform.Rotate(_rotation * Time.deltaTime);
        }
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
        _isZoomedOnMe = zoomEvent.ZoomPosition == transform.position;
        if (zoomEvent.IsZoomed)
        {
            transform.rotation = _initialRotation;
            gameObject.SetActive(_isZoomedOnMe);
        } else
        {
            gameObject.SetActive(true);
        }
    }
}
