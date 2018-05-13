namespace BookStoreDomainModel.Concrete
{
    public class EmailSettings
    {
        public string emailAddressFrom = "andrewchess25@gmail.com";
        public string emailAddressTo = "andrewchess25@gmail.com";
        public bool useSsl = true;
        public string userName = "andrewchess25@gmail.com";
        public string password = "11111";
        public string serverName = "smtp.gmail.com";
        public int serverPort = 587;
        public bool writeAsFile = true;
        public string fileLocation = @"c:\Email";
    }
}
