using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] private int addingMoney;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponentInParent<Player>();
            player?.AddMoney(addingMoney);

            Destroy(gameObject);
        }
    }
}
