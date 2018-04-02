namespace P02.Graphic_Editor
{
    class Program
    {
        static void Main()
        {
            GraphicEditor graphicEditor = new GraphicEditor();

            Circle circle = new Circle("Circle");
            Rectangle rectangle = new Rectangle("Rectangle");
            Square square = new Square("Square");

            graphicEditor.DrawShape(circle);
            graphicEditor.DrawShape(rectangle);
            graphicEditor.DrawShape(square);
        }
    }
}
