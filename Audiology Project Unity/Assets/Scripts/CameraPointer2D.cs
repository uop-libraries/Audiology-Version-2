using UnityEngine;

public class CameraPointer2D : MonoBehaviour
{
    public GameObject reticle;
    public float maxDistance = 10;
    public LayerMask layerMask;
    private GameObject _gazedAtObject;


private void Start()
{


}


    private void Update()
    {

        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.forward, maxDistance, layerMask);

        if (hit.collider != null)
        {
            if (_gazedAtObject != hit.transform.gameObject)
            {
                _gazedAtObject?.SendMessage("OnPointerExit2D", SendMessageOptions.DontRequireReceiver);
                _gazedAtObject = hit.transform.gameObject;
                _gazedAtObject.SendMessage("OnPointerEnter2D", SendMessageOptions.DontRequireReceiver);
            }
            if (hit.transform.gameObject.layer != LayerMask.NameToLayer("UI")) 
            {
                reticle.SetActive(false);
                reticle.transform.position = hit.point;
  reticle.transform.rotation = transform.rotation;
            }
            else 
            {
                reticle.SetActive(false);
            }
        }
        else
        {
            _gazedAtObject?.SendMessage("OnPointerExit2D", SendMessageOptions.DontRequireReceiver);
            _gazedAtObject = null;
            reticle.SetActive(false);
        }


    }
}