using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public static MapManager instance;
    public MeshRenderer meshRenderer;
    private Material originalMaterial;  // Lưu lại vật liệu ban đầu
    private Color originalColor;        // Lưu lại màu sắc ban đầu
    private float originalAlpha;        // Lưu lại alpha ban đầu
    private int originalRenderQueue;
    private void Awake()
    {
        if (!instance) 
        {
            instance = this;
        }
    }

    private void Start()
    {
        originalMaterial = meshRenderer.material;
        originalColor = originalMaterial.color;
        originalAlpha = originalColor.a;
        originalRenderQueue = originalMaterial.renderQueue;
    }

    public void SetToTransparent() 
    {
        originalMaterial.SetFloat("_Mode", 3);  // chuyển rendering mode về Transparent
        originalMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
        originalMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
        originalMaterial.DisableKeyword("_ALPHATEST_ON");
        originalMaterial.EnableKeyword("_ALPHABLEND_ON");
        originalMaterial.renderQueue = 3000;

        Color color = originalMaterial.color;
        color.a = 0.3f; // Set alpha (opacity) về 0.3
        originalMaterial.color = color;
    }

    public void SetToDeFault() 
    {
        originalMaterial.SetFloat("_Mode", 0);  // chuyển rendering mode về Transparent
        originalMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
        originalMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
        originalMaterial.DisableKeyword("_ALPHATEST_ON");
        originalMaterial.EnableKeyword("_ALPHABLEND_ON");
        originalMaterial.renderQueue = originalRenderQueue;
        Color color = originalMaterial.color;
        color.a = originalAlpha;  // Khôi phục lại alpha ban đầu
        originalMaterial.color = color;
    }
    
}
