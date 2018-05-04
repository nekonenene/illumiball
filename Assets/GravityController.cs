using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour {
	// 下向きの重力加速度
	const float Gravity = 9.81f;

	// 重力の適用具合
	public float gravityScale = 1.0f;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 vec = new Vector3 ();

		if (Application.isEditor) {
			// Unity Editor 上での動作

			// キーの入力を検知しベクトルを設定
			vec.x = Input.GetAxis ("Horizontal");
			vec.z = Input.GetAxis ("Vertical");

			// 高さ方向の判定はキーの z とする
			if (Input.GetKey ("z")) {
				vec.y = 1.0f;
			} else {
				vec.y = -1.0f;
			}
		} else {
			// 加速度センサーの入力を Unity 空間の軸にマッピングする
			vec.x = Input.acceleration.x;
			vec.y = Input.acceleration.y;
			vec.z = Input.acceleration.z;
		}

		// シーンの重力を、ベクトルの方向に合わせて変化させる
		Physics.gravity = Gravity * vec.normalized * gravityScale;
	}
}
