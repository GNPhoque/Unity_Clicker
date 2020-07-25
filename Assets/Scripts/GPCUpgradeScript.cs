using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GPCUpgradeScript : MonoBehaviour {
	
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
		btnText.text = nom + "\t\t\t\tLVL " + level + "\nCost : " + cost + "\nGain : " + bonusPower + " Gold/click";
	}

}