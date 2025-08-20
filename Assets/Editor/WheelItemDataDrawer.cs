// Assets/Editor/WheelItemDataDrawer.cs
#if UNITY_EDITOR
using _Game.Scripts.Infrastructure.Config;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(WheelItemData), true)]
public class WheelItemDataDrawer : PropertyDrawer
{
    const float Pad = 6f;
    const float MaxPreviewH = 120f; // üstteki önizleme alanının yüksekliği

    public override void OnGUI(Rect pos, SerializedProperty prop, GUIContent label)
    {
        EditorGUI.BeginProperty(pos, label, prop);

        // Alanlar
        var pIcon   = prop.FindPropertyRelative("ItemView");
        var pId     = prop.FindPropertyRelative("Id");
        var pName   = prop.FindPropertyRelative("Name");
        var pReward = prop.FindPropertyRelative("Reward");

        float y = pos.y + Pad;

        // --- Üstte Sprite Preview (aspect korunarak, ortalı) ---
        var previewArea = new Rect(pos.x + Pad, y, pos.width - 2 * Pad, MaxPreviewH);
        DrawSpritePreview(previewArea, pIcon.objectReferenceValue as Sprite);
        y += MaxPreviewH + Pad;

        // --- Sprite Object Field ---
        var ofRect = new Rect(pos.x + Pad, y, pos.width - 2 * Pad, EditorGUIUtility.singleLineHeight);
        EditorGUI.PropertyField(ofRect, pIcon, new GUIContent("Item View"));
        y += EditorGUIUtility.singleLineHeight + Pad;

        // --- Id ---
        var idRect = new Rect(pos.x + Pad, y, pos.width - 2 * Pad, EditorGUIUtility.singleLineHeight);
        EditorGUI.PropertyField(idRect, pId);
        y += EditorGUIUtility.singleLineHeight + Pad;

        // --- Name ---
        var nameRect = new Rect(pos.x + Pad, y, pos.width - 2 * Pad, EditorGUIUtility.singleLineHeight);
        EditorGUI.PropertyField(nameRect, pName);
        y += EditorGUIUtility.singleLineHeight + Pad;

        // --- Reward ---
        var rewardRect = new Rect(pos.x + Pad, y, pos.width - 2 * Pad, EditorGUIUtility.singleLineHeight);
        EditorGUI.PropertyField(rewardRect, pReward);
        y += EditorGUIUtility.singleLineHeight + Pad;

        EditorGUI.EndProperty();
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        // Preview + ObjectField + 3 satır (Id, Name, Reward) + paddingler
        int rows = 4; // ObjectField + 3 property
        return MaxPreviewH + Pad
             + rows * (EditorGUIUtility.singleLineHeight + Pad);
    }

    private static void DrawSpritePreview(Rect area, Sprite sprite)
    {
        if (sprite == null || sprite.texture == null)
        {
            // Placeholder arka plan
            EditorGUI.DrawRect(area, new Color(0, 0, 0, 0.08f));
            return;
        }

        var tex = sprite.texture;
        var tr  = sprite.textureRect;

        // UV'ler (çoklu sprite/atlas için doğru kesit)
        var uvs = new Rect(tr.x / tex.width, tr.y / tex.height, tr.width / tex.width, tr.height / tex.height);

        // Aspect oranını koruyarak alan içine sığdır
        float aspect = tr.width / tr.height;
        float availW = area.width;
        float availH = area.height;

        float drawW, drawH;
        if (availW / availH > aspect)
        {
            // yükseklik sınırlayıcı
            drawH = availH;
            drawW = drawH * aspect;
        }
        else
        {
            // genişlik sınırlayıcı
            drawW = availW;
            drawH = drawW / aspect;
        }

        // Ortala
        var drawRect = new Rect(
            area.x + (availW - drawW) / 2f,
            area.y + (availH - drawH) / 2f,
            drawW,
            drawH
        );

        GUI.DrawTextureWithTexCoords(drawRect, tex, uvs);
        // İsteğe bağlı çerçeve:
        // Handles.DrawSolidRectangleWithOutline(area, Color.clear, new Color(0,0,0,0.2f));
    }
}
#endif