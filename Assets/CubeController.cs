using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    //キューブの移動速度
    private float speed = -12;

    //消滅位置
    private float deadline = -10;

    //音を鳴らすためのコンポーネントをいれる
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        //AudioSourceのコンポーネントを取得する
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //キューブを移動させる
        transform.Translate(this.speed * Time.deltaTime, 0, 0); //Time.deltaTimeは前フレームからの経過時間

        //画面の外に出たら破棄する
        if (transform.position.x < this.deadline) 
        {
            Destroy(gameObject);
        }
    }

    //キューブが他の物に衝突した場合
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //衝突したものがUnityちゃんではない場合音を鳴らす
        if(collision.gameObject.name != "UnityChan2D")
        {
            audioSource.PlayOneShot(audioSource.clip);  //PlayOneShot関数で効果音の再生、clipは音源ファイルのこと
        }
    }
}
