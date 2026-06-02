using UnityEngine;
using Vuforia;

public class ARManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip audioClip;
    [SerializeField] AudioClip audioClip2;
    [SerializeField] ARManager TargetInteraction;
    [SerializeField] GameObject childObject;
    [SerializeField] GameObject otherChild;



    public float chaseSpeed = 0.01f;

    ObserverBehaviour observerBehaviour;
    bool isTracked = false;
    bool hasApeared = false;

    private void Awake()
    {
        observerBehaviour = GetComponent<ObserverBehaviour>();
    }

    private void OnEnable()
    {
        observerBehaviour.OnTargetStatusChanged += Observer_OnTargetStatusChanged;
    }

    private void OnDisable()
    {
        observerBehaviour.OnTargetStatusChanged -= Observer_OnTargetStatusChanged;
    }

    private void Observer_OnTargetStatusChanged(ObserverBehaviour behaviour, TargetStatus arg_status)
    {
        isTracked = (arg_status.Status == Status.TRACKED);
        hasApeared = true;

        if (isTracked && !TargetInteraction.HasApeared())
        {
            if (audioSource.isPlaying) audioSource.Stop();
            audioSource.clip = audioClip;
            audioSource.Play();
        }
        else
        {
            if (audioSource.isPlaying) audioSource.Stop();
            audioSource.clip = audioClip2;
            audioSource.Play();
        }
    }

    private void Update()
    {
        if (TargetInteraction.HasApeared())
        {
            childObject.SetActive(false);
            otherChild.SetActive(true);
        }

        /*
        if (isTracked && TargetInteraction.IsTracked())
        {
            Vector3 targetWorldPos = TargetInteraction.GetChildWorldPosition();
            Vector3 currentWorldPos = childObject.transform.position;
            Vector3 newWorldPos = Vector3.MoveTowards(currentWorldPos, targetWorldPos, chaseSpeed * Time.deltaTime);

            Transform parent = childObject.transform.parent;
            if (parent != null)
            {
                childObject.transform.localPosition = parent.InverseTransformPoint(newWorldPos);
            }
        }
        else
        {
            Vector3 targetWorldPos = transform.position;
            Vector3 currentWorldPos = childObject.transform.position;
            Vector3 newWorldPos = Vector3.MoveTowards(currentWorldPos, targetWorldPos, chaseSpeed * Time.deltaTime);

            Transform parent = childObject.transform.parent;
            if (parent != null)
            {
                childObject.transform.localPosition = parent.InverseTransformPoint(newWorldPos);
            }
        }
        ]*/
    }

    public bool HasApeared()
    {
        return hasApeared;
    }

    public bool IsTracked()
    {
        return isTracked;
    }

    public Vector3 GetChildWorldPosition()
    {
        return childObject.transform.position;
    }
}