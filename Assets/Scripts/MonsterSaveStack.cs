using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using System.Text;

public class MonsterSaveStack : MonoBehaviour
{
    public static MonsterSaveStack instance;

    public InputField FileName = null;
    public List<GameObject> savables = new List<GameObject>();

    public GameObject monster;
    public GameObject title;

    private void Start()
    {
        instance = this;
    }

    public void ClearAllNodes()
    {
        for (int i = 0; i < instance.savables.Count; i++)
        {
            Destroy(instance.savables[i]);
        }

        instance.savables = new List<GameObject>();
    }

    public void SaveFile()
    {
        if (FileName)
        {
            if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/" + FileName.text + ".AsteriaMonsters"))
            {
                // Create the file.
                using (FileStream fs = File.Create(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/" + FileName.text + ".AsteriaMonsters"))
                {
                    byte[] info =
                        new UTF8Encoding(true).GetBytes("");

                    // Add some information to the file.
                    fs.Write(info, 0, info.Length);
                }

                Debug.Log(FileName.text + ".AsteriaMonsters" + " was created on the desktop.");
            }

            string parsedSave = "";

            //Save tile data.
            for (int i = 0; i < savables.Count; i++)
            {
                Monster monsterNode = savables[i].GetComponent<Monster>();
                AreaTitle areaTitleNode = savables[i].GetComponent<AreaTitle>();

                ID _id = savables[i].GetComponent<ID>();

                if (monsterNode)
                {
                    parsedSave += "MonsterÆ" + _id.iD + "Æ" + monsterNode.transform.position.x + "Æ" + monsterNode.transform.position.y + "Æ" + monsterNode.transform.position.z + "Æ" + monsterNode.input_Name.text + "Æ" + monsterNode.input_LevelMin.text + "Æ" + monsterNode.input_LevelMax.text + "Æ" + monsterNode.input_Difficulty.text + "Æ" + monsterNode.input_Tankiness.text + "Æ" + monsterNode.input_Flavor.text + "Æ" + monsterNode.input_Icon.text + Environment.NewLine;
                }
                else if (areaTitleNode)
                {
                    parsedSave += "TitleÆ" + _id.iD + "Æ" + areaTitleNode.transform.position.x + "Æ" + areaTitleNode.transform.position.y + "Æ" + areaTitleNode.transform.position.z + "Æ" + areaTitleNode.input_Name.text + Environment.NewLine;
                }
                else Debug.LogError("Problem saving " + savables[i].gameObject.name);
            }

            Debug.Log(FileName.text + ".AsteriaMonsters" + " saved to the Desktop.");

            // Open the stream and read it back.
            File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/" + FileName.text + ".AsteriaMonsters", parsedSave);
        }
    }

    public void ReadFile()
    {
        for (int i = 0; i < instance.savables.Count; i++)
        {
            Destroy(instance.savables[i]);
        }

        instance.savables = new List<GameObject>();

        if (FileName)
        {
            if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/" + FileName.text + ".AsteriaMonsters"))
            {
                // Create the file.
                using (FileStream fs = File.Create(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/" + FileName.text + ".AsteriaMonsters"))
                {
                    Byte[] info =
                        new UTF8Encoding(true).GetBytes("");

                    // Add some information to the file.
                    fs.Write(info, 0, info.Length);
                }
            }

            // Open the stream and read it back.
            using (StreamReader sr = File.OpenText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/" + FileName.text + ".AsteriaMonsters"))
            {
                string s = "";

                while ((s = sr.ReadLine()) != null)
                {
                    string[] temp = s.Split('Æ');

                    Vector3 pos = Vector3.zero;

                    float x = 0f;
                    float y = 0f;
                    float z = 0f;

                    bool parseX = float.TryParse(temp[2], out x);
                    bool parseY = float.TryParse(temp[3], out y);
                    bool parseZ = float.TryParse(temp[4], out z);

                    if (parseX && parseY && parseZ)
                        pos = new Vector3(x, y, z);
                    else
                    {
                        Debug.Log(temp[1] + ", " + temp[2] + ", " + temp[3]);
                        Debug.LogError("Failed to parse transform position of " + temp[0]);
                        continue;
                    }

                    if (temp[0] == "Monster")
                    {
                        Monster d = Instantiate(monster, pos, Quaternion.identity).GetComponent<Monster>();

                        d.input_Name.text = temp[5];
                        d.input_LevelMin.text = temp[6];
                        d.input_LevelMax.text  = temp[7];
                        d.input_Difficulty.text = temp[8];
                        d.input_Tankiness.text = temp[9];
                        d.input_Flavor.text = temp[10];
                        d.input_Icon.text = temp[11];

                        d.downloader.Download();

                        ulong parsedID = 0;
                        bool parsed = ulong.TryParse(temp[1], out parsedID);

                        if (parsed)
                            d.gameObject.GetComponent<ID>().iD = parsedID;
                        else Debug.LogError("Failed to parse ID on " + d.gameObject.name);
                    }
                    else if (temp[0] == "Title")
                    {
                        AreaTitle d = Instantiate(title, pos, Quaternion.identity).GetComponent<AreaTitle>();
                        d.input_Name.text = temp[5];

                        ulong parsedID = 0;
                        bool parsed = ulong.TryParse(temp[1], out parsedID);

                        if (parsed)
                            d.gameObject.GetComponent<ID>().iD = parsedID;
                        else Debug.LogError("Failed to parse ID on " + d.gameObject.name);
                    }
                }
            }

            Debug.Log(FileName.text + ".AsteriaMonsters" + " was loaded.");
        }
    }

    public static ulong GenerateID()
    {
        bool keyGenerated = false;
        ulong newKey = 0;
        System.Random random = new System.Random();

        while (!keyGenerated)
        {
            char[] gen = new char[18];

            for (int i = 0; i < 18; i++)
                gen[i] = random.Next(0, 10).ToString().ToCharArray()[0];

            string _parser = "";

            for (int i = 0; i < 18; i++)
            {
                _parser += gen[i];
            }

            bool failed = false;

            failed = !ulong.TryParse(_parser, out newKey);

            if (!failed)
            {
                bool isValid = true;

                for (int i = 0; i < instance.savables.Count; i++)
                {
                    if (instance.savables[i].GetComponent<ID>().iD == newKey)
                    {
                        isValid = false;
                        break;
                    }
                }

                if (isValid)
                {
                    keyGenerated = true;
                }
            }
        }

        return newKey;
    }
}