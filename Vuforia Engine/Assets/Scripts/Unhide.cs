using UnityEngine;

public class Unhide : MonoBehaviour
{
    [SerializeField] private GameObject objectToUnhide;
    [SerializeField] private GameObject objectToHide;

    public void UnhideObject()
    {
        if (objectToUnhide != null)
        {
            objectToUnhide.SetActive(!objectToUnhide.activeInHierarchy);
        }
        if(objectToHide != null)
        {
            objectToHide.SetActive(!objectToHide.activeInHierarchy);
        }
        else
        {
            Debug.LogWarning("Object to unhide is not assigned.");
        }
    }
}
