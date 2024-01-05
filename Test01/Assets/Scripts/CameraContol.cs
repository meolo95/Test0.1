using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraContol : MonoBehaviour
{
    public Transform target;
    [SerializeField]  [Range(0.0f, 10f)] float cameraSpeed;
    float y = 0f;
    // Start is called before the first frame update

    private void Awake()
    {
        //target = PlayerManager.Instance.player.transform;
    }
    void Start()
    {
        target = PlayerManager.Instance.player.transform;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void LateUpdate()
    {
        if (PlayerLocation.Instance.isPlay == true)
        {

            var pos = new Vector3(target.position.x, target.position.y, -10f);

            transform.position = Vector3.Lerp(transform.position, pos, cameraSpeed * Time.deltaTime);
        }


        // target�� character �ְ� pos�� target position ����. ���� transform.position(ī�޶� ��ġ) = ī�޶� ��ġ + (�÷��̾� ��ġ - ī�޶� ��ġ) * ī�޶� �ӵ�,
        // �̰� �Ǵ� ������ �� �����Ӹ��� �÷��̾� ��ġ�� ī�޶� ��ġ�� ��������� ���������� 0�� �����ϱ� ������ 
        //ī�޶� �ӵ��� 1�̵� 0.1�̵� ī�޶� ��ġ�� �÷��̾� ��ġ�� ���� �� ����

        


    }
}
