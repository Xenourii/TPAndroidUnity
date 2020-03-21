using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private bool _isZoomed = false;

    public bool IsZoomed => _isZoomed;

    [SerializeField]
    private TouchPhase touchPhase = TouchPhase.Ended;

    private event EventHandler<ZoomEventArgs> _zoomChangedEvent;

    public event EventHandler<ZoomEventArgs> ZoomChanged
    {
        add => _zoomChangedEvent += value;
        remove => _zoomChangedEvent -= value;
    }

    private event EventHandler<TouchEventArgs> _touch;

    public event EventHandler<TouchEventArgs> Touch
    {
        add => _touch += value;
        remove => _touch -= value;
    }

    private event EventHandler<ChangeMaterialsEventArgs> _changeMaterials;

    public event EventHandler<ChangeMaterialsEventArgs> ChangeMaterials
    {
        add => _changeMaterials += value;
        remove => _changeMaterials -= value;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == touchPhase))
        {
            Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            if (Physics.Raycast(raycast, out RaycastHit raycastHit))
            {
                _touch?.Invoke(this, new TouchEventArgs(raycastHit.transform.gameObject));
            }
        }
    }
    public void OnButtonClicked()
    {
        _isZoomed = !_isZoomed;
        _zoomChangedEvent?.Invoke(this, new ZoomEventArgs(_isZoomed));
    }

    public void OnPokemonZoom(GameObject pokemeon)
    {
        _isZoomed = true;
        _zoomChangedEvent?.Invoke(this, new ZoomEventArgs(_isZoomed, pokemeon.transform.position));
    }

    public void OnPokemonChangeMaterials(string pokemonTag, bool shinny)
    {
        _changeMaterials?.Invoke(this, new ChangeMaterialsEventArgs(pokemonTag, shinny));
    }
}

public class ZoomEventArgs : EventArgs
{
    public ZoomEventArgs(bool isZoomed, Vector3? zoomPosition = null)
    {
        IsZoomed = isZoomed;
        ZoomPosition = zoomPosition;
    }

    public bool IsZoomed { get; }
    public Vector3? ZoomPosition { get; }

}


public class TouchEventArgs : EventArgs
{
    public TouchEventArgs(GameObject touchedObject)
    {
        TouchedObject = touchedObject;
    }

    public GameObject TouchedObject { get; }

}

public class ChangeMaterialsEventArgs : EventArgs
{
    public ChangeMaterialsEventArgs(string pokemonTag, bool shinny)
    {
        PokemonTag = pokemonTag;
        Shinny = shinny;
    }

    public string PokemonTag { get; }
    public bool Shinny { get; }
}