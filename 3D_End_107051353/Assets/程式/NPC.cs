
using UnityEngine;
using UnityEngine.UI;
using System.Collections;   //協同程序

public class NPC : MonoBehaviour
{
    [Header("NPC 資料")]
    public NPCData data;
    [Header("對話框")]
    public GameObject dialog;
    [Header("對話內容")]
    public Text textcontent;
    [Header("對話者名稱")]
    public Text textname;
    [Header("對話間隔")]
    public float interval = 0.2f;

    public bool playerInArea;

    public enum NPCState
    {
        FirstDialog,Missioning,Finish
    }

    public NPCState state = NPCState.FirstDialog;

    /*private void Start()
    {
        StartCoroutine (Test());
        //啟動協同
    }

    private IEnumerator Test()
    {
        print("嗨~");
        yield return new WaitForSeconds(1.5f);

    }
    */






    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "小名")
        {
            playerInArea = true;
            StartCoroutine(Dialog());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "小名")
        {
            playerInArea = false;
            StopDialog();

        }
    }

    /// <summary>
    /// 停止對話
    /// </summary>
        private void StopDialog()
        {
            dialog.SetActive(false);
            StopAllCoroutines();
        }



    /// <summary>
    /// 開始對話
    /// </summary>
    private IEnumerator Dialog()
    {
        /**print(data.dialougA);
        //print(data.dialougA[0]);
        //for (int i = 0; i < 100; i++)
        //{
        //    print("我是迴圈:" + i);
        //}
        */
        dialog.SetActive(true);
        textcontent.text = "";

        textname.text = name;

        string dialogstring = data.dialougB;

        switch (state)
        {
            case NPCState.FirstDialog:
                dialogstring = data.dialougA;
                break;
            case NPCState.Missioning:
                dialogstring = data.dialougB;
                break;
            case NPCState.Finish:
                dialogstring = data.dialougC;
                break;
         
        }

        for (int i = 0; i < dialogstring.Length; i++)
        {
            //print(data.dialougA[i]);
            textcontent.text += dialogstring[i] + "";
            yield return new WaitForSeconds(interval);
        }
    }
}
