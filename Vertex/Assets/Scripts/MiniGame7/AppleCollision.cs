using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleCollision : MonoBehaviour
{
    private ScoreManager scoreManager;
    private FollingObjeckt follingObjeckt;
    [SerializeField] private AudioClip _playSaund1;
    private AudioSource _audioSource;
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();

        scoreManager = FindObjectOfType<ScoreManager>();
        follingObjeckt = FindObjectOfType<FollingObjeckt>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Basket"))
        {
            _audioSource.PlayOneShot(_playSaund1, 1f);
            scoreManager.AddScore(1);
            follingObjeckt.SpawnNewObject();
            Debug.Log("яблоко поймано!");
        }
    }


}
