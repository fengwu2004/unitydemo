﻿using UnityEngine;
using System.Collections;

public class Call : MonoBehaviour {
   
	private AndroidJavaObject jo;

	private AndroidJavaClass jc;

	private AndroidJavaObject activity;

	void initMap() {

		jc = new AndroidJavaClass ("com.unity3d.player.UnityPlayer");

		activity = jc.GetStatic<AndroidJavaObject> ("currentActivity");

		jo = new AndroidJavaObject ("com.yihai.ky.caotang.MyActivity");
		
		activity.Call ("runOnUiThread", new AndroidJavaRunnable (() => {

			jo.Call ("initMap", activity);
		}));
	}

	void Start() {

		Invoke ("initMap", 2);
	}

	void OnGUI() {

        //调用显示一个文本为“Hello World!”的Toest
        if(GUI.Button(new Rect(0, 0, 200, 100), "Show Toest - Hello World!")) {
            //Unity侧调用Android侧代码

			activity.Call ("runOnUiThread", new AndroidJavaRunnable (() => {
			
				jo.Call ("showMap", true, activity);
			}));
        }

 		if (GUI.Button(new Rect(100, 200, 200, 100), "光线"))
        {
			activity.Call("runOnUiThread", new AndroidJavaRunnable(() =>
				{
					AndroidJavaObject Window = activity.Call<AndroidJavaObject>("getWindow");

					AndroidJavaObject Attributes = Window.Call<AndroidJavaObject>("getAttributes");

					Attributes.Set("screenBrightness", 0.7f);

					Window.Call("setAttributes", Attributes);
				}));
        }
    }
}
