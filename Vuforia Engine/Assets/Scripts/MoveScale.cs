using UnityEngine;

public class MoveScale : MonoBehaviour
{
    public GameObject Child_Object;
    public GameObject Other_child;

    bool letsShrink = false;
    bool waitDontResize = true;
    [SerializeField] private bool gettingBigger = false;
    [SerializeField] private float shrinkSpeed = 0.003f;
    [SerializeField] private float movementSpeed = 0.01f;
    [SerializeField] private float minScale = 0.001f;

    // Variables para guardar el estado original
    private Vector3 originalChildPosition;
    private Vector3 originalChildScale;
    private Vector3 originalOtherPosition;
    private Vector3 originalOtherScale;

    private void Awake()
    {
        // Guardar posición y escala inicial del Child_Object
        if (Child_Object != null)
        {
            originalChildPosition = Child_Object.transform.localPosition;
            originalChildScale = Child_Object.transform.localScale;
        }

        // Si también quieres restaurar Other_child, guarda su estado original
        if (Other_child != null)
        {
            originalOtherPosition = Other_child.transform.localPosition;
            originalOtherScale = Other_child.transform.localScale;
        }
    }

    private void Update()
    {
        if (letsShrink)
        {
            if (!gettingBigger)
            {
                if (Child_Object.transform.localScale.x > minScale)
                {
                    Child_Object.transform.localScale -= Vector3.one * shrinkSpeed * Time.deltaTime;
                    Child_Object.transform.localPosition -= Vector3.up * movementSpeed * Time.deltaTime;
                }
            }
            else
            {
                if (Child_Object.transform.localScale.x < minScale)
                {
                    Child_Object.transform.localScale -= Vector3.one * shrinkSpeed * Time.deltaTime;
                    Child_Object.transform.localPosition -= Vector3.up * movementSpeed * Time.deltaTime;
                }
            }

            waitDontResize = false;
        }
    }

    public void restartMySize()
    {
        if (letsShrink && !waitDontResize)
        {
            letsShrink = false;
            Child_Object.transform.localScale = Vector3.one;
            waitDontResize = true;
        }
    }

    public void ScaleObject()
    {
        letsShrink = true;
    }

    // Nuevo método: Restaura posición y escala originales
    public void ResetToOriginal()
    {
        // Detener cualquier cambio en curso
        letsShrink = false;
        waitDontResize = true;

        // Restaurar Child_Object
        if (Child_Object != null)
        {
            Child_Object.transform.localPosition = originalChildPosition;
            Child_Object.transform.localScale = originalChildScale;
        }

        // Restaurar Other_child si existe
        if (Other_child != null)
        {
            Other_child.transform.localPosition = originalOtherPosition;
            Other_child.transform.localScale = originalOtherScale;
        }
    }
}