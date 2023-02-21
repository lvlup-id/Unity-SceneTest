using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class nextscene : MonoBehaviour
{
    public void nscene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
