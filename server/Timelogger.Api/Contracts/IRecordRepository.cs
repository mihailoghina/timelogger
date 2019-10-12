using System;
using System.Collections.Generic;
using Timelogger.Entities;

namespace Timelogger.Api.Repository
{
    public interface IRecordRepository
    {
        IEnumerable<Record> GetAll();
        Record GetById(Guid id);
        Record Add(Record record);
        bool Delete(Record record);
        bool Update(Record record);
        bool PersistDbChanges();
    }
}