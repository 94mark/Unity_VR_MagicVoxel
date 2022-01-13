using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//1.복셀은 랜덤한 방향으로 날아가는 운동을 한다
//필요 속성 : 날아갈 속도
public class Voxel : MonoBehaviour
{
    //1. 복셀이 날아갈 속도 속성
    public float speed = 5;
    void Start()
    {
        //2.랜덤한 방향을 찾는다
        Vector3 direction = Random.insideUnitSphere;
        //3. 랜덤한 방향으로 날아가는 속도를 준다
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        rb.velocity = direction * speed;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
