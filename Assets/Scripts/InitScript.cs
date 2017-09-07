using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

//TODO
//FS & BroderLess
//MAJ du bouton upgrade
//Prestige system

public class InitScript : MonoBehaviour {	

	public class GPCUpgrade{
		public string nom = "";
		public float baseCost = 0;
		public float cost = 0;
		public float bonusPower = 0;
		public int level = 0;
	}

	public List<GPCUpgrade> gpcuList=new List<GPCUpgrade>();
	//GPCUpgradeScript gpcu = new GPCUpgradeScript();
	public UnityEngine.UI.Text goldText;
	public UnityEngine.UI.Text BonusInfoText;
	public float gold = 0, GPC = 0, GPS = 0;
	public Transform UpgradePanel;
	GameObject upgradePioche;
	GameObject upgradeChariot;
	GameObject upgradeDynamite;
	public GPCUpgrade pioche = new GPCUpgrade(){nom="Pioche",baseCost=100,cost=100,bonusPower=1, level=0};
	public GPCUpgrade chariot = new GPCUpgrade(){nom="Chariot",baseCost=1000,cost=1000,bonusPower=1, level=0};
	public GPCUpgrade dynamite = new GPCUpgrade(){nom="Dynamite",baseCost=10000,cost=10000,bonusPower=1, level=0};
	//public GPSUpgrade mineurs = new GPSUpgrade("Mineur",15,15,0.1f,0);
	//public GPSUpgrade mineurs = new GPSUpgrade(){name="Mineur",baseCost=15,cost=15,bonusPower=0.1f, level=0};

	public bool gpc1,gpc2,gpc3,gpc4,gpc5,gpc6,gpc7,gpc8,gpc9 = false;

	void Start () {		
		InvokeRepeating ("Tick", 1.0f, 1.0f);	
		gpcuList.Add (pioche);
		gpcuList.Add (chariot);
		gpcuList.Add (dynamite);
		InstancierGPC(gpcuList);
	}

	void Update () {
		CheckUnlocks ();
		//pioche.bonusPower = 0;
		goldText.text = "Gold\n" + Mathf.Floor(gold);
		BonusInfoText.text = "Gold par click : " + GPC+ "\nGold par seconde : " + GPS;

	}

	private void Tick(){
		GPS = (Mathf.Round (GPS*10))/10;
		gold += GPS;
	}

	/*private void InstancierGPC(List<GPCUpgrade> gpcuList){
		foreach (var item in gpcuList) {
			GameObject upgradeBtn = (GameObject)Instantiate(Resources.Load("UpgradeButton"));
			upgradeBtn.name = item.nom;
			upgradeBtn.transform.SetParent (UpgradePanel);
			upgradeBtn.GetComponentInChildren<Text>().text=item.nom+"\t\t\t\tLVL "+item.level+"\nCost : "+item.cost+"\nGain : "+item.bonusPower+" Gold/click";
			upgradeBtn.GetComponent<GPCUpgradeScript> ().nom = item.nom;
			upgradeBtn.GetComponent<GPCUpgradeScript> ().baseCost = item.baseCost;
			upgradeBtn.GetComponent<GPCUpgradeScript> ().cost = item.cost;
			upgradeBtn.GetComponent<GPCUpgradeScript> ().bonusPower = item.bonusPower;
			upgradeBtn.GetComponent<GPCUpgradeScript> ().level = item.level;
			upgradeBtn.GetComponent<Button> ().onClick.AddListener (() => OnGPCClick (item));
			upgradeBtn.GetComponent<Button> ().onClick.AddListener (() => upgradeBtn.GetComponent<GPCUpgradeScript>().OnClick());
		}
	}*/

	private void InstancierGPC(List<GPCUpgrade> gpcuList){
		for (int i = 0; i < gpcuList.Count; i++) {
			GameObject upgradeBtn = (GameObject)Instantiate(Resources.Load("UpgradeButton"));
			upgradeBtn.name = gpcuList.ElementAt(i).nom;
			upgradeBtn.transform.SetParent (UpgradePanel);
			upgradeBtn.GetComponentInChildren<Text>().text=gpcuList.ElementAt(i).nom+"\t\t\t\tLVL "+gpcuList.ElementAt(i).level+"\nCost : "+gpcuList.ElementAt(i).cost+"\nGain : "+gpcuList.ElementAt(i).bonusPower+" Gold/click";
			upgradeBtn.GetComponent<GPCUpgradeScript> ().nom = gpcuList.ElementAt(i).nom;
			upgradeBtn.GetComponent<GPCUpgradeScript> ().baseCost = gpcuList.ElementAt(i).baseCost;
			upgradeBtn.GetComponent<GPCUpgradeScript> ().cost = gpcuList.ElementAt(i).cost;
			upgradeBtn.GetComponent<GPCUpgradeScript> ().bonusPower = gpcuList.ElementAt(i).bonusPower;
			upgradeBtn.GetComponent<GPCUpgradeScript> ().level = gpcuList.ElementAt(i).level;
			int j = i;
			upgradeBtn.GetComponent<Button> ().onClick.AddListener (() => OnGPCClick (j));
			upgradeBtn.GetComponent<Button> ().onClick.AddListener (() => upgradeBtn.GetComponent<GPCUpgradeScript>().OnClick());
			Debug.Log (i);
		}
	}

	void CheckUnlocks(){
		if (gold>=150) {
			gpc1 = true;
			if (gold>=1000) {
				gpc2 = true;
				if (gold>=10000) {
					gpc3 = true;
					if (gold>=100000) {
						gpc4 = true;
						if (gold>=1000000) {
							gpc5 = true;
							if (gold>=10000000) {
								gpc6 = true;
								if (gold>=100000000) {
									gpc7 = true;

								}
							}
						}
					}
				}
			}
		}
	}

	public void OnNuggetClick(){
		gold+= GPC;
	}

	public void OnGPCClick(int i){
		Debug.Log (i);
		GPCUpgrade item = gpcuList.ElementAt (i);
		if (gold >= item.cost) {
			gold -= item.cost;
			GPC += item.bonusPower;
			item.level++;
			item.cost = Mathf.FloorToInt(item.baseCost * Mathf.Pow(1.15f,item.level));
		}
	}

	private void GPSClick(float gold, float GPS){

	}

}
