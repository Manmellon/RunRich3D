using UnityEngine;

public class ChoiceDoor : MonoBehaviour
{
    [SerializeField] private int addingMoney;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponentInParent<Player>();
            player?.AddMoney(addingMoney);
        }
    }
}
