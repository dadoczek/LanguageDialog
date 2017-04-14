﻿using Core.AbstractApp;
using Repo.AbstractRepo;
using Service;

namespace Core.Factories
{
    public interface IFactory
    {
        IDialogueRepository GetDialogueRepository { get; }
        ILanguageRepository GetLanguageRepository { get; }
        IActorRepository GetActorRepository { get; }
        IIssueRepository GetIssueRepository { get; }
        IFileRepository GetTrackFileInfoRepository { get; }
        IDialogueApplication GetDialogueApplication { get; }
        ILanguageApplication GetLanguageApplication { get; }
        IActorApplication GetActorApplication { get; }
        IIssueApplication GetIssueApplication { get; }
        IFileApplication GetFileApplication { get; }
        IFileRepository GetFileRepository { get; }
        IPlayerDialogueAppplication GetPlayerDiaogueApplication { get; }
        IDialogueService GetDialogueService { get; }
        ILanguageService GetLanguageService { get; }
    }
}
