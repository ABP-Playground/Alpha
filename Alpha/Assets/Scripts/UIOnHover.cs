using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIOnHover : MonoBehaviour {

	public void OnHover() {
		gameObject.GetComponent<Text> ().color = Color.green;
	}

	public void OnExit() {
		gameObject.GetComponent<Text> ().color = Color.white;
	}

	public void OnClickPlay() {
		StartCoroutine (SceneChange());
	}

	IEnumerator SceneChange() {
		float fadeTime = GameObject.Find ("GameManager").GetComponent<Fade>().BeginFade(1);
		yield return new WaitForSeconds(fadeTime);
		SceneManager.LoadScene (1);
	}
}
