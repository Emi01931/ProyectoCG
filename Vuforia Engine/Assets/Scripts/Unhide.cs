using TMPro;
using UnityEngine;

public class Unhide : MonoBehaviour
{
    [SerializeField] private GameObject objectToUnhide;
    [SerializeField] private GameObject objectToHide;
    [SerializeField] private TextMeshProUGUI textToChange;
    [SerializeField] private string newText;
    [SerializeField] private string originalText;

    private bool isUnhidden = false; // false = estado original (objectToHide visible)

    public void UnhideObject()
    {
        // Alternar estado
        isUnhidden = !isUnhidden;

        if (isUnhidden)
        {
            // Mostrar objectToUnhide, ocultar objectToHide, poner newText
            if (objectToUnhide != null) objectToUnhide.SetActive(true);
            if (objectToHide != null) objectToHide.SetActive(false);
            if (textToChange != null) textToChange.text = newText;
        }
        else
        {
            // Volver al estado original: mostrar objectToHide, ocultar objectToUnhide, poner originalText
            if (objectToUnhide != null) objectToUnhide.SetActive(false);
            if (objectToHide != null) objectToHide.SetActive(true);
            if (textToChange != null) textToChange.text = originalText;
        }
    }
}