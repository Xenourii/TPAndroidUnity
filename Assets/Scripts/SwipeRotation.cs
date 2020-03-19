using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeRotation : MonoBehaviour
{
    private Vector2 previousPosition;
    [SerializeField] private float speed;
    private void Update()
    {
        if (Input.touchCount == 1)
        {
            var touch = Input.touches[0];
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    // Stockage du point de départ
                    previousPosition = touch.position;
                    break;
                case TouchPhase.Moved:
                    // Stockage du point de fin
                    var distance = previousPosition.x - touch.position.x;
                    transform.Rotate(Vector3.up * distance * speed * Time.deltaTime);

                    previousPosition = touch.position;
                    break;
            }
        }
    }
}
