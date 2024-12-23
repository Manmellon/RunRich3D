using DG.Tweening;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private float rotateAngle;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponentInParent<Player>();

            Vector3 vec = player.transform.rotation.eulerAngles;
            vec.y += rotateAngle;

            player.transform.DORotate(vec, 1.5f);
        }
    }
}
