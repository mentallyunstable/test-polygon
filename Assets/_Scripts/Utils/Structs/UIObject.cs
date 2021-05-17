using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct UIObject
{
    [SerializeField]
    private Canvas canvas;
    [SerializeField]
    private GraphicRaycaster raycaster;

    public void Enable()
    {
        canvas.enabled = true;
        raycaster.enabled = true;
    }

    public void Disable()
    {
        canvas.enabled = false;
        raycaster.enabled = false;
    }
}