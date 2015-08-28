using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MultipleConnectionString.Repositories
{
    public interface IMessageRepository
    {
        string GetMessage();
    }
    public class MessageRepository : IMessageRepository
    {
        public string GetMessage()
        {
            return "Hello World";
        }
    }

    public class ChineseMessageRepository : IMessageRepository
    {
        public string GetMessage()
        {
            return "你好！";
        }
    }

    public class VietnameseMessageRepository : IMessageRepository
    {
        public string GetMessage()
        {
            return "Xin chào！";
        }
    }
}