using System.IO;
using UnityEngine;

public class DataMainManager : MonoBehaviour
{

    public string userName;
    public int highScore;

    public static DataMainManager Instance;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        loadUserInfo();
    }




    // Update is called once per frame
    void Update()
    {
        
    }


    [System.Serializable]
    class userInfo
    {
        public string name;
        public int highScore;

    }

    public void saveUserInfo()
    {
        userInfo data = new userInfo();
        data.name = userName;
        data.highScore = highScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void loadUserInfo()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            userInfo data = JsonUtility.FromJson<userInfo>(json);

            userName = data.name;
            highScore = data.highScore;

        }
    }
}
