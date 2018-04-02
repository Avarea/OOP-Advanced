namespace P02.Graphic_Editor
{
    public class Rectangle : IShape
    {
        private string type;

        public Rectangle(string type)
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
