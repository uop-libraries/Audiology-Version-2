//-----------------------------------------------------------------------
// This Script is modified 

// <copyright file="CameraPointer.cs" company="Google LLC">
// Copyright 2020 Google LLC
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections;
using UnityEngine;

/// <summary>
/// Sends messages to gazed GameObject.
/// </summary>
public class CursorPointer : MonoBehaviour
{
    private const float _maxDistance = 1000;

    private GameObject _gazedAtObject = null;
    private bool _isDelay;
    // public GameObject reticle;

    /// <summary>
    /// Update is called once per frame.
    ///  /// </summary>
    void Start()
    {
        _isDelay = false;
        Debug.Log("Delay: " + _isDelay );
    }
    
   
    public void Update()
    {
        // Casts ray towards camera's forward direction, to detect if a GameObject is being gazed
        // at.
        RaycastHit hit;
        
        if (StateNameController.isClick)
        {
            StateNameController.isClick = false;
            _isDelay = true;
            // Debug.Log("Delay: " + _isDelay );
            StartCoroutine(TimeDelay());
        }
        
        if (!_isDelay)
        {
            if (Physics.Raycast(transform.position, transform.forward, out hit, _maxDistance))
            {
                // GameObject detected in front of the camera.
                if (_gazedAtObject != hit.transform.gameObject)
                {
                    // New GameObject.
                    _gazedAtObject?.SendMessage("OnPointerOff", SendMessageOptions.DontRequireReceiver);
                    // _gazedAtObject?.SendMessage("OnPointerEnter");
                    _gazedAtObject = hit.transform.gameObject;
                    _gazedAtObject.SendMessage("OnPointerOn");
                    // reticle.SetActive(false);
                    // 
                }
            }
            else
            {
                // No GameObject detected in front of the camera.
                _gazedAtObject?.SendMessage("OnPointerOff", SendMessageOptions.DontRequireReceiver);
                _gazedAtObject = null;
                // reticle.SetActive(true);
            }

            // Checks for screen touches.
            if (Google.XR.Cardboard.Api.IsTriggerPressed)
            {
                _gazedAtObject?.SendMessage("OnPointerClick");
            }
        }

    }
    
    IEnumerator TimeDelay()
    {
        yield return new WaitForSecondsRealtime(2);
        _isDelay = false;
        // Debug.Log("Delay: " + _isDelay );
    }
}