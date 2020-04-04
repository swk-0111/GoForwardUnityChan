using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour {

    //キューブの移動速度
    private float speed = -12;

    //消滅位置
    private float deadLine = -10;

    //test 地面の位置
    private float groundLevel = -3.0f;

    //AudioSource
    AudioSource audio;

    // Use this for initialization
    void Start () {
        //AudioSourceの取得
        audio = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {

        //キューブを移動させる引数に与えた値のぶんだけ現在の位置から移動
        //(指定した値の座標に移動するわけではない)
        transform.Translate(this.speed * Time.deltaTime, 0, 0);

        //画面外に出たら破棄する
        if (transform.position.x < this.deadLine)
        {
            Destroy(gameObject);
        }

        //test キューブが着地しているかどうか調べる
        // if(isGround == (transform.position.y > this.groundLevel))
        // {
        // 接していたら音を鳴らす
        //Debug.Log("着地した");
        //     GetComponent<AudioSource>().volume = 1;
        //GetComponent<AudioSource>().volume = (isGround) ? 0 : 1;
        // }

        //bool isGround = (transform.position.y > this.groundLevel) ? false : true;
        //test キューブが着地していたらボリュームをtrue
        //GetComponent<AudioSource>().volume = (isGround) ? 0 : 1;

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        // GetComponent<AudioSource>().volume = 1;

        //音の再生
        audio.Play();

        //もし衝突相手がUnityちゃんだったらvolumeは0
        if (other.gameObject.tag == "UnityChan")
        {
            audio.volume = 0;
        }
    }

}
