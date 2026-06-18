using UnityEngine;
using Color = UnityEngine.Color;

public class Assembly : MonoBehaviour
{
    [SerializeField] private GameObject rna;
    [SerializeField] private GameObject capsid;
    [SerializeField] private GameObject virus;
    [SerializeField] private Light virusLight;

    [SerializeField] private float movementSpeed = 0.02f;
    [SerializeField] private float VirusMovementSpeed = 0.01f;
    [SerializeField] private float LightChangeSpeed = 0.4f;
    [SerializeField] private Color initColor = Color.white;
    [SerializeField] private Color finalColor = Color.red;

    private bool isAssembling = false;
    private bool fase1 = false;
    private bool fase2 = false;

    // Variables para guardar el estado original
    private Vector3 originalRnaPos;
    private Vector3 originalCapsidPos;
    private Vector3 originalVirusPos;
    private bool originalRnaActive;
    private bool originalCapsidActive;
    private bool originalVirusActive;
    private Color originalLightColor;

    private void Awake()
    {
        // Guardar estado original de cada objeto
        if (rna != null)
        {
            originalRnaPos = rna.transform.localPosition;
            originalRnaActive = rna.activeSelf;
        }
        if (capsid != null)
        {
            originalCapsidPos = capsid.transform.localPosition;
            originalCapsidActive = capsid.activeSelf;
        }
        if (virus != null)
        {
            originalVirusPos = virus.transform.localPosition;
            originalVirusActive = virus.activeSelf;
        }
        if (virusLight != null)
        {
            originalLightColor = virusLight.color;
        }
    }

    void Update()
    {
        if (isAssembling)
        {
            wichFase();
            if (!fase1)
            {
                rna.transform.localPosition = Vector3.MoveTowards(rna.transform.localPosition, capsid.transform.localPosition, movementSpeed * Time.deltaTime);
            }
            else if (!fase2)
            {
                capsid.transform.localPosition = Vector3.MoveTowards(capsid.transform.localPosition, virus.transform.localPosition, movementSpeed * Time.deltaTime);
                rna.transform.localPosition = Vector3.MoveTowards(rna.transform.localPosition, virus.transform.localPosition, movementSpeed * Time.deltaTime);
            }
            else
            {
                float timeValue = Mathf.PingPong(Time.time * LightChangeSpeed, 1.0f);
                virusLight.color = Color.Lerp(initColor, finalColor, timeValue);
                virus.transform.localPosition += Vector3.right * VirusMovementSpeed * Time.deltaTime;
            }
        }
    }

    private void wichFase()
    {
        if (rna.transform.localPosition == capsid.transform.localPosition)
        {
            fase1 = true;
        }

        if (capsid.transform.localPosition == virus.transform.localPosition)
        {
            capsid.SetActive(false);
            rna.SetActive(false);
            virus.SetActive(true);
            fase2 = true;
        }
    }

    public void StartAssembly()
    {
        isAssembling = !isAssembling;
    }

    // Nuevo método: Restaura todo al estado inicial
    public void ResetAssembly()
    {
        // Detener la animación
        isAssembling = false;
        fase1 = false;
        fase2 = false;

        // Restaurar posiciones locales
        if (rna != null)
        {
            rna.transform.localPosition = originalRnaPos;
            rna.SetActive(originalRnaActive);
        }
        if (capsid != null)
        {
            capsid.transform.localPosition = originalCapsidPos;
            capsid.SetActive(originalCapsidActive);
        }
        if (virus != null)
        {
            virus.transform.localPosition = originalVirusPos;
            virus.SetActive(originalVirusActive);
        }
        if (virusLight != null)
        {
            virusLight.color = originalLightColor;
        }
    }
}