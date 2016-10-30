using UnityEngine;
using System.Collections;

// This is a script for a simple recharging magic system. The idea is that magic starts recharging
// after a defined cooldown period after using it. If this period or the actual recharge process is 
// interrupted by using magic, the cooldown timer starts again from zero. The interruption can be
// caused by calling calculateMagic() with a negative amount from this or another script. Even though
// it's called magic in this script, the resource in question could of course be something else too.

public class MagicSystem : MonoBehaviour {

	// Total amount of available magic.
	public float magic = 0;
	
	// Maximum amount of magic.
	public float maxMagic = 100;
	
	// How long it takes for magic to start recharging after using it (here it takes 5 seconds).
	public float rechargeCooldown = 5;
	
	// When magic is recharging, how often it increases (here every 1 second).
	public float magicRechargeStep = 1;
	
	// When magic is recharging, how much magic is recovered every step (here 2 magic/step).
	public float magicRechargeRate = 2;
	
	void Start() 
	{
		// Initial start of the recharge timer, if magic is not already at max.
		if (magic != maxMagic) 
		{
			StartCoroutine("StartRechargeTimer");
		}
	}
	
	// Timer that starts the recharging after a cooldown.
	private IEnumerator StartRechargeTimer()
    	{
		yield return new WaitForSeconds(rechargeCooldown);
		StartCoroutine("RechargeMagic");
    	}
	
	// Recursive function that handles the recharging.
	private IEnumerator RechargeMagic()
	{
		yield return new WaitForSeconds(magicRechargeStep);
		calculateMagic(magicRechargeRate);
	
		// Keep recharging if magic is not maxed.
		if (magic != maxMagic) 
		{
			StartCoroutine("RechargeMagic");
		}
	}

	// Handles increasing/decreasing magic. It's a public function so it can be called from other scripts.
	public void calculateMagic(float amount)
	{
		// Change magic value and make sure it stays within defined bounds.
		magic += amount;
		Mathf.Clamp(magic, 0, maxMagic);
	
		// Stop recharging only if magic decreases.
		if (amount < 0)
		{
			// Stops both IEnumerators and starts the recharge timer again.
			StopAllCoroutines();
			StartCoroutine("StartRechargeTimer");
		}	
	}
}