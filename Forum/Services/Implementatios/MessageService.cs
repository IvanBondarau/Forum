using Forum.Constants;
using Forum.Models;
using Forum.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Services.Implementatios
{
    public class MessageService: AbstractCrudService<int, Message>, IMessageService
    {
        private readonly IMessageRepository messageRepository;
        private readonly ITopicRepository topicRepository;
        private readonly IUserRepository userRepository;

        public MessageService(IMessageRepository messageRepository, ITopicRepository topicRepository, IUserRepository userRepository)
            : base(messageRepository)
        {
            this.messageRepository = messageRepository;
            this.topicRepository = topicRepository;
            this.userRepository = userRepository;
        }

        public int CountPages(int topicId)
        {
            int cnt = this.messageRepository.Count(topicId);
            int pageSize = ApplicationConstants.MESSAGE_PAGE_SIZE;
            return cnt / pageSize + (cnt % pageSize == 0 ? 0 : 1);
        }

        public Message Create(int topicId, int authorId, string text)
        {
            Topic topic = topicRepository.Read(topicId);
            User creator = userRepository.Read(authorId);

            Message message = new Message(text, creator, topic);
            return messageRepository.Create(message);
        }

        public ICollection<Message> FindByTopicId(int topicId, int? page)
        {

            return messageRepository.FindByTopicId(topicId, page == null ? 1 : (int)page, ApplicationConstants.MESSAGE_PAGE_SIZE);
        }

        public void Like(int messageId, string username)
        {
            User user = userRepository.FindByUsername(username);
            Message message = messageRepository.Read(messageId);
            if (message.Likes == null)
            {
                message.Likes = new List<User>();
            }
            if (message.Likes.Contains(user))
            {
                message.Likes.Remove(user);
                messageRepository.Update(message);
            } else
            {
                message.Likes.Add(user);
                messageRepository.Update(message);
            }
        }
    }
}
