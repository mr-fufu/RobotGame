using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneManagementScript : MonoBehaviour
{

    public Text valueTxt;

    private void Start()
    {
        valueTxt.text = PersistentManager.single_instance.Value.ToString();
    }

    public void GoToBattleScene()
    {
        SceneManager.LoadScene("MainBattleScene");
        PersistentManager.single_instance.Value++;
    }

    public void GoToWorkshop()
    {
        SceneManager.LoadScene("Workshop");
        PersistentManager.single_instance.Value++;
    }
}
