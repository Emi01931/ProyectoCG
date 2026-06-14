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

    private void Update()
    {
        if (letsShrink)
        {
            if(!gettingBigger)
            {
                if (Child_Object.transform.localScale.x > minScale)
                {
                    // Subtract from all axes evenly, multiplied by Time.deltaTime for smoothness
                    Child_Object.transform.localScale -= Vector3.one * shrinkSpeed * Time.deltaTime;
                    Child_Object.transform.localPosition -= Vector3.up * movementSpeed * Time.deltaTime;
                }
            }
            else
            {
                if (Child_Object.transform.localScale.x < minScale)
                {
                    // Subtract from all axes evenly, multiplied by Time.deltaTime for smoothness
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
}
