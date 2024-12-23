using DG.Tweening;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] private GameObject[] flags;

    private Core core;
    void Start()
    {
        core = Core.Instance;

        foreach (var flag in flags)
            flag.transform.Rotate(Vector3.forward, 90);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (var flag in flags)
            {
                Vector3 vec = flag.transform.localEulerAngles;
                vec.z = 0;
                flag.transform.DOLocalRotate(vec, 0.5f);
            }

            core.soundController.PlaySound(audioSource, core.soundController.Checkpoint);
                
        }
    }

}
