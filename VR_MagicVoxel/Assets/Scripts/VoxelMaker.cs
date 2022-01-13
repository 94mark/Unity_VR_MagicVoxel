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
    //���� �ð�
    public float createTime = 0.1f;
    //��� �ð�
    float currentTime = 0;

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
        //���� �ð����� ������ ����� �ʹ�
        //1. ��� �ð��� �帥��
        currentTime += Time.deltaTime;
        //2. ��� �ð��� ���� �ð��� �ʰ��ߴٸ�
        if(currentTime > createTime)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo = new RaycastHit();
            //3. Ray�� ���
            if (Physics.Raycast(ray, out hitInfo))
            {
                //���� ������Ʈ Ǯ �̿��ϱ�
                //1. ���� ������Ʈ Ǯ�� ������ �ִٸ�
                if (voxelPool.Count > 0)
                {
                    //������ �������� ���� ��� �ð��� �ʱ�ȭ���ش�
                    currentTime = 0;
                    //2. ������Ʈ Ǯ���� ������ �ϳ� �����´�
                    GameObject voxel = voxelPool[0];
                    //3. ������ Ȱ��ȭ�Ѵ�
                    voxel.SetActive(true);
                    //4. ������ ��ġ�ϰ� �ʹ�
                    voxel.transform.position = hitInfo.point;
                    //5. ������Ʈ Ǯ���� ������ �����Ѵ�
                    voxelPool.RemoveAt(0);
                }
            }
        }
    }
}
