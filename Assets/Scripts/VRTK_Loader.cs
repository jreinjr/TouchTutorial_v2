﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VRTK_Loader : MonoBehaviour {

	void Awake () {
        SceneManager.LoadScene("VRTK_Scripts", LoadSceneMode.Additive);
	}

}
