using Model.Context;
using Model.Models;
using Repository.AbstractRepo;
using System;
using System.Data.Entity;
using System.Linq;

namespace Repository.Repositories
{
    internal class EfFileRepository : IFileRepository
    {
        private readonly EfContext _context;

        public EfFileRepository(EfContext context)
        {
            _context = context;
        }
        public AudioFile GetAudioFile(int audioId)
        {
            return _context.AudioFile.FirstOrDefault(a => a.Id == audioId);
        }

        public void Add(AudioFile newTrack)
        {
            newTrack = SetAudioName(newTrack);
            _context.AudioFile.Add(newTrack);
            _context.SaveChanges();
        }

        public void Edit(AudioFile editTrack)
        {
            editTrack = SetAudioName(editTrack);
            _context.Entry(editTrack).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Remove(int trackId, int dialogueId)
        {
            throw new NotImplementedException();
        }

        private AudioFile SetAudioName(AudioFile audioFile)
        {
            var issue = _context.Issue.Find(audioFile.Id);
            audioFile.FileName = $"Audio_{issue.Dialogue.Name}_{issue.IssueNr}_{issue.Actor.Name}";
            return audioFile;
        }
    }
}
