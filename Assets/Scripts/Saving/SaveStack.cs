using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using System.Text;

public class SaveStack : MonoBehaviour
{
    public static SaveStack instance;

    public InputField FileName = null;
    public List<GameObject> savables = new List<GameObject>();

    private void Start()
    {
        instance = this;
    }

    public void SaveFile()
    {
        if (FileName)
        {
            if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/" + FileName.text + ".AsteriaQuest"))
            {
                // Create the file.
                using (FileStream fs = File.Create(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/" + FileName.text + ".AsteriaQuest"))
                {
                    Byte[] info =
                        new UTF8Encoding(true).GetBytes("");

                    // Add some information to the file.
                    fs.Write(info, 0, info.Length);
                }

                Debug.Log(FileName.text + ".AsteriaQuest" + " was created on the desktop.");
            }

            string parsedSave = "";

            for(int i = 0; i < savables.Count; i++)
            {
                DialogueNode dialogueNode = savables[i].GetComponent<DialogueNode>();
                EveryDeityNode everyDeityNode = savables[i].GetComponent<EveryDeityNode>();
                GemNode gemNode = savables[i].GetComponent<GemNode>();
                GoldNode goldNode = savables[i].GetComponent<GoldNode>();
                HealDamageNode healDamageNode = savables[i].GetComponent<HealDamageNode>();
                IfElseDeity ifElseDeity = savables[i].GetComponent<IfElseDeity>();
                LootDropNode lootDropNode = savables[i].GetComponent<LootDropNode>();
                LoreDropNode loreDropNode = savables[i].GetComponent<LoreDropNode>();
                MultilootNode multilootNode = savables[i].GetComponent<MultilootNode>();
                QuestTitle questTitle = savables[i].GetComponent<QuestTitle>();
                XPNode xPNode = savables[i].GetComponent<XPNode>();

                if (dialogueNode)
                {
                    parsedSave += "DialogueNodeÆ" + dialogueNode.transform.position.x + "" + dialogueNode.transform.position.y + "Æ" + dialogueNode.transform.position.z + "Æ" + dialogueNode.inputText.text + "Æ" + dialogueNode.inputLinkText.text + Environment.NewLine;
                }
                else if (everyDeityNode)
                {
                    parsedSave += "EDeityNodeÆ" + everyDeityNode.transform.position.x + "Æ" + everyDeityNode.transform.position.y + "Æ" + everyDeityNode.transform.position.z + Environment.NewLine;
                }
                else if (gemNode)
                {
                    parsedSave += "GemNodeÆ" + gemNode.transform.position.x + "Æ" + gemNode.transform.position.y + "Æ" + gemNode.transform.position.z + "Æ" + gemNode.inputMin.text + "Æ" + gemNode.inputMax.text + Environment.NewLine;
                }
                else if (goldNode)
                {
                    parsedSave += "GoldNodeÆ" + goldNode.transform.position.x + "Æ" + goldNode.transform.position.y + "Æ" + goldNode.transform.position.z + "Æ" + goldNode.inputMin.text + "Æ" + goldNode.inputMax.text + Environment.NewLine;
                }
                else if (healDamageNode)
                {
                    parsedSave += "HealDamageNodeÆ" + healDamageNode.transform.position.x + "Æ" + healDamageNode.transform.position.y + "Æ" + healDamageNode.transform.position.z + "Æ" + healDamageNode.type.value + "Æ" + healDamageNode.inputMin.text + "Æ" + healDamageNode.inputMax.text + Environment.NewLine;
                }
                else if (ifElseDeity)
                {
                    parsedSave += "IfDeityNodeÆ" + ifElseDeity.transform.position.x + "Æ" + ifElseDeity.transform.position.y + "Æ" + ifElseDeity.transform.position.z + "Æ" + ifElseDeity.type.value + Environment.NewLine;
                }
                else if (lootDropNode)
                {
                    parsedSave += "LootDropNodeÆ" + lootDropNode.transform.position.x + "Æ" + lootDropNode.transform.position.y + "Æ" + lootDropNode.transform.position.z + "Æ" + lootDropNode.type.value + "Æ" + lootDropNode.rarityMin.value + "Æ" + lootDropNode.rarityMax.value + Environment.NewLine;
                }
                else if (loreDropNode)
                {
                    parsedSave += "LoreDropNodeÆ" + loreDropNode.transform.position.x + "Æ" + loreDropNode.transform.position.y + "Æ" + loreDropNode.transform.position.z + "Æ" + loreDropNode.inputText.text + "Æ" + loreDropNode.inputLinkText.text + Environment.NewLine;
                }
                else if (multilootNode)
                {
                    parsedSave += "MultilootNodeÆ" + multilootNode.transform.position.x + "Æ" + multilootNode.transform.position.y + "Æ" + multilootNode.transform.position.z + "Æ" + multilootNode.inputField.text + Environment.NewLine;
                }
                else if (questTitle)
                {
                    parsedSave += "QuestTitleNodeÆ" + questTitle.transform.position.x + "Æ" + questTitle.transform.position.y + "Æ" + questTitle.transform.position.z + "Æ" + questTitle.inputField.text + Environment.NewLine;
                }
                else if (xPNode)
                {
                    parsedSave += "XPNodeÆ" + xPNode.transform.position.x + "Æ" + xPNode.transform.position.y + "Æ" + xPNode.transform.position.z + "Æ" + xPNode.type.value + "Æ" + xPNode.inputMin.text + "Æ" + xPNode.inputMax.text + Environment.NewLine;
                }
                else Debug.LogError("Problem saving " + savables[i].gameObject.name);
            }

            Debug.Log(FileName.text + ".AsteriaQuest" + " saved to the Desktop.");

            // Open the stream and read it back.
            File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/" + FileName.text + ".AsteriaQuest", parsedSave);
        }
    }

    public void ReadFile()
    {
        if (FileName)
        {
            if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/" + FileName.text + ".AsteriaQuest"))
            {
                // Create the file.
                using (FileStream fs = File.Create(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/" + FileName.text + ".AsteriaQuest"))
                {
                    Byte[] info =
                        new UTF8Encoding(true).GetBytes("");

                    // Add some information to the file.
                    fs.Write(info, 0, info.Length);
                }
            }

            // Open the stream and read it back.
            using (StreamReader sr = File.OpenText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/" + FileName.text + ".AsteriaQuest"))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    ulong input;
                    bool didParse = ulong.TryParse(s, out input);
                }
            }

            Debug.Log(FileName.text + ".AsteriaQuest" + " was loaded.");
        }
    }
}