using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GoalScript : MonoBehaviour
{

    public AudioSource audioSource;
    public AudioClip GoalSound;
    public float volume = 1f;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GameObject.FindAnyObjectByType<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            Destroy(collider.gameObject);
            StartCoroutine(waiter());
        }

    }

    IEnumerator waiter()
    {
        audioSource.PlayOneShot(GoalSound, volume);
        yield return new WaitForSeconds(GoalSound.length);
        GameManager.instance.NextLevel();
    }
}
