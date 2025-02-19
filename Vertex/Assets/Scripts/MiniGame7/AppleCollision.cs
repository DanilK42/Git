using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleCollision : MonoBehaviour
{
    private ScoreManager scoreManager;
    private FollingObjeckt follingObjeckt;
    private void Start()
    {

        scoreManager = FindObjectOfType<ScoreManager>();
        follingObjeckt = FindObjectOfType<FollingObjeckt>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Basket"))
        {
            scoreManager.AddScore(1);
            follingObjeckt.SpawnNewObject();
            Debug.Log("яблоко поймано!");
        }
    }


}
