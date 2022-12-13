using System.Collections.Generic;
using UnityEngine;

public class DebugController : MonoSingleton<DebugController>
{
    bool showConsole;
    bool showHelp;

    Vector2 scroll;

    public string input;

    GUIStyle defaultLabelStyle;
    GUIStyle descriptionLabelStyle;

    public int descriptionSingleWidth;

    public static DebugCommand KILL_RANDOM_ENEMY;
    public static DebugCommand<int> TO_STAGE;
    public static DebugCommand<int, int> USE_SKILL;
    public static DebugCommand HELP;

    public List<object> commandList;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);

        defaultLabelStyle = new GUIStyle();
        defaultLabelStyle.fontSize = 60;
        defaultLabelStyle.normal.textColor = Color.green;

        descriptionSingleWidth = 45;

        descriptionLabelStyle = new GUIStyle();
        descriptionLabelStyle.fontSize = 40;
        descriptionLabelStyle.normal.textColor = Color.green;
    }

    protected override void Awake()
    {
        KILL_RANDOM_ENEMY = new DebugCommand("kill_random_enemy", "杀死随机一个敌人", "kill_random_enemy", () =>
        {
        });
        TO_STAGE = new DebugCommand<int>("go_stage", "进入指定关卡", "go_stage<stageIndex>", (stageIndex) =>
        {
        });
        USE_SKILL = new DebugCommand<int, int>("use_skill", "使用技能", "use_skill<buffID,useCount>", (buffID, useCount) =>
        {
        });

        HELP = new DebugCommand("help", "开启/关闭帮助指令", "help", () =>
        {
            showHelp = !showHelp;
        });

        commandList = new List<object>
        {
            KILL_RANDOM_ENEMY,
            TO_STAGE,
            USE_SKILL,
            HELP,
        };
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F12))
        {
            HandleShow();
        }
    }

    public void HandleShow()
    {
        showConsole = !showConsole;
    }

    private void OnGUI()
    {
        if (!showConsole) { return; }

        GUI.backgroundColor = Color.black;
        float y = 0;

        if (showHelp)
        {
            GUI.Box(new Rect(0, y, Screen.width, 150), "");

            Rect viewport = new Rect(0, 0, Screen.width - 30, descriptionSingleWidth * commandList.Count);

            scroll = GUI.BeginScrollView(new Rect(0, y + 5f, Screen.width, 150), scroll, viewport);

            for (int i = 0; i < commandList.Count; i++)
            {
                DebugCommandBase command = commandList[i] as DebugCommandBase;

                string label = $"{command.CommandFormat} - {command.CommandDescription}";

                Rect labelRect = new Rect(5, descriptionSingleWidth * i, viewport.width - 100, descriptionSingleWidth);

                GUI.Label(labelRect, label, descriptionLabelStyle);
            }

            GUI.EndScrollView();

            y += 150;
        }

        GUI.Box(new Rect(0, y, Screen.width, 100), "");

        Event evt = Event.current;
        if (evt.keyCode == KeyCode.Return)
        {
            HandleEndInput();
        }
        else
        {
            input = GUI.TextField(new Rect(10f, y, Screen.width - 20f, 100), input, defaultLabelStyle);
        }

        y += 100;

        Rect hintRect = new Rect(5, y, Screen.width, descriptionSingleWidth);
        GUI.Label(hintRect, "输入help开启/关闭帮助", descriptionLabelStyle);
    }

    private void HandleInput()
    {
        Debug.Log($"string input:{input}");
        string[] properties = input.Split(' ');

        for (int i = 0; i < commandList.Count; i++)
        {
            DebugCommandBase commandBase = commandList[i] as DebugCommandBase;
            if (input.Contains(commandBase.CommandId))
            {
                if (commandList[i] as DebugCommand != null)
                {
                    (commandList[i] as DebugCommand).Invoke();
                }
                else if (commandList[i] as DebugCommand<int> != null)
                {
                    (commandList[i] as DebugCommand<int>).Invoke(int.Parse(properties[1]));
                }
                else if (commandList[i] as DebugCommand<int, int> != null)
                {
                    (commandList[i] as DebugCommand<int, int>).Invoke(int.Parse(properties[1]), int.Parse(properties[2]));
                }
            }
        }
    }

    public void HandleEndInput()
    {
        if (showConsole)
        {
            HandleInput();
            input = "";
        }
    }
}
