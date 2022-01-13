using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//1.������ ������ �������� ���ư��� ��� �Ѵ�
//�ʿ� �Ӽ� : ���ư� �ӵ�
public class Voxel : MonoBehaviour
{
    //1. ������ ���ư� �ӵ� �Ӽ�
    public float speed = 5;
    void Start()
    {
        //2.������ ������ ã�´�
        Vector3 direction = Random.insideUnitSphere;
        //3. ������ �������� ���ư��� �ӵ��� �ش�
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        rb.velocity = direction * speed;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
