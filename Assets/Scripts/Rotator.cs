using DG.Tweening;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private float rotateAngle;
    [SerializeField] private float rotateTime;

    Collider _collider;

    private void Start()
    {
        _collider = GetComponent<Collider>();   
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponentInParent<Player>();

            Vector3 vec = player.transform.rotation.eulerAngles;
            vec.y += rotateAngle;

            /*float time;
            float x_dist = Mathf.Abs(_collider.bounds.center.x - player.transform.position.x);
            float z_dist = Mathf.Abs(_collider.bounds.center.z - player.transform.position.z);
            if (x_dist > z_dist)
            {
                time = x_dist / player.ForwardSpeed;
            }
            else
            {
                time = z_dist / player.ForwardSpeed;
            }
            Debug.Log(x_dist + " " + z_dist);
            Debug.Log(_collider.bounds.extents + " " + player.characterRadius + " " + player.ForwardSpeed + " " + time);

            player.transform.DOLocalRotate(vec, time);
            */
            player.transform.DORotate(vec, rotateTime);
        }
    }
}
