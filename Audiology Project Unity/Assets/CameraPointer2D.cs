using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class CameraPointer2D : MonoBehaviour
{
    public GameObject reticle;
    public float maxDistance = 10;
    public LayerMask layerMask;
    private GameObject _gazedAtObject;

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.forward, maxDistance, layerMask);
Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.red);
        if (hit.collider != null)
        {
            if (_gazedAtObject != hit.transform.gameObject)
            {
                _gazedAtObject?.SendMessage("OnPointerExit2D", SendMessageOptions.DontRequireReceiver);
                _gazedAtObject = hit.transform.gameObject;
                _gazedAtObject.SendMessage("OnPointerEnter2D", SendMessageOptions.DontRequireReceiver);
            }
            reticle.SetActive(true);
            reticle.transform.position = hit.point;
        }
        else
        {
            _gazedAtObject?.SendMessage("OnPointerExit2D", SendMessageOptions.DontRequireReceiver);
            _gazedAtObject = null;
            reticle.SetActive(false);
Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.red);
        }
    }
}
