using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternConsole.Decorator
{
    public interface IPostCreateor
    {
        void CreatePost();
    }

    public class PostCreator : IPostCreateor
    {
        public virtual void CreatePost()
        {
            Console.WriteLine("Post Created");
        }
    }

    public class PostCreatorWithBalanceChecker : PostCreator
    {
        int Balance;

        public PostCreatorWithBalanceChecker(int _balance)
        {
            Balance = _balance;
        }

        public override void CreatePost()
        {
            if(Balance > 0)
            {
                base.CreatePost();
            }
            else
            {
                Console.WriteLine("Not enough balance to create post.");
            }
        }
    }

}
