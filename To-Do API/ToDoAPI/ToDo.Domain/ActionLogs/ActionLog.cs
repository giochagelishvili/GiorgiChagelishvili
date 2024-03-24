namespace ToDo.Domain.ActionLogs
{
    public class ActionLog
    {
        //        o Date
        //o ItemType
        //o ItemId
        //o OperationType(ENUM: Created, Updated, Deleted, MarkedAsDone, ...)
        //o CollumnName

        //o OldResult
        //o NewResult
        //o STATUS NOT REQUIRED FOR THIS TABLE
        public int Id { get; set; }
        public DateTime Date { get; set; }
    }
}
