using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    //�L���[�u�̈ړ����x
    private float speed = -12;

    //���ňʒu
    private float deadline = -10;

    //����炷���߂̃R���|�[�l���g�������
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        //AudioSource�̃R���|�[�l���g���擾����
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //�L���[�u���ړ�������
        transform.Translate(this.speed * Time.deltaTime, 0, 0); //Time.deltaTime�͑O�t���[������̌o�ߎ���

        //��ʂ̊O�ɏo����j������
        if (transform.position.x < this.deadline) 
        {
            Destroy(gameObject);
        }
    }

    //�L���[�u�����̕��ɏՓ˂����ꍇ
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //�Փ˂������̂�Unity�����ł͂Ȃ��ꍇ����炷
        if(collision.gameObject.name != "UnityChan2D")
        {
            audioSource.PlayOneShot(audioSource.clip);  //PlayOneShot�֐��Ō��ʉ��̍Đ��Aclip�͉����t�@�C���̂���
        }
    }
}
