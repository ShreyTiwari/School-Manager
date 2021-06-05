namespace SchoolManager
{
    class SchoolMember
    {
        public string Name;
        public string Address;
        private int phone;

        public int Phone
        {
            get { return phone; }
            set { phone = value; }
        }
    }
}
