using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class EnemyScript : MonoBehaviour
{
    public float speed = 0.8f;
    public Vector3 v = new Vector3(1, 1, 1);
    public bool IsX;
    public bool IsY;
    public float UpperRange;
    public float LowerRange;

    public AudioSource audioSource;
    public AudioClip EnemySound;
    public float volume = 1f;

    // Start is called before the first frame update
    void Start(){
        audioSource = GameObject.FindAnyObjectByType<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition += v * speed*Time.fixedDeltaTime;

        if (IsX == true){
            if (transform.localPosition.x >= UpperRange){
                speed *= -1;
            } else if (transform.localPosition.x <= LowerRange){
                speed *= -1;
            }
        } else if (IsY == true){
            if (transform.localPosition.y >= UpperRange) {
                speed *= -1;
            } else if (transform.localPosition.y <= LowerRange) {
                speed *= -1;
            }
        } else {
            if (transform.localPosition.z >= UpperRange){
                speed *= -1;
            } else if (transform.localPosition.z <= LowerRange){
                speed *= -1;
            }
        }
  
    }

    public void FixedUpdate()
    {
        
    }

    public void OnAnimatorMove()
    {
        
    }

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player")){
            Destroy(collider.gameObject);
            StartCoroutine(waiter());
        }

    }

    IEnumerator waiter()
    {
        audioSource.PlayOneShot(EnemySound, volume);
        yield return new WaitForSeconds(EnemySound.length);
        GameManager.instance.ResetLevel();
    }
}
