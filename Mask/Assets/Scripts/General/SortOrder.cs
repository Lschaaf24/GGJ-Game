using UnityEngine;

public class SortOrder : MonoBehaviour
{
    [SerializeField]
    private int sortingOrder = 100;
    [SerializeField]
    private Renderer vfxRenderer;
    [SerializeField]
    private string layer;

    private void OnValidate()
    {
        vfxRenderer = GetComponent<Renderer>();

        if(vfxRenderer)
        {
            vfxRenderer.sortingOrder = sortingOrder;
            vfxRenderer.sortingLayerName = layer;
        }
    }
}
