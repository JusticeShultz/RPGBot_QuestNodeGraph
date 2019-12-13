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

    public GameObject dialogue;
    public GameObject eDeity;
    public GameObject gem;
    public GameObject gold;
    public GameObject healD;
    public GameObject ifElse;
    public GameObject lootDrop;
    public GameObject loreDrop;
    public GameObject multiLoot;
    public GameObject qTitle;
    public GameObject xP;

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
            if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/" + FileName.text + ".AsteriaQuest"))
            {
                // Create the file.
                using (FileStream fs = File.Create(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/" + FileName.text + ".AsteriaQuest"))
                {
                    byte[] info =
                        new UTF8Encoding(true).GetBytes("");

                    // Add some information to the file.
                    fs.Write(info, 0, info.Length);
                }

                Debug.Log(FileName.text + ".AsteriaQuest" + " was created on the desktop.");
            }

            string parsedSave = "";

            //Save tile data.
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

                ID _id = savables[i].GetComponent<ID>();

                if (dialogueNode)
                {
                    parsedSave += "DialogueNodeÆ" + _id.iD + "Æ" + dialogueNode.transform.position.x + "Æ" + dialogueNode.transform.position.y + "Æ" + dialogueNode.transform.position.z + "Æ" + dialogueNode.inputText.text + "Æ" + dialogueNode.inputLinkText.text + Environment.NewLine;
                }
                else if (everyDeityNode)
                {
                    parsedSave += "EDeityNodeÆ" + _id.iD + "Æ" + everyDeityNode.transform.position.x + "Æ" + everyDeityNode.transform.position.y + "Æ" + everyDeityNode.transform.position.z + Environment.NewLine;
                }
                else if (gemNode)
                {
                    parsedSave += "GemNodeÆ" + _id.iD + "Æ" + gemNode.transform.position.x + "Æ" + gemNode.transform.position.y + "Æ" + gemNode.transform.position.z + "Æ" + gemNode.inputMin.text + "Æ" + gemNode.inputMax.text + Environment.NewLine;
                }
                else if (goldNode)
                {
                    parsedSave += "GoldNodeÆ" + _id.iD + "Æ" + goldNode.transform.position.x + "Æ" + goldNode.transform.position.y + "Æ" + goldNode.transform.position.z + "Æ" + goldNode.inputMin.text + "Æ" + goldNode.inputMax.text + Environment.NewLine;
                }
                else if (healDamageNode)
                {
                    parsedSave += "HealDamageNodeÆ" + _id.iD + "Æ" + healDamageNode.transform.position.x + "Æ" + healDamageNode.transform.position.y + "Æ" + healDamageNode.transform.position.z + "Æ" + healDamageNode.type.value + "Æ" + healDamageNode.inputMin.text + "Æ" + healDamageNode.inputMax.text + Environment.NewLine;
                }
                else if (ifElseDeity)
                {
                    parsedSave += "IfDeityNodeÆ" + _id.iD + "Æ" + ifElseDeity.transform.position.x + "Æ" + ifElseDeity.transform.position.y + "Æ" + ifElseDeity.transform.position.z + "Æ" + ifElseDeity.type.value + Environment.NewLine;
                }
                else if (lootDropNode)
                {
                    parsedSave += "LootDropNodeÆ" + _id.iD + "Æ" + lootDropNode.transform.position.x + "Æ" + lootDropNode.transform.position.y + "Æ" + lootDropNode.transform.position.z + "Æ" + lootDropNode.type.value + "Æ" + lootDropNode.rarityMin.value + "Æ" + lootDropNode.rarityMax.value + Environment.NewLine;
                }
                else if (loreDropNode)
                {
                    parsedSave += "LoreDropNodeÆ" + _id.iD + "Æ" + loreDropNode.transform.position.x + "Æ" + loreDropNode.transform.position.y + "Æ" + loreDropNode.transform.position.z + "Æ" + loreDropNode.inputText.text + "Æ" + loreDropNode.inputLinkText.text + Environment.NewLine;
                }
                else if (multilootNode)
                {
                    parsedSave += "MultilootNodeÆ" + _id.iD + "Æ" + multilootNode.transform.position.x + "Æ" + multilootNode.transform.position.y + "Æ" + multilootNode.transform.position.z + "Æ" + multilootNode.inputField.text + Environment.NewLine;
                }
                else if (questTitle)
                {
                    parsedSave += "QuestTitleNodeÆ" + _id.iD + "Æ" + questTitle.transform.position.x + "Æ" + questTitle.transform.position.y + "Æ" + questTitle.transform.position.z + "Æ" + questTitle.inputField.text + Environment.NewLine;
                }
                else if (xPNode)
                {
                    parsedSave += "XPNodeÆ" + _id.iD + "Æ" + xPNode.transform.position.x + "Æ" + xPNode.transform.position.y + "Æ" + xPNode.transform.position.z + "Æ" + xPNode.type.value + "Æ" + xPNode.inputMin.text + "Æ" + xPNode.inputMax.text + Environment.NewLine;
                }
                else Debug.LogError("Problem saving " + savables[i].gameObject.name);
            }

            //Save node data.
            for (int i = 0; i < savables.Count; i++)
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

                ID _id = savables[i].GetComponent<ID>();

                if (dialogueNode)
                {
                    if(dialogueNode.inputNode.link != null)
                        parsedSave += "NodeÆDialogueÆ" + _id.iD + "Æ" + dialogueNode.inputNode.name + "Æ" + dialogueNode.inputNode.link.transform.root.gameObject.GetComponent<ID>().iD + "Æ" + dialogueNode.inputNode.link.transform.name + Environment.NewLine;

                    if (dialogueNode.outputLootNode.link != null)
                        parsedSave += "NodeÆDialogueÆ" + _id.iD + "Æ" + dialogueNode.outputLootNode.name + "Æ" + dialogueNode.outputLootNode.link.transform.root.gameObject.GetComponent<ID>().iD + "Æ" + dialogueNode.outputLootNode.link.transform.name + Environment.NewLine;

                    if (dialogueNode.outputNode1.link != null)
                        parsedSave += "NodeÆDialogueÆ" + _id.iD + "Æ" + dialogueNode.outputNode1.name + "Æ" + dialogueNode.outputNode1.link.transform.root.gameObject.GetComponent<ID>().iD + "Æ" + dialogueNode.outputNode1.link.transform.name + Environment.NewLine;

                    if (dialogueNode.outputNode2.link != null)
                        parsedSave += "NodeÆDialogueÆ" + _id.iD + "Æ" + dialogueNode.outputNode2.name + "Æ" + dialogueNode.outputNode2.link.transform.root.gameObject.GetComponent<ID>().iD + "Æ" + dialogueNode.outputNode2.link.transform.name + Environment.NewLine;

                    if (dialogueNode.outputNode3.link != null)
                        parsedSave += "NodeÆDialogueÆ" + _id.iD + "Æ" + dialogueNode.outputNode3.name + "Æ" + dialogueNode.outputNode3.link.transform.root.gameObject.GetComponent<ID>().iD + "Æ" + dialogueNode.outputNode3.link.transform.name + Environment.NewLine;
                }
                else if (everyDeityNode)
                {
                    if (everyDeityNode.inputNode.link != null)
                        parsedSave += "NodeÆEveryDeityÆ" + _id.iD + "Æ" + everyDeityNode.inputNode.name + "Æ" + everyDeityNode.inputNode.link.transform.root.gameObject.GetComponent<ID>().iD + "Æ" + everyDeityNode.inputNode.link.transform.name + Environment.NewLine;

                    if (everyDeityNode.outputNode1.link != null)
                        parsedSave += "NodeÆEveryDeityÆ" + _id.iD + "Æ" + everyDeityNode.outputNode1.name + "Æ" + everyDeityNode.outputNode1.link.transform.root.gameObject.GetComponent<ID>().iD + "Æ" + everyDeityNode.outputNode1.link.transform.name + Environment.NewLine;

                    if (everyDeityNode.outputNode2.link != null)
                        parsedSave += "NodeÆEveryDeityÆ" + _id.iD + "Æ" + everyDeityNode.outputNode2.name + "Æ" + everyDeityNode.outputNode2.link.transform.root.gameObject.GetComponent<ID>().iD + "Æ" + everyDeityNode.outputNode2.link.transform.name + Environment.NewLine;

                    if (everyDeityNode.outputNode3.link != null)
                        parsedSave += "NodeÆEveryDeityÆ" + _id.iD + "Æ" + everyDeityNode.outputNode3.name + "Æ" + everyDeityNode.outputNode3.link.transform.root.gameObject.GetComponent<ID>().iD + "Æ" + everyDeityNode.outputNode3.link.transform.name + Environment.NewLine;

                    if (everyDeityNode.outputNode4.link != null)
                        parsedSave += "NodeÆEveryDeityÆ" + _id.iD + "Æ" + everyDeityNode.outputNode4.name + "Æ" + everyDeityNode.outputNode4.link.transform.root.gameObject.GetComponent<ID>().iD + "Æ" + everyDeityNode.outputNode4.link.transform.name + Environment.NewLine;

                    if (everyDeityNode.outputNode5.link != null)
                        parsedSave += "NodeÆEveryDeityÆ" + _id.iD + "Æ" + everyDeityNode.outputNode5.name + "Æ" + everyDeityNode.outputNode5.link.transform.root.gameObject.GetComponent<ID>().iD + "Æ" + everyDeityNode.outputNode5.link.transform.name + Environment.NewLine;

                    if (everyDeityNode.outputNode6.link != null)
                        parsedSave += "NodeÆEveryDeityÆ" + _id.iD + "Æ" + everyDeityNode.outputNode6.name + "Æ" + everyDeityNode.outputNode6.link.transform.root.gameObject.GetComponent<ID>().iD + "Æ" + everyDeityNode.outputNode6.link.transform.name + Environment.NewLine;

                    if (everyDeityNode.outputNode7.link != null)
                        parsedSave += "NodeÆEveryDeityÆ" + _id.iD + "Æ" + everyDeityNode.outputNode7.name + "Æ" + everyDeityNode.outputNode7.link.transform.root.gameObject.GetComponent<ID>().iD + "Æ" + everyDeityNode.outputNode7.link.transform.name + Environment.NewLine;

                    if (everyDeityNode.outputNode8.link != null)
                        parsedSave += "NodeÆEveryDeityÆ" + _id.iD + "Æ" + everyDeityNode.outputNode8.name + "Æ" + everyDeityNode.outputNode8.link.transform.root.gameObject.GetComponent<ID>().iD + "Æ" + everyDeityNode.outputNode8.link.transform.name + Environment.NewLine;
                }
                else if (gemNode)
                {
                    if (gemNode.inputNode.link != null)
                        parsedSave += "NodeÆGemÆ" + _id.iD + "Æ" + gemNode.inputNode.name + "Æ" + gemNode.inputNode.link.transform.root.gameObject.GetComponent<ID>().iD + "Æ" + gemNode.inputNode.link.transform.name + Environment.NewLine;
                }
                else if (goldNode)
                {
                    if (goldNode.inputNode.link != null)
                        parsedSave += "NodeÆGoldÆ" + _id.iD + "Æ" + goldNode.inputNode.name + "Æ" + goldNode.inputNode.link.transform.root.gameObject.GetComponent<ID>().iD + "Æ" + goldNode.inputNode.link.transform.name + Environment.NewLine;
                }
                else if (healDamageNode)
                {
                    if (healDamageNode.inputNode.link != null)
                        parsedSave += "NodeÆHealDamageÆ" + _id.iD + "Æ" + healDamageNode.inputNode.name + "Æ" + healDamageNode.inputNode.link.transform.root.gameObject.GetComponent<ID>().iD + "Æ" + healDamageNode.inputNode.link.transform.name + Environment.NewLine;
                }
                else if (ifElseDeity)
                {
                    if (ifElseDeity.inputNode.link != null)
                        parsedSave += "NodeÆIfElseÆ" + _id.iD + "Æ" + ifElseDeity.inputNode.name + "Æ" + ifElseDeity.inputNode.link.transform.root.gameObject.GetComponent<ID>().iD + "Æ" + ifElseDeity.inputNode.link.transform.name + Environment.NewLine;

                    if (ifElseDeity.outputTrue.link != null)
                        parsedSave += "NodeÆIfElseÆ" + _id.iD + "Æ" + ifElseDeity.outputTrue.name + "Æ" + ifElseDeity.outputTrue.link.transform.root.gameObject.GetComponent<ID>().iD + "Æ" + ifElseDeity.outputTrue.link.transform.name + Environment.NewLine;

                    if (ifElseDeity.outputFalse.link != null)
                        parsedSave += "NodeÆIfElseÆ" + _id.iD + "Æ" + ifElseDeity.outputFalse.name + "Æ" + ifElseDeity.outputFalse.link.transform.root.gameObject.GetComponent<ID>().iD + "Æ" + ifElseDeity.outputFalse.link.transform.name + Environment.NewLine;
                }
                else if (lootDropNode)
                {
                    if (lootDropNode.inputNode.link != null)
                        parsedSave += "NodeÆLootDropÆ" + _id.iD + "Æ" + lootDropNode.inputNode.name + "Æ" + lootDropNode.inputNode.link.transform.root.gameObject.GetComponent<ID>().iD + "Æ" + lootDropNode.inputNode.link.transform.name + Environment.NewLine;
                }
                else if (loreDropNode)
                {
                    if (loreDropNode.inputNode.link != null)
                        parsedSave += "NodeÆLoreDropÆ" + _id.iD + "Æ" + loreDropNode.inputNode.name + "Æ" + loreDropNode.inputNode.link.transform.root.gameObject.GetComponent<ID>().iD + "Æ" + loreDropNode.inputNode.link.transform.name + Environment.NewLine;

                    if (loreDropNode.outputNode1.link != null)
                        parsedSave += "NodeÆLoreDropÆ" + _id.iD + "Æ" + loreDropNode.outputNode1.name + "Æ" + loreDropNode.outputNode1.link.transform.root.gameObject.GetComponent<ID>().iD + "Æ" + loreDropNode.outputNode1.link.transform.name + Environment.NewLine;
                }
                else if (multilootNode)
                {
                    if (multilootNode.inputNode.link != null)
                        parsedSave += "NodeÆMultiLootÆ" + _id.iD + "Æ" + multilootNode.inputNode.name + "Æ" + multilootNode.inputNode.link.transform.root.gameObject.GetComponent<ID>().iD + "Æ" + multilootNode.inputNode.link.transform.name + Environment.NewLine;

                    if (multilootNode.outputNode1.link != null)
                        parsedSave += "NodeÆMultiLootÆ" + _id.iD + "Æ" + multilootNode.outputNode1.name + "Æ" + multilootNode.outputNode1.link.transform.root.gameObject.GetComponent<ID>().iD + "Æ" + multilootNode.outputNode1.link.transform.name + Environment.NewLine;

                    if (multilootNode.outputNode2.link != null)
                        parsedSave += "NodeÆMultiLootÆ" + _id.iD + "Æ" + multilootNode.outputNode2.name + "Æ" + multilootNode.outputNode2.link.transform.root.gameObject.GetComponent<ID>().iD + "Æ" + multilootNode.outputNode2.link.transform.name + Environment.NewLine;

                    if (multilootNode.outputNode3.link != null)
                        parsedSave += "NodeÆMultiLootÆ" + _id.iD + "Æ" + multilootNode.outputNode3.name + "Æ" + multilootNode.outputNode3.link.transform.root.gameObject.GetComponent<ID>().iD + "Æ" + multilootNode.outputNode3.link.transform.name + Environment.NewLine;
                }
                else if (questTitle)
                {
                    if (questTitle.outputNode.link != null)
                        parsedSave += "NodeÆQuestTitleÆ" + _id.iD + "Æ" + questTitle.outputNode.name + "Æ" + questTitle.outputNode.link.transform.root.gameObject.GetComponent<ID>().iD + "Æ" + questTitle.outputNode.link.transform.name + Environment.NewLine;
                }
                else if (xPNode)
                {
                    if (xPNode.inputNode.link != null)
                        parsedSave += "NodeÆXPÆ" + _id.iD + "Æ" + xPNode.inputNode.name + "Æ" + xPNode.inputNode.link.transform.root.gameObject.GetComponent<ID>().iD + "Æ" + xPNode.inputNode.link.transform.name + Environment.NewLine;
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
        for(int i = 0; i < instance.savables.Count; i++)
        {
            Destroy(instance.savables[i]);
        }

        instance.savables = new List<GameObject>();

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
                    string[] temp = s.Split('Æ');

                    if (temp[0] == "Node")
                    {
                        ulong parsedID1 = 0;
                        bool parsed1 = ulong.TryParse(temp[2], out parsedID1);

                        ulong parsedID2 = 0;
                        bool parsed2 = ulong.TryParse(temp[4], out parsedID2);

                        Node them = null;

                        if (parsed1 && parsed2)
                        {
                            for (int i = 0; i < instance.savables.Count; i++)
                            {
                                if (instance.savables[i].GetComponent<ID>().iD == parsedID2)
                                {
                                    if (instance.savables[i].GetComponent<DialogueNode>() != null)
                                    {
                                        if (instance.savables[i].GetComponent<DialogueNode>().inputNode.name == temp[5])
                                        {
                                            them = instance.savables[i].GetComponent<DialogueNode>().inputNode;
                                        }

                                        if (instance.savables[i].GetComponent<DialogueNode>().outputLootNode.name == temp[5])
                                        {
                                            them = instance.savables[i].GetComponent<DialogueNode>().outputLootNode;
                                        }

                                        if (instance.savables[i].GetComponent<DialogueNode>().outputNode1.name == temp[5])
                                        {
                                            them = instance.savables[i].GetComponent<DialogueNode>().outputNode1;
                                        }

                                        if (instance.savables[i].GetComponent<DialogueNode>().outputNode2.name == temp[5])
                                        {
                                            them = instance.savables[i].GetComponent<DialogueNode>().outputNode2;
                                        }

                                        if (instance.savables[i].GetComponent<DialogueNode>().outputNode3.name == temp[5])
                                        {
                                            them = instance.savables[i].GetComponent<DialogueNode>().outputNode3;
                                        }
                                    }
                                    else if (instance.savables[i].GetComponent<EveryDeityNode>() != null)
                                    {
                                        if (instance.savables[i].GetComponent<EveryDeityNode>().inputNode.name == temp[5])
                                        {
                                            them = instance.savables[i].GetComponent<EveryDeityNode>().inputNode;
                                        }

                                        if (instance.savables[i].GetComponent<EveryDeityNode>().outputNode1.name == temp[5])
                                        {
                                            them = instance.savables[i].GetComponent<EveryDeityNode>().outputNode1;
                                        }

                                        if (instance.savables[i].GetComponent<EveryDeityNode>().outputNode2.name == temp[5])
                                        {
                                            them = instance.savables[i].GetComponent<EveryDeityNode>().outputNode2;
                                        }

                                        if (instance.savables[i].GetComponent<EveryDeityNode>().outputNode3.name == temp[5])
                                        {
                                            them = instance.savables[i].GetComponent<EveryDeityNode>().outputNode3;
                                        }

                                        if (instance.savables[i].GetComponent<EveryDeityNode>().outputNode4.name == temp[5])
                                        {
                                            them = instance.savables[i].GetComponent<EveryDeityNode>().outputNode4;
                                        }

                                        if (instance.savables[i].GetComponent<EveryDeityNode>().outputNode5.name == temp[5])
                                        {
                                            them = instance.savables[i].GetComponent<EveryDeityNode>().outputNode5;
                                        }

                                        if (instance.savables[i].GetComponent<EveryDeityNode>().outputNode6.name == temp[5])
                                        {
                                            them = instance.savables[i].GetComponent<EveryDeityNode>().outputNode6;
                                        }

                                        if (instance.savables[i].GetComponent<EveryDeityNode>().outputNode7.name == temp[5])
                                        {
                                            them = instance.savables[i].GetComponent<EveryDeityNode>().outputNode7;
                                        }

                                        if (instance.savables[i].GetComponent<EveryDeityNode>().outputNode8.name == temp[5])
                                        {
                                            them = instance.savables[i].GetComponent<EveryDeityNode>().outputNode8;
                                        }

                                        if (instance.savables[i].GetComponent<EveryDeityNode>().outputNode3.name == temp[5])
                                        {
                                            them = instance.savables[i].GetComponent<EveryDeityNode>().outputNode3;
                                        }
                                    }
                                    else if (instance.savables[i].GetComponent<GemNode>() != null)
                                    {
                                        if (instance.savables[i].GetComponent<GemNode>().inputNode.name == temp[5])
                                        {
                                            them = instance.savables[i].GetComponent<GemNode>().inputNode;
                                        }
                                    }
                                    else if (instance.savables[i].GetComponent<GoldNode>() != null)
                                    {
                                        if (instance.savables[i].GetComponent<GoldNode>().inputNode.name == temp[5])
                                        {
                                            them = instance.savables[i].GetComponent<GoldNode>().inputNode;
                                        }
                                    }
                                    else if (instance.savables[i].GetComponent<HealDamageNode>() != null)
                                    {
                                        if (instance.savables[i].GetComponent<HealDamageNode>().inputNode.name == temp[5])
                                        {
                                            them = instance.savables[i].GetComponent<HealDamageNode>().inputNode;
                                        }
                                    }
                                    else if (instance.savables[i].GetComponent<IfElseDeity>() != null)
                                    {
                                        if (instance.savables[i].GetComponent<IfElseDeity>().inputNode.name == temp[5])
                                        {
                                            them = instance.savables[i].GetComponent<IfElseDeity>().inputNode;
                                        }

                                        if (instance.savables[i].GetComponent<IfElseDeity>().outputTrue.name == temp[5])
                                        {
                                            them = instance.savables[i].GetComponent<IfElseDeity>().outputTrue;
                                        }

                                        if (instance.savables[i].GetComponent<IfElseDeity>().outputFalse.name == temp[5])
                                        {
                                            them = instance.savables[i].GetComponent<IfElseDeity>().outputFalse;
                                        }
                                    }
                                    else if (instance.savables[i].GetComponent<LootDropNode>() != null)
                                    {
                                        if (instance.savables[i].GetComponent<LootDropNode>().inputNode.name == temp[5])
                                        {
                                            them = instance.savables[i].GetComponent<LootDropNode>().inputNode;
                                        }
                                    }
                                    else if (instance.savables[i].GetComponent<LoreDropNode>() != null)
                                    {
                                        if (instance.savables[i].GetComponent<LoreDropNode>().inputNode.name == temp[5])
                                        {
                                            them = instance.savables[i].GetComponent<LoreDropNode>().inputNode;
                                        }

                                        if (instance.savables[i].GetComponent<LoreDropNode>().outputNode1.name == temp[5])
                                        {
                                            them = instance.savables[i].GetComponent<LoreDropNode>().outputNode1;
                                        }
                                    }
                                    else if (instance.savables[i].GetComponent<MultilootNode>() != null)
                                    {
                                        if (instance.savables[i].GetComponent<MultilootNode>().inputNode.name == temp[5])
                                        {
                                            them = instance.savables[i].GetComponent<MultilootNode>().inputNode;
                                        }

                                        if (instance.savables[i].GetComponent<MultilootNode>().outputNode1.name == temp[5])
                                        {
                                            them = instance.savables[i].GetComponent<MultilootNode>().outputNode1;
                                        }

                                        if (instance.savables[i].GetComponent<MultilootNode>().outputNode2.name == temp[5])
                                        {
                                            them = instance.savables[i].GetComponent<MultilootNode>().outputNode2;
                                        }

                                        if (instance.savables[i].GetComponent<MultilootNode>().outputNode3.name == temp[5])
                                        {
                                            them = instance.savables[i].GetComponent<MultilootNode>().outputNode3;
                                        }
                                    }
                                    else if (instance.savables[i].GetComponent<QuestTitle>() != null)
                                    {
                                        if (instance.savables[i].GetComponent<QuestTitle>().outputNode.name == temp[5])
                                        {
                                            them = instance.savables[i].GetComponent<QuestTitle>().outputNode;
                                        }
                                    }
                                    else if (instance.savables[i].GetComponent<XPNode>() != null)
                                    {
                                        if (instance.savables[i].GetComponent<XPNode>().inputNode.name == temp[5])
                                        {
                                            them = instance.savables[i].GetComponent<XPNode>().inputNode;
                                        }
                                    }
                                }
                            }

                            if (them == null)
                            {
                                Debug.LogError("Failed to find a connection for Node A");
                                continue;
                            }

                            for (int i = 0; i < instance.savables.Count; i++)
                            {
                                if (instance.savables[i].GetComponent<ID>().iD == parsedID1)
                                {
                                    if (temp[1] == "Dialogue")
                                    {
                                        DialogueNode dialogue = instance.savables[i].GetComponent<DialogueNode>();

                                        if (dialogue.inputNode.name == temp[3]) dialogue.inputNode.link = them.gameObject;
                                        else if (dialogue.outputLootNode.name == temp[3]) dialogue.outputLootNode.link = them.gameObject;
                                        else if (dialogue.outputNode1.name == temp[3]) dialogue.outputNode1.link = them.gameObject;
                                        else if (dialogue.outputNode2.name == temp[3]) dialogue.outputNode2.link = them.gameObject;
                                        else if (dialogue.outputNode3.name == temp[3]) dialogue.outputNode3.link = them.gameObject;
                                    }
                                    else if (temp[1] == "EveryDeity")
                                    {
                                        EveryDeityNode t = instance.savables[i].GetComponent<EveryDeityNode>();

                                        if (t.inputNode.name == temp[3]) t.inputNode.link = them.gameObject;
                                        else if (t.outputNode1.name == temp[3]) t.outputNode1.link = them.gameObject;
                                        else if (t.outputNode2.name == temp[3]) t.outputNode2.link = them.gameObject;
                                        else if (t.outputNode3.name == temp[3]) t.outputNode3.link = them.gameObject;
                                        else if (t.outputNode4.name == temp[3]) t.outputNode4.link = them.gameObject;
                                        else if (t.outputNode5.name == temp[3]) t.outputNode5.link = them.gameObject;
                                        else if (t.outputNode6.name == temp[3]) t.outputNode6.link = them.gameObject;
                                        else if (t.outputNode7.name == temp[3]) t.outputNode7.link = them.gameObject;
                                        else if (t.outputNode8.name == temp[3]) t.outputNode8.link = them.gameObject;
                                    }
                                    else if (temp[1] == "Gem")
                                    {
                                        GemNode t = instance.savables[i].GetComponent<GemNode>();

                                        if (t.inputNode.name == temp[3]) t.inputNode.link = them.gameObject;
                                    }
                                    else if (temp[1] == "Gold")
                                    {
                                        GoldNode t = instance.savables[i].GetComponent<GoldNode>();

                                        if (t.inputNode.name == temp[3]) t.inputNode.link = them.gameObject;
                                    }
                                    else if (temp[1] == "HealDamage")
                                    {
                                        HealDamageNode t = instance.savables[i].GetComponent<HealDamageNode>();

                                        if (t.inputNode.name == temp[3]) t.inputNode.link = them.gameObject;
                                    }
                                    else if (temp[1] == "IfElse")
                                    {
                                        IfElseDeity t = instance.savables[i].GetComponent<IfElseDeity>();

                                        if (t.inputNode.name == temp[3]) t.inputNode.link = them.gameObject;
                                        if (t.outputTrue.name == temp[3]) t.outputTrue.link = them.gameObject;
                                        if (t.outputFalse.name == temp[3]) t.outputFalse.link = them.gameObject;
                                    }
                                    else if (temp[1] == "LootDrop")
                                    {
                                        LootDropNode t = instance.savables[i].GetComponent<LootDropNode>();

                                        if (t.inputNode.name == temp[3]) t.inputNode.link = them.gameObject;
                                    }
                                    else if (temp[1] == "LoreDrop")
                                    {
                                        LoreDropNode t = instance.savables[i].GetComponent<LoreDropNode>();

                                        if (t.inputNode.name == temp[3]) t.inputNode.link = them.gameObject;
                                        if (t.outputNode1.name == temp[3]) t.outputNode1.link = them.gameObject;
                                    }
                                    else if (temp[1] == "MultiLoot")
                                    {
                                        MultilootNode t = instance.savables[i].GetComponent<MultilootNode>();

                                        if (t.inputNode.name == temp[3]) t.inputNode.link = them.gameObject;
                                        if (t.outputNode1.name == temp[3]) t.outputNode1.link = them.gameObject;
                                        if (t.outputNode2.name == temp[3]) t.outputNode2.link = them.gameObject;
                                        if (t.outputNode3.name == temp[3]) t.outputNode3.link = them.gameObject;
                                    }
                                    else if (temp[1] == "QuestTitle")
                                    {
                                        QuestTitle t = instance.savables[i].GetComponent<QuestTitle>();

                                        if (t.outputNode.name == temp[3]) t.outputNode.link = them.gameObject;
                                    }
                                    else if (temp[1] == "XP")
                                    {
                                        XPNode t = instance.savables[i].GetComponent<XPNode>();

                                        if (t.inputNode.name == temp[3]) t.inputNode.link = them.gameObject;
                                    }
                                    else
                                    {
                                        Debug.LogError("There was a problem loading a node.");
                                    }

                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
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

                        if (temp[0] == "DialogueNode")
                        {
                            DialogueNode d = Instantiate(dialogue, pos, Quaternion.identity).GetComponent<DialogueNode>();
                            d.inputText.text = temp[5];
                            d.inputLinkText.text = temp[6];

                            ulong parsedID = 0;
                            bool parsed = ulong.TryParse(temp[1], out parsedID);

                            if (parsed)
                                d.gameObject.GetComponent<ID>().iD = parsedID;
                            else Debug.LogError("Failed to parse ID on " + d.gameObject.name);
                        }
                        else if (temp[0] == "EDeityNode")
                        {
                            GameObject d = Instantiate(eDeity, pos, Quaternion.identity);

                            ulong parsedID = 0;
                            bool parsed = ulong.TryParse(temp[1], out parsedID);

                            if (parsed)
                                d.GetComponent<ID>().iD = parsedID;
                            else Debug.LogError("Failed to parse ID on " + d.gameObject.name);
                        }
                        else if (temp[0] == "GemNode")
                        {
                            GemNode d = Instantiate(gem, pos, Quaternion.identity).GetComponent<GemNode>();
                            d.inputMin.text = temp[5];
                            d.inputMax.text = temp[6];

                            ulong parsedID = 0;
                            bool parsed = ulong.TryParse(temp[1], out parsedID);

                            if (parsed)
                                d.gameObject.GetComponent<ID>().iD = parsedID;
                            else Debug.LogError("Failed to parse ID on " + d.gameObject.name);
                        }
                        else if (temp[0] == "GoldNode")
                        {
                            GoldNode d = Instantiate(gold, pos, Quaternion.identity).GetComponent<GoldNode>();
                            d.inputMin.text = temp[5];
                            d.inputMax.text = temp[6];

                            ulong parsedID = 0;
                            bool parsed = ulong.TryParse(temp[1], out parsedID);

                            if (parsed)
                                d.gameObject.GetComponent<ID>().iD = parsedID;
                            else Debug.LogError("Failed to parse ID on " + d.gameObject.name);
                        }
                        else if (temp[0] == "HealDamageNode")
                        {
                            HealDamageNode d = Instantiate(healD, pos, Quaternion.identity).GetComponent<HealDamageNode>();

                            int id = -1;

                            bool parsed = int.TryParse(temp[5], out id);

                            if (!parsed)
                                Debug.LogError("Failed to parse heal damage value");

                            d.type.value = id;
                            d.inputMin.text = temp[6];
                            d.inputMax.text = temp[7];

                            ulong parsedID = 0;
                            bool parsedq = ulong.TryParse(temp[1], out parsedID);

                            if (parsedq)
                                d.gameObject.GetComponent<ID>().iD = parsedID;
                            else Debug.LogError("Failed to parse ID on " + d.gameObject.name);
                        }
                        else if (temp[0] == "IfDeityNode")
                        {
                            IfElseDeity d = Instantiate(ifElse, pos, Quaternion.identity).GetComponent<IfElseDeity>();

                            int id = -1;

                            bool parsed = int.TryParse(temp[5], out id);

                            if (!parsed)
                                Debug.LogError("Failed to parse IfDeityNode value");

                            d.type.value = id;

                            ulong parsedID = 0;
                            bool parsedq = ulong.TryParse(temp[1], out parsedID);

                            if (parsedq)
                                d.gameObject.GetComponent<ID>().iD = parsedID;
                            else Debug.LogError("Failed to parse ID on " + d.gameObject.name);
                        }
                        else if (temp[0] == "LootDropNode")
                        {
                            LootDropNode d = Instantiate(lootDrop, pos, Quaternion.identity).GetComponent<LootDropNode>();

                            int id1 = -1;
                            int id2 = -1;
                            int id3 = -1;

                            bool parsed1 = int.TryParse(temp[5], out id1);
                            bool parsed2 = int.TryParse(temp[6], out id2);
                            bool parsed3 = int.TryParse(temp[7], out id3);

                            if (!parsed1 || !parsed2 || !parsed3)
                                Debug.LogError("Failed to parse loot drop node values");

                            d.type.value = id1;
                            d.rarityMin.value = id2;
                            d.rarityMax.value = id3;

                            ulong parsedID = 0;
                            bool parsed = ulong.TryParse(temp[1], out parsedID);

                            if (parsed)
                                d.gameObject.GetComponent<ID>().iD = parsedID;
                            else Debug.LogError("Failed to parse ID on " + d.gameObject.name);
                        }
                        else if (temp[0] == "LoreDropNode")
                        {
                            LoreDropNode d = Instantiate(loreDrop, pos, Quaternion.identity).GetComponent<LoreDropNode>();
                            d.inputText.text = temp[5];
                            d.inputLinkText.text = temp[6];

                            ulong parsedID = 0;
                            bool parsed = ulong.TryParse(temp[1], out parsedID);

                            if (parsed)
                                d.gameObject.GetComponent<ID>().iD = parsedID;
                            else Debug.LogError("Failed to parse ID on " + d.gameObject.name);
                        }
                        else if (temp[0] == "MultilootNode")
                        {
                            MultilootNode d = Instantiate(multiLoot, pos, Quaternion.identity).GetComponent<MultilootNode>();
                            d.inputField.text = temp[5];

                            ulong parsedID = 0;
                            bool parsed = ulong.TryParse(temp[1], out parsedID);

                            if (parsed)
                                d.gameObject.GetComponent<ID>().iD = parsedID;
                            else Debug.LogError("Failed to parse ID on " + d.gameObject.name);
                        }
                        else if (temp[0] == "QuestTitleNode")
                        {
                            QuestTitle d = Instantiate(qTitle, pos, Quaternion.identity).GetComponent<QuestTitle>();
                            d.inputField.text = temp[5];

                            ulong parsedID = 0;
                            bool parsed = ulong.TryParse(temp[1], out parsedID);

                            if (parsed)
                                d.gameObject.GetComponent<ID>().iD = parsedID;
                            else Debug.LogError("Failed to parse ID on " + d.gameObject.name);
                        }
                        else if (temp[0] == "XPNode")
                        {
                            XPNode d = Instantiate(xP, pos, Quaternion.identity).GetComponent<XPNode>();

                            int id = -1;

                            bool parsed = int.TryParse(temp[5], out id);

                            if (!parsed)
                                Debug.LogError("Failed to parse XP Node values");

                            d.type.value = id;
                            d.inputMin.text = temp[6];
                            d.inputMax.text = temp[7];

                            ulong parsedID = 0;
                            bool parsedq = ulong.TryParse(temp[1], out parsedID);

                            if (parsedq)
                                d.gameObject.GetComponent<ID>().iD = parsedID;
                            else Debug.LogError("Failed to parse ID on " + d.gameObject.name);
                        }
                    }
                }
            }

            Debug.Log(FileName.text + ".AsteriaQuest" + " was loaded.");
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

            for(int i = 0; i < 18; i++)
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