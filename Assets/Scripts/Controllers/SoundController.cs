using UnityEngine;
using UnityEngine.InputSystem.XR.Haptics;

public class SoundController : MonoBehaviour
{
    [SerializeField] private AudioClip[] basicSteps;
    [SerializeField] private AudioClip[] heelsSteps;

    [SerializeField] private AudioClip getCoin;
    public AudioClip GetCoin => getCoin;

    [SerializeField] private AudioClip lostMoney;
    public AudioClip LostMoney => lostMoney;

    [SerializeField] private AudioClip checkpoint;
    public AudioClip Checkpoint => checkpoint;


    public void PlayStepSound(AudioSource source, bool heels)
    {
        AudioClip[] soundArr = heels ? heelsSteps : basicSteps;

        source.PlayOneShot(soundArr[Random.Range(0, soundArr.Length)]);
    }

    public void PlaySound(AudioSource source, AudioClip clip)
    {
        source.PlayOneShot(clip);
    }
}
