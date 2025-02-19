using System.Collections;
using UnityEngine;

public class FollingObjeckt : MonoBehaviour
{
    public float fallSpeed = 5f;
    public float respawnTime = 1f;
    private ScoreManager scoreManager;
    private void Start()
    {

        scoreManager = FindObjectOfType<ScoreManager>();
        StartCoroutine(Fall());
    }

    private IEnumerator Fall()
    {
        while (true)
        {

            transform.position += Vector3.down * fallSpeed * Time.deltaTime;


            if (transform.position.y < -16f)
            {
                scoreManager.MissApple();
                yield return new WaitForSeconds(respawnTime);
                SpawnNewObject();
            }

            yield return null;
        }
    }

    public void SpawnNewObject()
    {

        float randomX = Random.Range(118.50f, 133.40f);
        transform.position = new Vector3(randomX, -6f, 0);
    }
}
