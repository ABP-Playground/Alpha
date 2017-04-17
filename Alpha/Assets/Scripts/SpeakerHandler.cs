using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeakerHandler : MonoBehaviour {
	[SerializeField] private Sprite portrait2, background2;

	private GameObject imgUIPortrait, imgUIBackground, txtUIText, txtUIPressEnter;
	private bool playing = false;
	private float timeUntilNextLetter = 0.05f;
	private int currentLetterPosition = 0;
	private string speakerDialogue;

	public static SpeakerHandler instance = null;

	void Awake() {
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);    
		}
		DontDestroyOnLoad(gameObject);
	}

	// Use this for initialization
	void Start () {
		imgUIPortrait = GameObject.Find ("imgUISpeakingPortrait");
		imgUIBackground = GameObject.Find ("imgUISpeakingBackground");
		txtUIText = GameObject.Find ("txtUISpeakingText");
		txtUIPressEnter = GameObject.Find ("txtUIPressEnter");
		initSpeaker (portrait2, background2, "Hello and welcome to cactus land! Drink all the beer you want!");
	}

	// Update is called once per frame
	void Update () {
		if (playing) {
			timeUntilNextLetter -= Time.deltaTime;
			if (timeUntilNextLetter <= 0) {
				if (currentLetterPosition <= speakerDialogue.Length) {
					txtUIText.GetComponent<Text> ().text = speakerDialogue.Substring (0, currentLetterPosition);
					currentLetterPosition++;
					timeUntilNextLetter = 0.05f;
				} else {
					playing = false;
					txtUIPressEnter.GetComponent<Text> ().enabled = true;
					timeUntilNextLetter = 0.05f;
					currentLetterPosition = 0;
				}
			}
		}
		if(Input.GetKeyDown(KeyCode.Return)) {
			hideDialogue ();
		}
	}

	void initSpeaker(Sprite portrait, Sprite background, string text) {
		imgUIPortrait.GetComponent<Image> ().sprite = portrait;
		imgUIBackground.GetComponent<Image> ().sprite = background;
		this.speakerDialogue = text;
		imgUIPortrait.GetComponent<Image> ().enabled = true;
		imgUIBackground.GetComponent<Image> ().enabled = true;
		txtUIText.GetComponent<Text> ().enabled = true;
		play ();
	}

	void play() {
		playing = true;
	}

	void hideDialogue() {
		playing = false;
		imgUIPortrait.GetComponent<Image> ().enabled = false;
		imgUIBackground.GetComponent<Image> ().enabled = false;
		txtUIText.GetComponent<Text> ().enabled = false;
		txtUIPressEnter.GetComponent<Text> ().enabled = false;
	}
}
