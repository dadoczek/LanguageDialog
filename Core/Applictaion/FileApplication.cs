using System;
using Contract.Responses;
using Core.AbstractApp;
using Core.Factories;
using Model.Models;
using Repo.AbstractRepo;

namespace Core.Applictaion
{
    internal class FileApplication : BaseApplication, IFileApplication
    {
        private readonly IFileRepository _repo;

        public FileApplication(IFactory factory)
        {
            _repo = factory.GetFileRepository;
        }

        public BaseResponse Add(AudioFile newTrack)
        {
            return DoSuccess(() =>
            {
                _repo.Add(newTrack);
            });
        }

        public BaseResponse Edit(AudioFile editTrack)
        {
            return DoSuccess(() =>
            {
                _repo.Edit(editTrack);
            });
        }

        public BaseResponse AddOrEdit(AudioFile audioFile)
        {
            return DoSuccess(() =>
            {
                

                var existAudio = _repo.GetAudioFile(audioFile.Id);
                if (existAudio != null)
                {
                    existAudio.Data = audioFile.Data;
                    existAudio.sufix = audioFile.sufix;
                    _repo.Edit(existAudio);
                } 
                else
                    _repo.Add(audioFile);
            });
        }

        public BaseResponse Remove(int trackId, int dialogueId)
        {
            throw new NotImplementedException();
        }
    }
}
