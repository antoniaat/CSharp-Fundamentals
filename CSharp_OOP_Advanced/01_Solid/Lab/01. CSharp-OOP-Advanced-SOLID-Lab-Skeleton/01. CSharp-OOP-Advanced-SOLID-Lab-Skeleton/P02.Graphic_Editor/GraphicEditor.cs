using System;

namespace P02.Graphic_Editor
{
    public class GraphicEditor
    {
        void DrawShape(IShape shape)
        {
            shape.Draw();
        }
    }
}