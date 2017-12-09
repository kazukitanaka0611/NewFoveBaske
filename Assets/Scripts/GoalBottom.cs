using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalBottom : MonoBehaviour
{
    [SerializeField] ScoreManager scoreManager = null;

    private Collider parentCollider = null;

    public AudioClip se;

    public GameObject goalText;

    public void SetCollider(Collider collider)
    {
        parentCollider = collider;
    }

    private void OnTriggerEnter(Collider collider)
    {

        if (parentCollider == collider)
        {
            print("Detected!");
            if (scoreManager)
            {
                GetComponent<AudioSource>().PlayOneShot(se);
                StartCoroutine("GoalDsp");
                scoreManager.AddScore(2);
            }

        }

    }

    // ゴール文字表示関数
    private IEnumerator GoalDsp()
    {
        Debug.Log("1");
        // ゴール文字表示
        goalText.SetActive(true);

        // 0.5秒待つ  
        yield return new WaitForSeconds(0.5f);

        // ゴール文字非表示
        goalText.SetActive(false);


    }
}
