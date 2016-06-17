namespace AscomIntegration
{
    public class ConnectObject
    {
        private string _name;
        private int _delay; // delay between sends in ms
        private int _repeat;   // number of times to repeat this send

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Delay
        {
            get { return _delay; }
            set { _delay = value; }
        }

        public int Repeat
        {
            get { return _repeat; }
            set { _repeat = value; }
        }
    }
}