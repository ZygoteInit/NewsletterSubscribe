using GreenFinch.Data.Infrastructure;
using GreenFinch.Data.Repositories;
using GreenFinch.Models;
using System.Collections.Generic;
using System;

namespace GreenFinch.Service
{
    public interface ISubscriberService
    {
        IEnumerable<Subscriber> GetSubscribers();
        IEnumerable<Source> GetSources();
        void CreateSubscriber(Subscriber gadget);
        void SaveSubscriber();
        bool CheckIfEmailExists(string email);
    }

    public class SubscriberService : ISubscriberService
    {
        private readonly ISubscriberRepository subscriberRepository;
        private readonly ISourceRepository SourceRepository;
        private readonly IUnitOfWork unitOfWork;

        public SubscriberService(ISubscriberRepository subscriberRepository, ISourceRepository SourceRepository, IUnitOfWork unitOfWork)
        {
            this.subscriberRepository = subscriberRepository;
            this.SourceRepository = SourceRepository;
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Source> GetSources()
        {
            var sources = SourceRepository.GetAll();
            return sources;
        }

        public IEnumerable<Subscriber> GetSubscribers()
        {
            var subscribers = subscriberRepository.GetAll();
            return subscribers;
        }

        public void CreateSubscriber(Subscriber subscriber)
        {
            subscriberRepository.Add(subscriber);
        }

        public void SaveSubscriber()
        {
            unitOfWork.Commit();
        }

        public bool CheckIfEmailExists(string email)
        {
            return subscriberRepository.CheckIfEmailExists(email);
        }
    }
}
