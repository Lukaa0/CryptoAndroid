using System;
namespace HandyCrypto.Model
{
    internal class MessageContent 
    {
        public string Username { get; set; }
        public string Message { get; set; }
        public string Time { get; set; }

        

        public MessageContent() { }
        public MessageContent(string username, string Message)
        {
            this.Username = username;
            this.Message = Message;
            Time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}