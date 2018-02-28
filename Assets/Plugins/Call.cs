using UnityEngine;
using System.Collections;

public class Call : MonoBehaviour {
   
	void OnGUI() {

        //调用显示一个文本为“Hello World!”的Toest
        if(GUI.Button(new Rect(0, 0, 200, 100), "Show Toest - Hello World!")) {
            //Unity侧调用Android侧代码

			AndroidJavaClass jc = new AndroidJavaClass ("com.unity3d.player.UnityPlayer");

			var context = jc.GetStatic<AndroidJavaObject> ("currentActivity");

			AndroidJavaObject jo = new AndroidJavaObject ("com.yellfun.www.exportaar.MainActivity");

			GUI.Button (new Rect (0, 500, 200, 100), "Get Plugin's Information");
			//调用成员方法
			jo.Call ("showMap", true, context);
        }
    }
}
