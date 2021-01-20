using UnityEngine;

/// <summary>
/// Apply this on a gameObject and reference a MeshRenderer in order to use its lightmap.
/// </summary>
[ExecuteInEditMode]
public class StealLightmap : MonoBehaviour {

    private MeshRenderer currentRenderer;
    public MeshRenderer lightmappedObject;
    
    private void OnEnable()
    {
        Awake();
    }

    private void Awake()
    {
        currentRenderer = gameObject.GetComponent<MeshRenderer>();
        RendererInfoTransfer();
    }

#if UNITY_EDITOR
    void OnBecameVisible()
    {
        RendererInfoTransfer();
    }
#endif

    void RendererInfoTransfer()
    {
        if(lightmappedObject == null || currentRenderer == null)
            return;

        currentRenderer.lightmapIndex = lightmappedObject.lightmapIndex;
        currentRenderer.lightmapScaleOffset = lightmappedObject.lightmapScaleOffset;
        currentRenderer.realtimeLightmapIndex = lightmappedObject.realtimeLightmapIndex;
        currentRenderer.realtimeLightmapScaleOffset = lightmappedObject.realtimeLightmapScaleOffset;
        currentRenderer.lightProbeUsage = lightmappedObject.lightProbeUsage;
    }
}
