using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Levelcomp : MonoBehaviour
{
    void CharacterDied1()
    {
        Invoke("DeactivateGameObject", 1000000000000000000f);
        SceneManager.LoadScene("Level3");
    }
}
