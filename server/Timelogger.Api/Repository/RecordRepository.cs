using System;
using System.Collections.Generic;
using System.Linq;
using Timelogger.Entities;
using Microsoft.Extensions.Logging;

namespace Timelogger.Api.Repository
{
    public class RecordRepository : IRecordRepository
    {
        private readonly ApiContext _context;
        private readonly ILogger _logger;

        public RecordRepository(ApiContext context, ILogger<RecordRepository> logger) 
        {
            _context = context;
            _logger = logger;
        } 

        public IEnumerable<Record> GetAll() 
        {
            return _context.Records;
        } 
        public Record GetById(Guid id)
        {
            return _context.Records.SingleOrDefault(_ => _.Id == id);
        } 

        public Record Add(Record record) 
        {
            _context.Records.Add(record);
            if (PersistDbChanges())
            {
                 return record;
            }
            return (Record)null;          
        }

        public bool Delete(Record record) 
        {
            _context.Records.Remove(record);
            return PersistDbChanges();
        }

        public bool PersistDbChanges()
        {
            try
            {
                return _context.SaveChanges() > 0;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return false;
            }        
        }

        public bool Update(Record record)
        {
            _context.Records.Update(record);
            return PersistDbChanges();
        }
    }
}