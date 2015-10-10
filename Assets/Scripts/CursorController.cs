using UnityEngine;
using System.Collections;

public class CursorController : MonoBehaviour {
	public GameObject cursorPrefab;
	GameObject cursor;
	public Camera mainCamera;
	// Use this for initialization
	void Start () {
		cursor = Instantiate(cursorPrefab) as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 mouse = Input.mousePosition;			// マウスカーソルの位置を取ってきて
		Ray ray = mainCamera.ScreenPointToRay(mouse);	// カメラ位置からのＲａｙに変換する
		RaycastHit hit;									// Ｒａｙのヒット情報の入れ物を用意して
		if(Physics.Raycast(ray,out hit)){				// ヒットしてたら
			Vector3 pos = hit.point;					// 衝突位置と
			Vector3 norm = hit.normal;					// 衝突した面の法線をもらってきて
			cursor.transform.position = pos;			// カーソル用のオブジェクトの位置と方向を合わせる
			cursor.transform.rotation = Quaternion.FromToRotation(Vector3.up,norm);
			cursor.SetActive(true);						// 
		}else{
			cursor.SetActive(false);					// ヒットしなかったら表示しない
		}
	}
}
