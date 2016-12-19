using GreenFinch.Data.Infrastructure;
using GreenFinch.Data.Repositories;
using GreenFinch.Models;
using System.Collections.Generic;

namespace GreenFinch.Service
{
    public interface ISourceService
    {
      
        IEnumerable<Source> GetSources();
        void CreateSource(Source source);
        void SaveSource();
    }

    public class SourceService : ISourceService
    {
        private readonly ISourceRepository SourceRepository;
        private readonly IUnitOfWork unitOfWork;

        public SourceService( ISourceRepository SourceRepository, IUnitOfWork unitOfWork)
        {
            this.SourceRepository = SourceRepository;
          
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Source> GetSources()
        {
            var sources = SourceRepository.GetAll();
            return sources;
        }

        public void CreateSource(Source source)
        {
            SourceRepository.Add(source);
        }

        public void SaveSource()
        {
            unitOfWork.Commit();
        }

     
    }
}
