using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button : MonoBehaviour
{
    private Button _button;

    // Start is called before the first frame update
    void Start()
    {
        var gameManager = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameManager>();
        gameManager.ZoomChanged += OnZoomChanged;
        _button = GetComponent<Button>();
        _button.gameObject.SetActive(false);
    }

    private void OnZoomChanged(object sender, ZoomEventArgs zoomEvent)
    {
        _button.gameObject.SetActive(zoomEvent.IsZoomed);
        Debug.Log($"zoom={zoomEvent.IsZoomed}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
