using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA;
using UnityEngine.XR.WSA.Input;

public class SpatialMapping : MonoBehaviour
{

    private SpatialMappingRenderer surfaceRenderer;
    private SurfaceObserver surfaceObserver;

    // Use this for initialization
    void Start()
    {
        surfaceRenderer = this.gameObject.GetComponentInChildren<SpatialMappingRenderer>();
        surfaceObserver = new SurfaceObserver();
    }

    // Update is called once per frame
    void Update()
    {
        var headPosition = Camera.main.transform.position;
        var gazeDirection = Camera.main.transform.forward;
        int layerMask = 1 << LayerMask.NameToLayer("Spatial Surface");
        RaycastHit[] hits = Physics.RaycastAll(Camera.main.ScreenPointToRay(headPosition), float.MaxValue, layerMask);
        if (hits.Length > 0 && !surfaceRenderer.enabled)
            surfaceRenderer.enabled = true;
    }
}
