﻿using Model.Models;

namespace Repo.AbstractRepo
{
    public interface IFileRepository
    {
        void Add(AudioFile newTrack);
        void Remove(int trackId, int dialogueId);
        void Edit(AudioFile editTrack);
        AudioFile GetAudioFile(int audioId);
    }
}
