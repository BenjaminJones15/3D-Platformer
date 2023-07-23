using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class CoinScript : MonoBehaviour
{
    public float speed = 100f;
    public int Score = 0;

    public AudioSource audioSource;
    public AudioClip CoinSound;
    public float volume = 1f;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GameObject.FindAnyObjectByType<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float angle = speed * Time.deltaTime;
        transform.Rotate(0, 0, angle);
    }

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player")){
            GameManager.instance.IncreaseScore(1);
            audioSource.PlayOneShot(CoinSound, volume);
            Destroy(gameObject);
            
        }

    }
}
