using System;
using Contract.Responses;
using Core.AbstractApp;
using Core.Factories;
using Model.Models;
using Repository.AbstractRepo;

namespace Core.Applictaion
{
    internal class FileApplication : BaseApplication, IFileApplication
    {
        private IFileRepository _repo;

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

        public BaseResponse Remove(int trackId, int dialogueId)
        {
            throw new NotImplementedException();
        }
    }
}
