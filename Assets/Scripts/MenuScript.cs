using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuScript : MonoBehaviour {

	Resolution[] resolutions;
	bool fullscreen, borderLess = false;
	public GameObject buttonPrefab;
	public GameObject Toggle;
	public Transform MenuPanel;

	// Use this for initialization
	void Start ()
    {
        
        GameObject toggleFS = (GameObject)Instantiate(Toggle, MenuPanel);
        //toggleFS.GetComponent<Toggle>().onValueChanged.AddListener(()=>FSClick(fullscreen));
        GameObject toggleBL = (GameObject)Instantiate(Toggle, MenuPanel);
        //toggleBL.GetComponent<Toggle> ().onValueChanged.AddListener (() => {BLClick();});
        resolutions = Screen.resolutions;
		for (int i = 0; i < resolutions.Length; i++) 
		{
			Debug.Log (resolutions [i] +" , " + resolutions.Length);
			GameObject button = (GameObject)Instantiate(buttonPrefab);
			button.GetComponentInChildren<Text> ().text = resolutions [i].width + "x" + resolutions [i].height;
			int index = i;
			button.GetComponent<Button>().onClick.AddListener(
				() => SetResolution(index));
			button.transform.SetParent(MenuPanel);
		}
	}

	void SetResolution(int i){

		Screen.SetResolution (resolutions [i].width, resolutions [i].height, fullscreen);
	}

	public void FSClick(bool fullscreen){
		Screen.fullScreen = !Screen.fullScreen;
    }
    void BLClick(){
		borderLess = !borderLess;
	}
}
