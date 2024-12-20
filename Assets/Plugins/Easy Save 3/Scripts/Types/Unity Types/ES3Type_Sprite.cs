using UnityEngine;
using UnityEngine.Scripting;

namespace ES3Types
{
    [Preserve]
    [ES3PropertiesAttribute("texture", "rect", "pivot", "pixelsPerUnit", "border")]
    public class ES3Type_Sprite : ES3UnityObjectType
    {
        public static ES3Type Instance;

        public ES3Type_Sprite() : base(typeof(Sprite))
        {
            Instance = this;
        }

        protected override void WriteUnityObject(object obj, ES3Writer writer)
        {
            var instance = (Sprite)obj;

            writer.WriteProperty("texture", instance.texture, ES3Type_Texture2D.Instance);
            writer.WriteProperty("rect", instance.rect, ES3Type_Rect.Instance);
            // Pivot value is in pixels, but we require a normalised pivot when using Sprite.Create during loading, so we normalise it here.
            writer.WriteProperty("pivot", new Vector2(instance.pivot.x / instance.texture.width, instance.pivot.y / instance.texture.height), ES3Type_Vector2.Instance);
            writer.WriteProperty("pixelsPerUnit", instance.pixelsPerUnit, ES3Type_float.Instance);
            writer.WriteProperty("border", instance.border, ES3Type_Vector4.Instance);
        }

        protected override void ReadUnityObject<T>(ES3Reader reader, object obj)
        {
            foreach (string propertyName in reader.Properties)
                reader.Skip();
        }

        protected override object ReadUnityObject<T>(ES3Reader reader)
        {
            Texture2D texture = null;
            var rect = Rect.zero;
            var pivot = Vector2.zero;
            float pixelsPerUnit = 0;
            var border = Vector4.zero;

            foreach (string propertyName in reader.Properties)
                switch (propertyName)
                {
                    case "texture":
                        texture = reader.Read<Texture2D>(ES3Type_Texture2D.Instance);
                        break;
                    case "textureRect":
                    case "rect":
                        rect = reader.Read<Rect>(ES3Type_Rect.Instance);
                        break;
                    case "pivot":
                        pivot = reader.Read<Vector2>(ES3Type_Vector2.Instance);
                        break;
                    case "pixelsPerUnit":
                        pixelsPerUnit = reader.Read<float>(ES3Type_float.Instance);
                        break;
                    case "border":
                        border = reader.Read<Vector4>(ES3Type_Vector4.Instance);
                        break;
                    default:
                        reader.Skip();
                        break;
                }

            return Sprite.Create(texture, rect, pivot, pixelsPerUnit, 0, SpriteMeshType.Tight, border);
        }
    }
}