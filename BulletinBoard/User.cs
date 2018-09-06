using System;
using System.Collections.Generic;
using System.Text;

namespace BulletinBoard
{
    class User
    {
        string Username;
        string Password;
        Board selectedboard;
        public bool Isadmin = false;

        public Board NewBoard(string boardname)
        {
            if (Isadmin)
            {
                Board newbrd = new Board(boardname,Username);
                return newbrd;
            }
            else return null;
        }
        public void Selectboard(string brdname,List<Board> brdlist)
        {
            foreach (Board brd in brdlist)
            {
                if (brd.GetName() == brdname)
                {
                    selectedboard = brd;
                }
            }
        }
        public Board Getselectedboard()
        {
            return selectedboard;
        }
        public void Makeadmin(User usr)
        {
            if (usr.Isadmin)
            {
                Isadmin = true;
            }
        }
        public User(string usr, string pssw)
        {
            Username = usr;
            Password = pssw;
        }
        public string GetUsername()
        {
            return Username;
        }
        public string GetPassword()
        {
            return Password;
        }
        public int GetUsernameLength()
        {
            return Username.Length +1;
        }
        
    }
}
