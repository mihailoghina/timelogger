using System;
using System.Collections.Generic;
using Timelogger.Entities;

namespace Timelogger.Api.Repository
{
    public interface IRecordRepository
    {
        Record GetById(Guid id);
        IEnumerable<Record> GetEntitiesForParentId(Guid activityId);
        IEnumerable<Record> GetAll();
        Record Add(Record record);
        bool Update(Record record);
        bool Delete(Record record);
        bool PersistDbChanges();
    }
}