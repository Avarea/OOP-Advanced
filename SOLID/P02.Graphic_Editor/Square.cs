namespace P02.Graphic_Editor
{
    public class Square : IShape
    {
        private string type;

        public Square(string type)
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
