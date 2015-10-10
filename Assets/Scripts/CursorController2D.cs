using UnityEngine;
using System.Collections;

public class CursorController2D : MonoBehaviour {
	public Camera mainCamera;
	GameObject dragTarget;
	float targetZ;
	Vector3 targetOffset;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 mouse = Input.mousePosition;				// マウスカーソルの位置を取ってきて
		Vector3 pos = mainCamera.ScreenToWorldPoint(mouse);	// カメラ位置からワールド座標に変換する
		if(Input.GetMouseButtonDown(0)){					// クリックされたら
			RaycastHit2D hit = Physics2D.Raycast(pos,-Vector2.up,0.01f);	// ヒットチェック
			if(hit.collider!=null){											// ヒットしてたら
				targetOffset = hit.collider.transform.position - pos;		// 位置の差分を保存して
				targetOffset.z = 0;											// z方向は無視する
				targetZ = hit.collider.transform.position.z;				// ｚ座標を保存して
				pos.z = targetZ;											// 
				hit.collider.transform.position = pos + targetOffset;		// マウスのワールド座標に移動
				dragTarget = hit.collider.gameObject;		// つかんだOBJは保持しておく
			}else{
				dragTarget = null;	//つかんでない
			}
		}else if(Input.GetMouseButton(0)){					// ボタンが押された状態なら（ドラッグ中なら）
			if(dragTarget!=null){							// つかんだOBJが無ければ何もしない
				pos.z = targetZ;
				dragTarget.transform.position = pos + targetOffset;		// マウス座標についてくる
			}
		}else{
			dragTarget = null;
		}
	}
}
