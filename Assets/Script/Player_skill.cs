using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://www.youtube.com/watch?v=ODB3IOFqmrE
public enum KeyAction //스킬들 들어갈 곳
{
    Skill1, //임시 작명, 스킬 이름 정해지면 넣어주자
    Skill2,
    Skill3,
    Skill4,
    Skill5,
    Skill6,
    Skill7,
    Skill8,
    Skill9,
    Skill10,
    KeyCount, //for문을 사용하기 위해 KeyAction가 몇 개 있는지 알려주기 위함
}

public static class KeySetting
{
    public static Dictionary<KeyAction, KeyCode> keys = new Dictionary<KeyAction, KeyCode>();
}

//체스판 폰 움직일 때 처럼 스킬도 그렇게 만들기

public class Player_skill : MonoBehaviour
{
    private void Awake()
    {
        KeyCode[] defaultKeys = new KeyCode[] { KeyCode.Q, KeyCode.W, KeyCode.E, KeyCode.R, KeyCode.T, KeyCode.A, KeyCode.S, KeyCode.D, KeyCode.C, KeyCode.F };
        for (int i = 0; i < (int)KeyAction.KeyCount; i++)
        {
            KeySetting.keys.Add((KeyAction) i, defaultKeys[i]);
        }
    }
}
