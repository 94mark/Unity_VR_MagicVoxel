using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//����ڰ� ���콺�� Ŭ���� ������ ������ 1�� ����� �ʹ�
//�ʿ� �Ӽ� : ���� ����
//������Ʈ Ǯ�� ��Ȱ��ȭ�� ������ ��� �ʹ�
//�ʿ� �Ӽ� : ������Ʈ Ǯ, ������Ʈ Ǯ�� ũ��
public class VoxelMaker : MonoBehaviour
{
    //���� ����
    public GameObject voxelFactory;
    //������Ʈ Ǯ�� ũ��
    public int voxelPoolSize = 20;
    //������Ʈ Ǯ
    public static List<GameObject> voxelPool = new List<GameObject>();

    void Start()
    {
        //������Ʈ Ǯ�� ��Ȱ��ȭ�� ������ ��� �ʹ�
        for(int i = 0; i < voxelPoolSize; i++)
        {
            //1.���� ���忡�� ���� �����ϱ�
            GameObject voxel = Instantiate(voxelFactory);
            //2. ���� ��Ȱ��ȭ�ϱ�
            voxel.SetActive(false);
            //3. ������ ������Ʈ Ǯ�� ��� �ʹ�
            voxelPool.Add(voxel);
        }
    }
    void Update()
    {
        //����ڰ� ���콺�� Ŭ���� ������ ������ 1�� ����� �ʹ�
        //1. ����ڰ� ���콺�� Ŭ���ߴٸ�
        if(Input.GetButtonDown("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo = new RaycastHit();
            //2. ���콺�� ��ġ�� �ٴ� ���� ��ġ�� �ִٸ�
            if (Physics.Raycast(ray, out hitInfo))
            {
                //3. ���� ���忡�� ������ ������ �Ѵ�
                GameObject voxel = Instantiate(voxelFactory);
                //4. ������ ��ġ�ϰ� �ʹ�
                voxel.transform.position = hitInfo.point;
            }
        }
    }
}
