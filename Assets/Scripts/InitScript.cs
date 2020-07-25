using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

//TODO
//FS & BroderLess
//MAJ du bouton upgrade
//Prestige system

public class InitScript : MonoBehaviour
{

	public class GPCUpgrade
	{
		public string nom = "";
		public float baseCost = 0;
		public float cost = 0;
		public float bonusPower = 0;
		public int level = 0;
	}

	public class GPSUpgrade
	{
		public string nom = "";
		public float baseCost = 0;
		public float cost = 0;
		public float bonusPower = 0;
		public int level = 0;
	}

	public Text goldText;
	public Text BonusInfoText;
	public Animator Anim;
	public Transform UpgradePanel;
	public Transform GoldParticleSpawner;
	public GameObject GPCUpgradeButton;

	public float gold = 0, GPC = 0, GPS = 0;

	List<GPCUpgrade> gpcuList = new List<GPCUpgrade>();
	List<GPCUpgradeScript> gpcusList = new List<GPCUpgradeScript>();
	List<GPSUpgrade> gpsuList = new List<GPSUpgrade>();
	List<GPSUpgradeScript> gpsusList = new List<GPSUpgradeScript>();
	GPCUpgrade pioche = new GPCUpgrade() { nom = "Pioche", baseCost = 100, cost = 100, bonusPower = 1, level = 0 };
	GPCUpgrade chariot = new GPCUpgrade() { nom = "Chariot", baseCost = 1000, cost = 1000, bonusPower = 2, level = 0 };
	GPCUpgrade dynamite = new GPCUpgrade() { nom = "Dynamite", baseCost = 10000, cost = 10000, bonusPower = 5, level = 0 };
	GPSUpgrade mineur = new GPSUpgrade() { nom = "Mineur", baseCost = 200, cost = 200, bonusPower = 0.1f, level = 0 };

	public bool gpc1, gpc2, gpc3, gpc4, gpc5, gpc6, gpc7, gpc8, gpc9 = false;

	void Start()
	{
		InvokeRepeating("Tick", 1.0f, 1.0f);
		gpcuList.Add(pioche);
		gpcuList.Add(chariot);
		gpcuList.Add(dynamite);
		InstancierGPC(gpcuList);
		gpsuList.Add(mineur);
		InstancierGPS(gpsuList);
	}

	void Update()
	{
		CheckUnlocks();
		goldText.text = "Gold\n" + Mathf.Floor(gold);
		BonusInfoText.text = "Gold par click : " + GPC + "\nGold par seconde : " + GPS;
	}

	private void Tick()
	{
		GPS = (Mathf.Round(GPS * 10)) / 10; //Pour palier aux problèmes de précisions?
		gold += GPS;
	}

	private void InstancierGPC(List<GPCUpgrade> gpcuList)
	{
		for (int i = 0; i < gpcuList.Count; i++)
		{
			GameObject upgradeBtn = (GameObject)Instantiate(Resources.Load("GPCUpgradeButton"), UpgradePanel, false);
			upgradeBtn.name = gpcuList.ElementAt(i).nom;
			upgradeBtn.GetComponentInChildren<Text>().text = gpcuList.ElementAt(i).nom + "\t\t\t\tLVL " + gpcuList.ElementAt(i).level + "\nCost : " + gpcuList.ElementAt(i).cost + "\nGain : " + gpcuList.ElementAt(i).bonusPower + " Gold/click";
			GPCUpgradeScript gpcus = upgradeBtn.GetComponent<GPCUpgradeScript>();
			gpcus.nom = gpcuList.ElementAt(i).nom;
			gpcus.baseCost = gpcuList.ElementAt(i).baseCost;
			gpcus.cost = gpcuList.ElementAt(i).cost;
			gpcus.bonusPower = gpcuList.ElementAt(i).bonusPower;
			gpcus.level = gpcuList.ElementAt(i).level;
			int j = i;
			gpcus.index = j;
			upgradeBtn.GetComponent<Button>().onClick.AddListener(() => OnGPCClick(j));
			gpcusList.Add(gpcus);
		}
	}

	private void InstancierGPS(List<GPSUpgrade> gpsuList)
	{
		for (int i = 0; i < gpsuList.Count; i++)
		{
			GameObject upgradeBtn = (GameObject)Instantiate(Resources.Load("GPSUpgradeButton"), transform, false);
			upgradeBtn.name = gpsuList.ElementAt(i).nom;
			upgradeBtn.GetComponentInChildren<Text>().text = gpsuList.ElementAt(i).nom + "\t\t\t\tLVL " + gpsuList.ElementAt(i).level + "\nCost : " + gpsuList.ElementAt(i).cost + "\nGain : " + gpsuList.ElementAt(i).bonusPower + " Gold/s";
			GPSUpgradeScript gpsus = upgradeBtn.GetComponent<GPSUpgradeScript>();
			gpsus.nom = gpsuList.ElementAt(i).nom;
			gpsus.baseCost = gpsuList.ElementAt(i).baseCost;
			gpsus.cost = gpsuList.ElementAt(i).cost;
			gpsus.bonusPower = gpsuList.ElementAt(i).bonusPower;
			gpsus.level = gpsuList.ElementAt(i).level;
			int j = i;
			gpsus.index = j;
			upgradeBtn.GetComponent<Button>().onClick.AddListener(() => OnGPSClick(j));
			gpsusList.Add(gpsus);
		}
	}

	void CheckUnlocks()
	{
		if (gold >= 150)
		{
			gpc1 = true;
			if (gold >= 1000)
			{
				gpc2 = true;
				if (gold >= 10000)
				{
					gpc3 = true;
					if (gold >= 100000)
					{
						gpc4 = true;
						if (gold >= 1000000)
						{
							gpc5 = true;
							if (gold >= 10000000)
							{
								gpc6 = true;
								if (gold >= 100000000)
								{
									gpc7 = true;

								}
							}
						}
					}
				}
			}
		}
	}

	public void OnNuggetClick()
	{
		gold += GPC;
		Anim.Play("Nugget_click");

		//PARTICLE
		GameObject go = (GameObject)Instantiate(Resources.Load("GoldParticle"), GoldParticleSpawner, false);
		go.transform.Rotate(new Vector3(0, Random.Range(-20f, 20f), 0f));
		ParticleSystem ps = go.GetComponent<ParticleSystem>();
		var x = new ParticleSystem.Burst();
		x.count = 1;
		x.cycleCount = Mathf.RoundToInt(GPC);
		x.repeatInterval = 0.05f;
		ps.emission.SetBurst(1, x);
	}

	public void OnGPCClick(int i)
	{
		GPCUpgradeScript item = gpcusList.First(x => x.index == i);
		if (gold >= item.cost)
		{
			gold -= item.cost;
			item.LvlUp();
			GPC += item.bonusPower;
		}
	}

	public void OnGPSClick(int i)
	{
		GPSUpgradeScript item = gpsusList.First(x => x.index == i);
		if (gold >= item.cost)
		{
			gold -= item.cost;
			item.LvlUp();
			GPS += item.bonusPower;
		}
	}

}
