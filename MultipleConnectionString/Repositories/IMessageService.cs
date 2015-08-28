using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MultipleConnectionString.Repositories
{
    public interface IMessageService
    {
        string GetMessage();
    }

    public class MessageService: IMessageService
    {
        private readonly IMessageRepository _messageRepository;
        public MessageService(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public string GetMessage()
        {
            return _messageRepository.GetMessage();
        }
    }

    public class ChineseMessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;
        public ChineseMessageService(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public string GetMessage()
        {
            return _messageRepository.GetMessage();
        }
    }

    public class VietnameseMessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;
        public VietnameseMessageService(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public string GetMessage()
        {
            return _messageRepository.GetMessage();
        }
    }
}