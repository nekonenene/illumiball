using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour {
	bool fallIn;

	// どのボールを吸い寄せるかタグで指定
	public string activeTag;

	// ボールが入っているかを返す
	public bool IsFallIn() {
		return fallIn;
	}

	// ホールに侵入したとき
	void OnTriggerEnter (Collider col) {
		if (col.gameObject.tag == activeTag) {
			fallIn = true;
		}
	}
	
	// ホールから出たとき
	void OnTriggerExit (Collider col) {
		if (col.gameObject.tag == activeTag) {
			fallIn = false;
		}
	}

	// オブジェクト同士のコリジョン（衝突）が発生しているときに毎フレーム呼ばれる
	void OnTriggerStay (Collider col) {
		// コライダに触れているオブジェクトの、Rigidbody コンポーネントを取得
		Rigidbody r = col.gameObject.GetComponent<Rigidbody>();

		// ボールがどの方向にあるかを計算
		Vector3 direction = transform.position - col.gameObject.transform.position;
		direction.Normalize ();

		// タグに応じてボールに力を加える
		if (col.gameObject.tag == activeTag) {
			// 中心地点でボールを止めたいので減速
			r.velocity *= 0.9f;

			// 内側への力
			r.AddForce (direction * r.mass * 20.0f);
		} else {
			// 外向きへの力をかける
			r.AddForce(- direction * r.mass * 80.0f);
		}
	}
}
