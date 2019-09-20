using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BamGScript : MonoBehaviour {

    public KMAudio Audio;
    public KMBombInfo bomb;
    public List<KMSelectable> buttons;
    public Renderer[] brends;
    public Material[] buttoncol;
    public Renderer[] leds;
    public Material[] ledcol;
    public TextMesh[] displays;

    private string[] prepend = new string[4] { string.Empty, "THE LETTER ", "THE WORD " ,"MISSPELT "};
    private string[] colours = new string[14] { "WHITE", "RED", "ORANGE", "YELLOW", "LIME", "GREEN", "JADE", "GREY", "CYAN", "AZURE", "BLUE", "VIOLET", "MAGENTA", "ROSE" };
    private string[][] alph = new string[3][] { new string[26] { "A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z"},
                                                new string[26] { "ALPHA", "BRAVO", "CHARLIE", "DELTA", "ECHO", "FOXTROT", "GOLF", "HOTEL", "INDIA", "JULIET", "KILO", "LIMA", "MIKE",
                                                                 "NOVEMBER", "OSCAR", "PAPA", "QUEBEC", "ROMEO", "SIERRA", "TANGO", "UNIFORM", "VICTOR", "WHISKEY", "XRAY", "YANKEE", "ZULU" },
                                                new string[130]{ "ALFHA", "BRAVOH", "CHARLEE", "DELLTA", "EKO", "FOKSTROT", "GOLPH", "HOATEL", "INDYA", "JOOLIET", "KEYLO", "LEEMA", "MYKE",
                                                                 "NOBEMVER", "OSCAH", "PAPPA", "QEUBEC", "ROMIO", "SCIERA", "TANKO", "YUNIFORM", "VICKTOR", "WISKEY", "EKSRAY", "YANKIE", "ZOOLU",
                                                                 "ALPA", "BRAVOE", "CHARLY", "DELTER", "ECOH", "FOXCHROT", "GOLLF", "HOTELL", "INDEA", "JULYET", "KEELO", "LEYMA", "MAIK",
                                                                 "NOVEBMER", "OZCAR", "PAPHA", "QUEBECK", "REOMO", "SIARRA", "TONGO", "UNIPHORM", "VICTAH", "WHISKEE", "XRAE", "YANGKEE", "ZULOO",
                                                                 "ALEPH", "BRAHVO", "CHAALIE", "TELTA", "ECCO", "FOXTROY", "COLF", "OHTEL", "INDIR", "GULIET", "CHILO", "LEMA", "MIC",
                                                                 "NOVEMBAR", "OSKAR", "PAHPAH", "CUEBEC", "ROMYO", "SEERRA", "DANGO", "UNUFORM", "VITCOR", "WHISCEY", "XREI", "YANKY", "ZULLU",
                                                                 "ALPHER", "BRUHVO", "SHARLIE", "OELTA", "EGHO", "POXTROT", "EOLF", "HOTLE", "NDIA", "JULLIET", "QUILO", "LIA", "MIXE",
                                                                 "NOVENBER", "OSSCAR", "FAFA", "QUEBEQ", "RHOMEO", "SYERRA", "TNGO", "UNIFROM", "VICTUR", "VVHISKEY", "XARRAY", "IANKEE", "ZUWU",
                                                                 "AELLFHAH", "BERRARVO", "TCHAALEY", "DERLEDEH", "EQUEAUX", "PHAWXTRT", "GAULTH", "HOUGHTEL", "YNNDEYER", "DGEULIRT", "QUEELOWE", "LEIGHMUR", "MISQUE",
                                                                 "NOUGHVMB", "AUSQUE", "PARGHPEH", "KWUBBECH", "ROAMEEOH", "CYERHA", "TAENGKOW", "EUNIFAWM", "VYCHTOUR", "UISSQUAY", "ECHSREIH", "EANGQUI", "ZOUGHLEW" } };
    private string[] properties = new string[100] { "Y4", "G2", "R1", "B5", "G1", "24", "Y3", "13", "R5", "Y2",
                                                    "G1", "B2", "G5", "B3", "R4", "45", "Y1", "R2", "23", "B4",
                                                    "R4", "34", "R2", "G3", "Y5", "G1", "B4", "G4", "B2", "12",
                                                    "B3", "15", "G3", "R4", "25", "Y2", "Y3", "G3", "R1", "B1",
                                                    "Y2", "B4", "Y1", "23", "B1", "G4", "B5", "Y3", "14", "Y5",
                                                    "23", "R5", "12", "G1", "Y4", "B3", "R2", "R1", "G3", "G2",
                                                    "Y3", "R1", "G5", "B4", "35", "Y5", "B1", "G2", "R5", "14",
                                                    "G1", "Y4", "24", "R2", "G5", "R4", "13", "B5", "Y1", "R5",
                                                    "45", "B3", "G1", "Y3", "B5", "G3", "15", "R4", "R2", "Y2",
                                                    "R5", "G4", "Y5", "34", "B4", "G2", "R3", "25", "Y3", "B2"};
    private List<string> tplist = new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16" };
    private string[][] disptext = new string[2][] { new string[4], new string[4]};
    private string[][] propselect = new string[2][] { new string[4], new string[4]};
    private List<string>[] buttoncycle = new List<string>[16] { new List<string> { }, new List<string> { }, new List<string> { }, new List<string> { }, new List<string> { }, new List<string> { }, new List<string> { }, new List<string> { }, new List<string> { }, new List<string> { }, new List<string> { }, new List<string> { }, new List<string> { }, new List<string> { }, new List<string> { }, new List<string> { }};
    private List<int> alreadypressed = new List<int> { };
    private List<int> ordering = new List<int> { };
    private int[][] origvals = new int[2][] { new int[4], new int[4]};
    private int[][] finvals = new int[2][] { new int[4], new int[4]};
    private List<int> chosenbutton = new List<int> { };
    private string[][] chosenprop = new string[2][] { new string[4], new string[4]};
    private int[][][] textrand = new int[2][][] { new int[4][] { new int[4], new int[4], new int[4], new int[4] }, new int[4][] { new int[4], new int[4], new int[4], new int[4] } };
    private bool pressable;
    private bool safetynet = true;
    private bool fullreset = true;
    private int pressCount;
    private int stageCount;

    private static int moduleIDcounter;
    private int moduleID;
    private bool moduleSolved;

    private void Awake()
    {
        moduleID = moduleIDcounter++;
        foreach(KMSelectable button in buttons)
        {
            int b = buttons.IndexOf(button);
            button.OnInteract += delegate () { ButtonPress(b); return false; };
        }
        foreach(Renderer led in leds)
        {
            led.material = ledcol[0];          
        }
    }

    private void Start()
    {
        Reset();
	}

    private void ButtonPress(int b)
    {
        if (pressable == true && moduleSolved == false)
        {
            Audio.PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, transform);
            buttons[b].AddInteractionPunch(0.5f);
            if (b == 16)
            {
                Debug.LogFormat("[Bamboozling Button Grid #{0}]Manual reset initiated", moduleID);
                if (pressCount == 0)
                {
                    fullreset = true;
                }
                Reset();
            }
            else
            {
                if (chosenbutton.Contains(b) || alreadypressed.Contains(b))
                {
                    Debug.LogFormat("[Bamboozling Button Grid #{0}]Error: Button {1} has already been pressed", moduleID, b+1);
                    GetComponent<KMBombModule>().HandleStrike();
                    chosenbutton.Clear();
                    for (int i = 4; i < 8; i++)
                    {
                        leds[i].material = ledcol[2];
                    }
                    for (int i = 0; i < stageCount; i++)
                    {
                        if (safetynet == false)
                        {
                            leds[i].material = ledcol[4];
                        }
                        else
                        {
                            leds[i].material = ledcol[3];
                        }
                    }
                    if (safetynet == true)
                    {
                        safetynet = false;
                        pressable = false;
                        StartCoroutine(LEDreset());
                    }
                    else
                    {
                        Reset();
                    }
                }
                else
                {
                    chosenbutton.Add(b);
                    leds[pressCount + 4].material = ledcol[1];
                    for (int i = 0; i < 2; i++)
                    {
                        if (propselect[i][pressCount] != "//")
                        {
                            if ("RYGB".Contains(propselect[i][pressCount][0].ToString()))
                            {
                                chosenprop[i][pressCount] = buttoncycle[b]["12345".IndexOf(propselect[i][pressCount][1].ToString())].ToString() + propselect[i][pressCount][1].ToString();
                            }
                            else
                            {
                                chosenprop[i][pressCount] = buttoncycle[b]["12345".IndexOf(propselect[i][pressCount][0].ToString())].ToString() + buttoncycle[b]["12345".IndexOf(propselect[i][pressCount][1].ToString())].ToString();
                            }
                        }
                        else
                        {
                            chosenprop[1][pressCount] = buttoncycle[b]["12345".IndexOf(propselect[0][pressCount][1].ToString())].ToString() + ("51234".IndexOf(propselect[0][pressCount][1].ToString()) + 1).ToString();
                        }
                    }
                    Debug.Log(string.Join(string.Empty, buttoncycle[b].ToArray()));
                    Debug.LogFormat("[Bamboozling Button Grid #{0}]Button {1} pressed, its properties are: {2}", moduleID, b+1, chosenprop[0][pressCount] + ", " + chosenprop[1][pressCount]);
                    if (pressCount == 3)
                    {
                        pressCount = 0;
                        bool[][] pass = new bool[2][] { new bool[4], new bool[4]};
                        for (int i = 0; i < 2; i++)
                        {
                            for (int j = 0; j < 4; j++)
                            {
                                if ((propselect[i][j] != "//" && (chosenprop[i][j] == propselect[i][j] || chosenprop[i][j][0] == chosenprop[i][j][1])) || (propselect[i][j] == "//" && chosenprop[0][j][0] == chosenprop[1][j][0] && "51234".IndexOf(chosenprop[0][j][1]) == "12345".IndexOf(chosenprop[1][j][1])))
                                {
                                    pass[i][j] = true;
                                }
                            }                       
                        }
                        for(int i = 0; i < 4; i++)
                        {
                            if(pass[0][i] == true && pass[1][i] == true)
                            {
                                leds[i + 4].material = ledcol[4];
                            }
                            else
                            {
                                leds[i + 4].material = ledcol[2];
                            }
                        }
                        for(int i = 0; i < 9; i++)
                        {
                            if(i < 8)
                            {
                                if (pass[Mathf.FloorToInt(i / 4)][i % 4] == false)
                                {
                                    if (safetynet == false)
                                    {
                                        leds[stageCount].material = ledcol[0];
                                    }
                                    for (int j = 0; j < stageCount; j++)
                                    {
                                        if (safetynet == false)
                                        {
                                            leds[j].material = ledcol[0];
                                        }
                                        else
                                        {
                                            leds[j].material = ledcol[3];
                                        }
                                    }
                                    if (safetynet == true)
                                    {
                                        safetynet = false;
                                        pressable = false;
                                        StartCoroutine(LEDreset());
                                    }
                                    else
                                    {
                                        GetComponent<KMBombModule>().HandleStrike();
                                        Reset();
                                    }
                                    break;
                                }
                            }
                            else
                            {
                                safetynet = true;
                                Audio.PlaySoundAtTransform("InputCorrect", transform);
                                for (int j = 0; j < stageCount + 1; j++)
                                {
                                    leds[j].material = ledcol[4];
                                }
                                if (stageCount == 3)
                                {
                                    GetComponent<KMBombModule>().HandlePass();
                                    moduleSolved = true;
                                    displays[0].text = string.Empty;
                                    displays[1].text = string.Empty;
                                    Reset();
                                }
                                else
                                {
                                    stageCount++;
                                    for(int j = 0; j < 4; j++)
                                    {
                                        alreadypressed.Add(chosenbutton[j]);
                                    }
                                    Reset();
                                }
                            }
                        }
                        chosenbutton.Clear();
                    }
                    else
                    {
                        pressCount++;
                    }
                }
            }
        }
        else if(moduleSolved == true && b == 16)
        {
            StopAllCoroutines();
            foreach (Renderer brend in brends)
            {
                brend.material = buttoncol[0];
            }
        }
    }

    private void Reset()
    {
        StopAllCoroutines();
        if(fullreset == true)
        {
            Debug.LogFormat("[Bamboozling Button Grid #{0}]Resetting to stage 1", moduleID);
            fullreset = false;
            safetynet = true;
            alreadypressed.Clear();
            stageCount = 0;
            for(int i = 0; i < 4; i++)
            {
                leds[i].material = ledcol[0];
            }
        }
        pressable = false;
        pressCount = 0;
        foreach(Renderer brend in brends)
        {
            brend.material = buttoncol[0];
        }
        if (moduleSolved == false)
        {
            List<int> initlist = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            List<string> order = new List<string> { };
            foreach (int num in alreadypressed)
            {
                initlist.Remove(num);
            }
            ordering.Clear();
            int forbid = initlist.Count;
            for (int i = 0; i < forbid; i++)
            {
                int r = UnityEngine.Random.Range(0, initlist.Count);
                ordering.Add(initlist[r]);
                order.Add((initlist[r] + 1).ToString());
                initlist.RemoveAt(r);
            }
            Debug.Log(string.Join(", ", order.ToArray()));
            foreach (List<string> list in buttoncycle)
            {
                list.Clear();
                for (int i = 0; i < 5; i++)
                {
                    string thing = "RYGB"[UnityEngine.Random.Range(0, 4)].ToString();
                    list.Add(thing);
                }
            }
            string[][] ologvals = new string[2][] { new string[4], new string[4] };
            string[][] flogvals = new string[2][] { new string[4], new string[4] };
            string[][] collog = new string[2][] { new string[4], new string[4] };
            for (int i = 0; i < 2; i++)
            {
                displays[i].text = string.Empty;
                for (int j = 0; j < 4; j++)
                {
                    textrand[i][j][3] = UnityEngine.Random.Range(0, 14);
                    collog[i][j] = colours[textrand[i][j][3]];
                    textrand[i][j][2] = UnityEngine.Random.Range(0, 4);
                    textrand[i][j][1] = UnityEngine.Random.Range(0, 3);
                    textrand[i][j][0] = UnityEngine.Random.Range(0, 130);
                    if (textrand[i][j][1] != 2)
                    {
                        textrand[i][j][0] %= 26;
                    }
                    disptext[i][j] = prepend[textrand[i][j][2]] + alph[textrand[i][j][1]][textrand[i][j][0]];
                    switch (textrand[i][j][1])
                    {
                        case 0:
                            origvals[i][j] = textrand[i][j][0] % 26 + 1;
                            break;
                        case 1:
                            origvals[i][j] = (textrand[i][j][0] % 26) + 37;
                            break;
                        case 2:
                            origvals[i][j] = (textrand[i][j][0] % 26) + 74;
                            break;
                    }
                    ologvals[i][j] = origvals[i][j].ToString();
                }
            }
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    switch (textrand[i][j][2])
                    {
                        case 0:
                            finvals[i][j] = Rule(origvals[i][j], textrand[i][j][3]);
                            break;
                        case 1:
                            finvals[i][j] = Rule(origvals[i][j], textrand[i][(j + 1) % 4][3]);
                            break;
                        case 2:
                            finvals[i][j] = Rule(origvals[i][j], textrand[1 - i][j][3]);
                            break;
                        case 3:
                            finvals[i][j] = Rule(origvals[i][j], textrand[1 - i][(j + 1) % 4][3]);
                            break;
                    }
                    finvals[i][j] = Mathf.Abs(finvals[i][j]) % 100;
                    flogvals[i][j] = finvals[i][j].ToString();
                    propselect[i][j] = properties[finvals[i][j]];
                }
            }
            for (int i = 0; i < 4; i++)
            {
                if ("RYGB".Contains(propselect[0][i][0].ToString()))
                {
                    if ("RYGB".Contains(propselect[1][i][0].ToString()))
                    {
                        buttoncycle[ordering[i]]["12345".IndexOf(propselect[0][i][1].ToString())] = propselect[0][i][0].ToString();
                        if (propselect[0][i][1] == propselect[1][i][1] && propselect[0][i][0] != propselect[1][i][0])
                        {
                            buttoncycle[ordering[i]]["51234".IndexOf(propselect[1][i][1].ToString())] = buttoncycle[ordering[i]]["12345".IndexOf(propselect[0][i][1].ToString())];
                            propselect[1][i] = "//";                           
                        }
                        else
                        {
                            buttoncycle[ordering[i]]["12345".IndexOf(propselect[1][i][1].ToString())] = propselect[1][i][0].ToString();
                        }
                    }
                    else
                    {
                        buttoncycle[ordering[i]]["12345".IndexOf(propselect[0][i][1].ToString())] = propselect[0][i][0].ToString();
                        if (propselect[0][i][1] == propselect[1][i][1])
                        {
                            buttoncycle[ordering[i]]["12345".IndexOf(propselect[1][i][0].ToString())] = propselect[0][i][0].ToString();
                        }
                        else
                        {
                            buttoncycle[ordering[i]]["12345".IndexOf(propselect[1][i][1].ToString())] = buttoncycle[ordering[i]]["12345".IndexOf(propselect[1][i][0].ToString())];
                        }
                    }
                }
                else
                {
                    if ("RYGB".Contains(propselect[1][i][0].ToString()))
                    {
                        buttoncycle[ordering[i]]["12345".IndexOf(propselect[1][i][1].ToString())] = propselect[1][i][0].ToString();
                        if (propselect[0][i][1] == propselect[1][i][1])
                        {
                            buttoncycle[ordering[i]]["12345".IndexOf(propselect[0][i][0].ToString())] = propselect[1][i][0].ToString();
                        }
                        else
                        {
                            buttoncycle[ordering[i]]["12345".IndexOf(propselect[0][i][1].ToString())] = buttoncycle[ordering[i]]["12345".IndexOf(propselect[0][i][0].ToString())];
                        }
                    }
                    else if (propselect[0][i][1] == propselect[1][i][1])
                    {
                        buttoncycle[ordering[i]]["12345".IndexOf(propselect[0][i][0].ToString())] = buttoncycle[ordering[i]]["12345".IndexOf(propselect[0][i][1].ToString())];
                        buttoncycle[ordering[i]]["12345".IndexOf(propselect[1][i][0].ToString())] = buttoncycle[ordering[i]]["12345".IndexOf(propselect[1][i][1].ToString())];
                    }
                    else
                    {
                        buttoncycle[ordering[i]]["12345".IndexOf(propselect[0][i][1].ToString())] = buttoncycle[ordering[i]]["12345".IndexOf(propselect[0][i][0].ToString())];
                        buttoncycle[ordering[i]]["12345".IndexOf(propselect[1][i][1].ToString())] = buttoncycle[ordering[i]]["12345".IndexOf(propselect[1][i][0].ToString())];
                    }
                }
            }
            string grid = "[Bamboozling Button Grid #" + moduleID + "]The grid has the buttons:";
            for (int i = 0; i < 4; i++)
            {
                grid += "\n[Bamboozling Button Grid #" + moduleID + "]";
                for (int j = 0; j < 4; j++)
                {
                    grid += string.Join(string.Empty, buttoncycle[i * 4 + j].ToArray()) + " ";
                }
            }
            Debug.Log(grid);
            for (int i = 0; i < 2; i++)
            {
                Debug.LogFormat("[Bamboozling Button Grid #{0}]The {2} screen reads {1}", moduleID, string.Join(" - ", disptext[i]), new string[] { "upper", "right" }[i]);
                Debug.LogFormat("[Bamboozling Button Grid #{0}]The {2} screen gives the values {1}", moduleID, string.Join(", ", ologvals[i]), new string[] { "upper", "right" }[i]);
                Debug.LogFormat("[Bamboozling Button Grid #{0}]The {2} screen has the text colours: {1}", moduleID, string.Join(", ", collog[i]), new string[] { "upper", "right" }[i]);
                Debug.LogFormat("[Bamboozling Button Grid #{0}]The altered values are {1}", moduleID, string.Join(", ", flogvals[i]));
                Debug.LogFormat("[Bamboozling Button Grid #{0}]The {2} set of desired properties are {1} ", moduleID, string.Join(", ", propselect[i]), new string[] { "first", "second" }[i]);
            }
            StartCoroutine(Cycle());
            pressable = true;
        }
        else
        {
            StartCoroutine(Solveanim());
        }
    }

    private int Rule(int v, int r)
    {
        int[] digit = new int[2] { v % 10, Mathf.FloorToInt(v / 10)};
        switch (r)
        {
            case 1:
                v += digit[1] * 10;
                break;
            case 2:
                v += digit[0] + digit[1];
                break;
            case 3:
                v *= 2;
                break;
            case 4:
                v += Mathf.Abs(digit[0] - digit[1]) * 5;
                break;
            case 5:
                v = 100 - v;
                break;
            case 6:
                v += digit[1] * 11;
                break;
            case 7:
                v = digit[0] * 10 + digit[1];
                break;
            case 8:
                v += digit[0] * 10;
                break;
            case 9:
                v += (digit[0] + digit[1])*2;
                break;
            case 10:
                v += v + 1;
                break;
            case 11:
                v += Mathf.Abs(digit[0] - digit[1]) * 8;
                break;
            case 12:
                v = 100 - 2*v;
                break;
            case 13:
                v += digit[0] * 11;
                break;
        }
        return v;
    }

    private IEnumerator LEDreset()
    {
        yield return new WaitForSeconds(2);
        pressable = true;
        for(int i = pressCount + 4; i < 8; i++)
        {
            leds[i].material = ledcol[0];
        }
        yield return null;
    }

    private IEnumerator Cycle()
    {
        yield return new WaitForSeconds(2);
        for(int i = 4; i < 8; i++)
        {
            leds[i].material = ledcol[0];
        }
        for(int i = 0; i < 5; i++)
        {
            for(int j = 0; j < 2; j++)
            {
                if (i != 4)
                {
                    displays[j].text = disptext[j][i];
                    switch (textrand[j][i][3])
                    {
                        case 0:
                            displays[j].color = new Color32(192, 192, 192, 255);
                            break;
                        case 1:
                            displays[j].color = new Color32(192, 0, 0, 255);
                            break;
                        case 2:
                            displays[j].color = new Color32(192, 96, 0, 255);
                            break;
                        case 3:
                            displays[j].color = new Color32(192, 192, 0, 255);
                            break;
                        case 4:
                            displays[j].color = new Color32(96, 192, 0, 255);
                            break;
                        case 5:
                            displays[j].color = new Color32(0, 192, 0, 255);
                            break;
                        case 6:
                            displays[j].color = new Color32(0, 192, 96, 255);
                            break;
                        case 7:
                            displays[j].color = new Color32(96, 96, 96, 255);
                            break;
                        case 8:
                            displays[j].color = new Color32(0, 192, 192, 255);
                            break;
                        case 9:
                            displays[j].color = new Color32(0, 96, 192, 255);
                            break;
                        case 10:
                            displays[j].color = new Color32(0, 0, 192, 255);
                            break;
                        case 11:
                            displays[j].color = new Color32(96, 0, 192, 255);
                            break;
                        case 12:
                            displays[j].color = new Color32(192, 0, 192, 255);
                            break;
                        case 13:
                            displays[j].color = new Color32(192, 0, 96, 255);
                            break;
                    }
                }
                else
                {
                    displays[j].text = string.Empty;
                }
            }
            for(int j = 0; j < 16; j++)
            {
                switch (buttoncycle[j][i])
                {
                    case "R":
                        brends[j].material = buttoncol[1];
                        break;
                    case "Y":
                        brends[j].material = buttoncol[2];
                        break;
                    case "G":
                        brends[j].material = buttoncol[3];
                        break;
                    case "B":
                        brends[j].material = buttoncol[4];
                        break;
                }
            }
            if(i == 4)
            {
                i = -1;
            }
            yield return new WaitForSeconds(1);
        }
    }

    private IEnumerator Solveanim()
    {
        yield return new WaitForSeconds(2);
        displays[0].text = "NICELY DONE";
        displays[1].text = "YOU DID IT";
        displays[0].color = new Color32(255, 255, 255, 255);
        displays[1].color = new Color32(255, 255, 255, 255);
        for (int i = 0; i < 28; i++)
        {
            switch (i)
            {
                case 0:
                    brends[0].material = buttoncol[1];
                    break;
                case 1:
                    brends[1].material = buttoncol[1];
                    brends[4].material = buttoncol[1];
                    break;
                case 2:
                    brends[2].material = buttoncol[1];
                    brends[5].material = buttoncol[1];
                    brends[8].material = buttoncol[1];
                    break;
                case 3:
                    brends[3].material = buttoncol[1];
                    brends[6].material = buttoncol[1];
                    brends[9].material = buttoncol[1];
                    brends[12].material = buttoncol[1];
                    break;
                case 4:
                    brends[7].material = buttoncol[1];
                    brends[10].material = buttoncol[1];
                    brends[13].material = buttoncol[1];
                    break;
                case 5:
                    brends[11].material = buttoncol[1];
                    brends[14].material = buttoncol[1];
                    break;
                case 6:
                    brends[15].material = buttoncol[1];
                    break;
                case 7:
                    brends[3].material = buttoncol[2];
                    break;
                case 8:
                    brends[2].material = buttoncol[2];
                    brends[7].material = buttoncol[2];
                    break;
                case 9:
                    brends[1].material = buttoncol[2];
                    brends[6].material = buttoncol[2];
                    brends[11].material = buttoncol[2];
                    break;
                case 10:
                    brends[0].material = buttoncol[2];
                    brends[5].material = buttoncol[2];
                    brends[10].material = buttoncol[2];
                    brends[15].material = buttoncol[2];
                    break;
                case 11:
                    brends[4].material = buttoncol[2];
                    brends[9].material = buttoncol[2];
                    brends[14].material = buttoncol[2];
                    break;
                case 12:
                    brends[8].material = buttoncol[2];
                    brends[13].material = buttoncol[2];
                    break;
                case 13:
                    brends[12].material = buttoncol[2];
                    break;
                case 20:
                    brends[0].material = buttoncol[3];
                    break;
                case 19:
                    brends[1].material = buttoncol[3];
                    brends[4].material = buttoncol[3];
                    break;
                case 18:
                    brends[2].material = buttoncol[3];
                    brends[5].material = buttoncol[3];
                    brends[8].material = buttoncol[3];
                    break;
                case 17:
                    brends[3].material = buttoncol[3];
                    brends[6].material = buttoncol[3];
                    brends[9].material = buttoncol[3];
                    brends[12].material = buttoncol[3];
                    break;
                case 16:
                    brends[7].material = buttoncol[3];
                    brends[10].material = buttoncol[3];
                    brends[13].material = buttoncol[3];
                    break;
                case 15:
                    brends[11].material = buttoncol[3];
                    brends[14].material = buttoncol[3];
                    break;
                case 14:
                    brends[15].material = buttoncol[3];
                    break;
                case 27:
                    brends[3].material = buttoncol[4];
                    break;
                case 26:
                    brends[2].material = buttoncol[4];
                    brends[7].material = buttoncol[4];
                    break;
                case 25:
                    brends[1].material = buttoncol[4];
                    brends[6].material = buttoncol[4];
                    brends[11].material = buttoncol[4];
                    break;
                case 24:
                    brends[0].material = buttoncol[4];
                    brends[5].material = buttoncol[4];
                    brends[10].material = buttoncol[4];
                    brends[15].material = buttoncol[4];
                    break;
                case 23:
                    brends[4].material = buttoncol[4];
                    brends[9].material = buttoncol[4];
                    brends[14].material = buttoncol[4];
                    break;
                case 22:
                    brends[8].material = buttoncol[4];
                    brends[13].material = buttoncol[4];
                    break;
                case 21:
                    brends[12].material = buttoncol[4];
                    break;
            }
            if(i == 27)
            {
                i = -1;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
#pragma warning disable 414
    private string TwitchHelpMessage = "!{0} 1-16 [Presses button in that position in reading order] | !{0} reset [Presses reset button]";
#pragma warning restore 414
    IEnumerator ProcessTwitchCommand(string command)
    {
        if (command.ToLowerInvariant() == "reset")
        {
            yield return null;
            buttons[16].OnInteract();
        }
        else
        {
            string[] presses = command.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            foreach(string press in presses)
            {
                yield return null;
                if (tplist.Contains(press))
                {               
                    buttons[tplist.IndexOf(press)].OnInteract();
                }
                else
                {
                    yield return "sendtochaterror Invalid button";
                    yield break;
                }
            }
        }
    }
}
