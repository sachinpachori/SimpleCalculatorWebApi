using SimpleCalculator.DataAccess;
using SimpleCalculator.DomainEntities;
using System;

namespace SimpleCalculator.Services
{
    public class DiagnosticsService : IDiagnosticsService
    {
        private readonly IRepository<Diagnostics, int> _diagRepository;
        public DiagnosticsService(IRepository<Diagnostics, int> DiagRepository)
        {
            _diagRepository = DiagRepository;
        }

        public void LogToDB(string Data)
        {
            _diagRepository.Add(entity: new Diagnostics
            {
                Id = 0,
                CreatedOn = DateTime.UtcNow,
                Details = Data
            });
        }
    }
}
