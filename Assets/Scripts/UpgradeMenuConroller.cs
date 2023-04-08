using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeMenuConroller : MonoBehaviour
{
    public GameObject upgradeMenu;
    public void upgradeMenuControlller()
    {
        upgradeMenu.SetActive(false);
        Time.timeScale = 1;
    }
}
