using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour {
	[SerializeField]
	private int targetSceneIdInBuildSettings;

	private void Start() {
		Button button;
		button = GetComponent<Button>();
		button.onClick.AddListener(buttonOnClick);
	}

	private void buttonOnClick() {
		SceneManager.LoadScene(targetSceneIdInBuildSettings);
	}
}
