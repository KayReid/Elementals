
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CoinPanel : MonoBehaviour {


	public Text coinText;
	public int numCoins;
	public static CoinPanel instance;

	void Awake () {
		instance = this;
	}

	public void CollectCoins () {
	
		numCoins++;
		setCoinText ();
	
	}

	public void removeCoins () {
		numCoins -= 3;
		setCoinText ();
	} 

	public void setCoinText () {
		// print ("set the text");
		coinText.text = numCoins.ToString ();

	}

	public bool canUseItem () {
		if (numCoins >= 3) {
			return true;
		} else { 
			return false; 
		}
	}





}
