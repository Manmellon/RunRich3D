using DG.Tweening;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private GameObject[] flags;

    void Start()
    {
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
                
        }
    }

}
