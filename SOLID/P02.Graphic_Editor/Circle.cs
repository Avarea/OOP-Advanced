namespace P02.Graphic_Editor
{
    public class Circle : IShape
    {
        private string type;

        public Circle(string type)
        {
            this.Type = type;
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public override string ToString()
        {
            return $"Shape is {Type}!";
        }
    }
}
