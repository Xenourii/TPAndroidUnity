using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private bool _isZoomed = false;

    private event EventHandler<ZoomEventArgs> _zoomChangedEvent;

    public event EventHandler<ZoomEventArgs> ZoomChangedEvent
    {
        add => _zoomChangedEvent += value;
        remove => _zoomChangedEvent -= value;
    }

    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButtonClicked()
    {
        _isZoomed = !_isZoomed;
        _zoomChangedEvent?.Invoke(this, new ZoomEventArgs(_isZoomed));
    }
    
}

public class ZoomEventArgs : EventArgs
{
    public ZoomEventArgs(bool isZoomed)
    {
        IsZoomed = isZoomed;
    }

    public bool IsZoomed { get; }

}
