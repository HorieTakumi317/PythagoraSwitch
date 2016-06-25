using UnityEngine;
using System.Collections;
using UnityEditor;

public class SettingCameras : MonoBehaviour {

	/* 
	 * ＜ピラゴラ用 Camera Utility＞
	 * ・準備
	 * 	①使用するCameraにAddComponentする
	 * 	②使いたい画面をシーンビューで再現したらsetCameraボタンを押す
	 * 	③setした順に1,2,3...と数字キーに各Cameraが割り振られていて、再生中に切り替えられる
	 * 
	 */
	[SerializeField]
	Vector3[]    cameraPositions = new Vector3[10];

	[SerializeField]
	Quaternion[] cameraRotations = new Quaternion[10];

	[SerializeField, Range (1 ,9)]
	int settingNumber = 1;

	[Button ("setCamera", "Set")]
	public int Set;
	
	KeyCode[] numKeyCodes = {
		KeyCode.Alpha0,
		KeyCode.Alpha1,
		KeyCode.Alpha2,
		KeyCode.Alpha3,
		KeyCode.Alpha4,
		KeyCode.Alpha5,
		KeyCode.Alpha6,
		KeyCode.Alpha7,
		KeyCode.Alpha8,
		KeyCode.Alpha9
	};

	// Use this for initialization
	void Start () {

		cameraPositions [0] = transform.position;
		cameraRotations [0] = transform.rotation;
	
	}
	
	// Update is called once per frame
	void Update () {
		for(int i=0; i<10; i++){
			if(Input.GetKeyDown(numKeyCodes[i])){
				Debug.Log (i);
				Debug.Log (cameraPositions[i]);
				transform.position = cameraPositions[i];

				transform.rotation = cameraRotations[i];
			}
		}
	}

	void setCamera () {

		Debug.Log (UnityEditor.SceneView.lastActiveSceneView.camera.transform.position);

		cameraPositions [settingNumber] = UnityEditor.SceneView.lastActiveSceneView.camera.transform.position;
		cameraRotations [settingNumber] = UnityEditor.SceneView.lastActiveSceneView.camera.transform.rotation;

		Debug.Log (cameraPositions [settingNumber]);
		settingNumber = settingNumber == 9 ? 9 : settingNumber + 1;

	}


}
