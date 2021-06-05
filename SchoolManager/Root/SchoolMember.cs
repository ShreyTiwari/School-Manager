namespace SchoolManager
{
    public class SchoolMember
    {
        public string Name;
        public string Address;
        private int phone;

        public SchoolMember(string name = "", string address = "", int phone = 0)
        {
            Name = name;
            Address = address;
            this.phone = phone;
        }

        public int Phone
        {
            get { return phone; }
            set { phone = value; }
        }
    }
}
