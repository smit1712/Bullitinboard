using System;
using System.Collections.Generic;
using System.Text;

namespace BulletinBoard
{
    class Message
    {
        private string MessageName;
        private string Postername;
       public string MessageText;
        private List<string> MessageTags = new List<string>();
        public Message(string MsgName, string pstname, string MsgText, string tag)
        {
            MessageName = MsgName;
            Postername = pstname;
            MessageText = MsgText;
            AddTag(tag);

        }
        public void ChangeMsg(string message)
        {
            MessageText = message;
        }

        public string Getname()
        {
            return MessageName;
        }
        public void AddTag(string tag)
        {
            MessageTags.Add(tag);
        }
        public List<string> GetTags()
        {
            return MessageTags;
        }
        public string GetMessage()
        {
            return MessageText;
        }
    }
}
