using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GPCUpgradeScript : MonoBehaviour {

	public GameObject btnText;
	public string nom = "";
	public float baseCost = 0;
	public float cost = 0;
	public float bonusPower = 0;
	public int level = 0;

	public void OnClick(){
		var val=btnText.transform.GetComponentInParent<GPCUpgradeScript>();
		btnText.transform.GetComponent<Text>().text= val.nom+"\t\t\t\tLVL "+val.level+"\nCost : "+val.cost+"\nGain : "+val.bonusPower+" Gold/click";
		Debug.Log (btnText.transform.GetComponent<Text> ().text);
	}
}