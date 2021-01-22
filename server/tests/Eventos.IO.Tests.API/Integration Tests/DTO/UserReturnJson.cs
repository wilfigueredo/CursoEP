using System;

namespace Eventos.IO.Tests.API.Integration_Tests.DTO
{
    public class UserReturnJson
    {
        public bool success { get; set; }
        public Data data { get; set; }
    }

    public class Data
    {
        public Result result { get; set; }
        public int id { get; set; }
        public object exception { get; set; }
        public int status { get; set; }
        public bool isCanceled { get; set; }
        public bool isCompleted { get; set; }
        public bool isCompletedSuccessfully { get; set; }
        public int creationOptions { get; set; }
        public object asyncState { get; set; }
        public bool isFaulted { get; set; }
    }

    public class Result
    {
        public string access_token { get; set; }
        public DateTime expires_in { get; set; }
        public User user { get; set; }
    }

    public class User
    {
        public string id { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public Claim[] claims { get; set; }
    }

    public class Claim
    {
        public string type { get; set; }
        public string value { get; set; }
    }
}