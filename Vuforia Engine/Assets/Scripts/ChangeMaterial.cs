using UnityEngine;

public class ChangeMaterial : MonoBehaviour
{
    [SerializeField] private Material mealslesSkin;
    [SerializeField] private Material healthySkin;
    [SerializeField] private Material conjuvitisEye;
    [SerializeField] private Material healthyEye;
    [SerializeField] private MeshRenderer eye;
    [SerializeField] private MeshRenderer Face; 

    private bool isInfected = false;

    public void changeMaterial()
    {
        if(isInfected)
        {
            eye.material = conjuvitisEye;
            Face.material = mealslesSkin;
        }
        else
        {
            eye.material = healthyEye;
            Face.material = healthySkin;
        }

        isInfected = !isInfected;
    }
}
