using System;
using System.Collections.Generic;
using System.Text;

namespace BulletinBoard
{
    class Board
    {
        private string BoardName;
        private List<Message> MessageList = new List<Message>();
        private List<Image> ImageList = new List<Image>();
        private string creatorname;
        public Board(string BrdName,string Ctrname)
        {
            creatorname = Ctrname;
            BoardName = BrdName;
        }
        public Message Newmessage(string MsgName, string pstname, string MsgText, string tag)
        {
            Message newMessage = new Message(MsgName, pstname, MsgText, tag);
            return newMessage;
        }
        public void Addmassage(Message msg)
        {
            MessageList.Add(msg);
        }
        public List<Message> GetMessages()
        {
            return MessageList;
        }
        public void AddImage(Image IMG)
        {
            ImageList.Add(IMG);
        }
        public List<Image> Getimages()
        {
            return ImageList;
        }
        public List<string[]> GetAllImages()
        {
            List<string[]> result = new List<string[]>();
            string[] IMcomputer = { ".--.", "|__| .-------.", "|=.| |.-----.|", "|--| || KCK ||", "|  | |'-----'|", "|__|~')_____('" };
            string[] IMsmiley = { "    _____  ", "  .'     '.", " /  o   o  \\ ", "|           |", "|  \\     /  |", " \\  '---'  /", "  '._____.'" };

            result.Add(IMcomputer);
            result.Add(IMsmiley);
            return result;
        }
        public List<string> GetImageNames()
        {
            List<string> result = new List<string>();
            result.Add("computer");
            result.Add("smiley");
            return result;
        }
        public string GetName()
        {
            return BoardName;
        }
            public List<string> Gettags()
            {
                List<string> tagslist = new List<string>();
                foreach (Message msg in MessageList)
                {
                    tagslist.AddRange(msg.GetTags());
                }
                return tagslist;
            }
        }
    }
