using UnityEngine;
using System.Collections;

public class ClickScript : MonoBehaviour {
	public UnityEngine.UI.Text goldText;
	public int gold=0;
	public int GPC=1;
	public void OnClick(){
	gold+= GPC;
		goldText.text = "Gold\n" + gold;
	}
}