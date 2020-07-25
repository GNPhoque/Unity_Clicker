using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GPSUpgradeScript : MonoBehaviour {

	public Text btnText;
	public int index;
	public string nom = "";
	public float baseCost = 0;
	public float cost = 0;
	public float bonusPower = 0;
	public int level = 0;

	public void LvlUp()
	{
		level++;
		cost = Mathf.FloorToInt(baseCost * Mathf.Pow(1.15f, level));
		btnText.text = nom + "\t\t\t\tLVL " + level + "\nCost : " + cost + "\nGain : " + bonusPower + " Gold/s";
	}
	/*
	public string nom = "";
	public int baseCost = 0;
	public int cost = 0;
	public float bonusPower = 0;
	public int level = 0;
//	GameObject go = (GameObject)Instantiate(Resources.Load("Upgrade1"));

	//public UnityEngine.UI.Button btn = new UnityEngine.UI.Button ();
	//public UnityEngine.UI.Text GPSText=new UnityEngine.UI.Text(){text=nom + "\t\t\t LVL " + level + "\nCost : " 
	//														+ cost+ "gold \nGain ; "+ bonusPower + "GPS"};
	
	public GPSUpgrade(){

	string nom = "";
	int baseCost = 0;
	int cost = 0;
	float bonusPower = 0;
	int level = 0;
	//UnityEngine.UI.Button btn = new UnityEngine.UI.Button ();
	//UnityEngine.UI.Text GPSText=new UnityEngine.UI.Text(){text=nom + "\t\t\t LVL " + level + "\nCost : " 
	//														+ cost+ "gold \nGain ; "+ bonusPower + "GPS"};
	}

	public GPSUpgrade(string vnom,int vbaseCost, int vcost, float vbonusPower, int vlevel){
		string nom = vnom;
		int baseCost = vbaseCost;
		int cost = vcost;
		float bonusPower = vbonusPower;
		int level = vlevel;
	//	UnityEngine.UI.Button btn = new UnityEngine.UI.Button ();
	//	UnityEngine.UI.Text GPSText=new UnityEngine.UI.Text(){text=nom + "\t\t\t LVL " + level + "\nCost : " 
	//															+ cost+ "gold \nGain ; "+ bonusPower + "GPS"};
	}
		
	public void Clicked(float gold, float GPS){

		if (gold >= cost) {
			gold -= cost;
			GPS += bonusPower;
			level++;
			cost = Mathf.FloorToInt(baseCost * Mathf.Pow(1.15f,level));
		}
	}*/
}
