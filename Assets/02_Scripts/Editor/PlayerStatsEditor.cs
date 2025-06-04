using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PlayerStats))]
public class PlayerStatsEditor : Editor
{
    // 인스펙터뷰에 GUI를 커스텀하기 위한 기본 메소드
    public override void OnInspectorGUI()
    {
        var playerStats = (PlayerStats)target;

        EditorGUILayout.Space();
        EditorGUILayout.HelpBox("주인공 캐릭터 스텟", MessageType.Info);
        EditorGUILayout.Space();
        
        // 입력 필드
        playerStats.hp = EditorGUILayout.IntField("생명", playerStats.hp);
        playerStats.mp = EditorGUILayout.IntSlider("MP", playerStats.mp, 0, 100);

        EditorGUILayout.BeginHorizontal();
        // 무적 모드 토글 버튼
        if (GUILayout.Button(playerStats.isGodMode ? "일반모드로 전환" : "무적모드로 전환"))
        {
            playerStats.isGodMode = !playerStats.isGodMode;
        }
        
        // 플레이어 데이터 초기화
        if (GUILayout.Button("데이터 초기화"))
        {
            playerStats.InitPlayerData();
        }
        EditorGUILayout.EndHorizontal();
    } 
}
