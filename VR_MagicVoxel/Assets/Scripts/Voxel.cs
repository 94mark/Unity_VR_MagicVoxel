using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//1.������ ������ �������� ���ư��� ��� �Ѵ�
//�ʿ� �Ӽ� : ���ư� �ӵ�
//2. ���� �ð��� ������ ������ �����ϰ� �ʹ�
//�ʿ� �Ӽ� : ������ ������ �ð�, ��� �ð�
public class Voxel : MonoBehaviour
{
    //������ ���ư� �ӵ� �Ӽ�
    public float speed = 5;
    
    void Start()
    {
        //2.������ ������ ã�´�
        Vector3 direction = Random.insideUnitSphere;
        //3. ������ �������� ���ư��� �ӵ��� �ش�
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        rb.velocity = direction * speed;
        
    }

    //������ ������ �ð�
    public float destroyTime = 3.0f;
    //��� �ð�
    float currentTime;

    void Update()
    {
        //���� �ð��� ������ ������ �����ϰ� �ʹ�
        //1. �ð��� �귯�� �Ѵ�
        currentTime += Time.deltaTime;
        //2. ���� �ð��� �����ϱ�
        //���� ��� �ð��� ���� �ð��� �ʰ��ߴٸ�
        if(currentTime > destroyTime)
        {
            //3.������ �����ϰ� �ʹ�
            Destroy(gameObject);
        }
    }
}
