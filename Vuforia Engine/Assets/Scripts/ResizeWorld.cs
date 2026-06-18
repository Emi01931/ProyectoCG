using TMPro;
using UnityEngine;

public class ResizeWorld : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField] private GameObject targetCanvas;   // El Canvas que quieres activar
    [SerializeField] private GameObject objectToScale;  // El objeto cuya escala cambiará
    [SerializeField] private TextMeshProUGUI textToChange;  // El texto que quieres cambiar

    [Header("Ajustes de escala")]
    [SerializeField] private float scaleStep = 0.5f;    // Cantidad a sumar/restar (por defecto 0.5)
    [SerializeField] private float minScale = 0.5f;     // Escala mínima permitida
    [SerializeField] private float maxScale = 5f;       // Escala máxima permitida


    /// <summary>
    /// Activa el Canvas asignado (lo hace visible).
    /// </summary>
    /// 

    private void Awake()
    {
        textToChange.text = objectToScale.transform.localScale.x.ToString("F1");
    }

    public void ActivateCanvas()
    {
        if (targetCanvas != null)
            targetCanvas.SetActive(!targetCanvas.activeSelf);
        else
            Debug.LogWarning("El Canvas de destino no está asignado.");
    }

    /// <summary>
    /// Aumenta la escala del objeto en +0.5 (o el valor definido en scaleStep).
    /// </summary>
    public void ScaleUp()
    {
        if (objectToScale == null)
        {
            Debug.LogWarning("El objeto a escalar no está asignado.");
            return;
        }

        Vector3 newScale = objectToScale.transform.localScale + Vector3.one * scaleStep;
        // Limitar la escala máxima
        newScale.x = Mathf.Min(newScale.x, maxScale);
        newScale.y = Mathf.Min(newScale.y, maxScale);
        newScale.z = Mathf.Min(newScale.z, maxScale);
        objectToScale.transform.localScale = newScale;

        textToChange.text = objectToScale.transform.localScale.x.ToString("F1"); // Asumiendo escala uniforme
    }

    /// <summary>
    /// Disminuye la escala del objeto en -0.5 (o el valor definido en scaleStep).
    /// </summary>
    public void ScaleDown()
    {
        if (objectToScale == null)
        {
            Debug.LogWarning("El objeto a escalar no está asignado.");
            return;
        }

        Vector3 newScale = objectToScale.transform.localScale - Vector3.one * scaleStep;
        // Limitar la escala mínima (evitar valores negativos o cero)
        newScale.x = Mathf.Max(newScale.x, minScale);
        newScale.y = Mathf.Max(newScale.y, minScale);
        newScale.z = Mathf.Max(newScale.z, minScale);
        objectToScale.transform.localScale = newScale;

        textToChange.text = objectToScale.transform.localScale.x.ToString("F1"); // Asumiendo escala uniforme
    }
}