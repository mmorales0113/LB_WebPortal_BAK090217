﻿using System;
using System.Threading.Tasks;
using Abp;
using Abp.Domain.Services;

namespace WebPortal.Chat
{
    public interface IChatMessageManager : IDomainService
    {
        Task SendMessageAsync(UserIdentifier sender, UserIdentifier receiver, string message, string senderTenancyName, string senderUserName, Guid? senderProfilePictureId);

        long Save(ChatMessage message);

        int GetUnreadMessageCount(UserIdentifier userIdentifier, UserIdentifier sender);
    }
}
