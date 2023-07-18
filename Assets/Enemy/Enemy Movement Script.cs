using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementScript : MonoBehaviour
{
    public float speed = 0.001f;
    public Vector3 v = new Vector3(1, 1, 1);
    public bool IsX;
    public bool IsY;
    public float UpperRange;
    public float LowerRange;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition += v * speed;

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
}
