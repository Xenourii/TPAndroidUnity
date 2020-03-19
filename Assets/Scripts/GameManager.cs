using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private bool _isZoomed = false;



    public event EventHandler<bool> OnZoom;



    // Start is called before the first frame update
    void Start()
    {

    }



    // Update is called once per frame
    void Update()
    {

    }



    void OnButtonClicked()
    {
        _isZoomed = !_isZoomed;
        OnZoom?.Invoke(this, _isZoomed);
    }

}