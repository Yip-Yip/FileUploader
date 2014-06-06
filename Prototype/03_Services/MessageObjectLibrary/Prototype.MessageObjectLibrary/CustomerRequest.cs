using System;

namespace Prototype.MessageObjectLibrary
{
    public class CustomerRequest
    {
        public int RequestId { get; set; }
        public int CustomerId { get; set; }
        public string CountryCode { get; set; }
        public string CustomerReference { get; set; }
        public string UserIPAddress { get; set; }
        public string RequestServiceType { get; set; }
        public bool IsCreditFileRequest { get; set; }
        public string DeliveryType { get; set; }
        public Nullable<short> SupportingDocumentDeliveryType { get; set; }
        public short RequestStatus { get; set; }
        public Nullable<short> POICheckStatus { get; set; }
        public string Comments { get; set; }
        public string UpdatedBy { get; set; }
        public string AssignedTo { get; set; }
        public Nullable<int> MatchedConsumerId { get; set; }
        public Nullable<DateTime> SubmittedOn { get; set; }
        public Nullable<DateTime> DueOn { get; set; }
        public Nullable<DateTime> CompletedOn { get; set; }
        public Nullable<DateTime> AcknowledgedOn { get; set; }
        public Nullable<short> AmendmentOutcome { get; set; }
        public string NoAmendmentReason { get; set; }
        public string TerminateReason { get; set; }
        public byte[] AccountData { get; set; }
        public string ValidationErrors { get; set; }
        public Nullable<Guid> WorkflowId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string UID { get; set; }
        public string NewEmailAddress { get; set; }
        public bool UseCurrentAddressForDelivery { get; set; }
        public string AlertDeliveryType { get; set; }
        public string ReportType { get; set; }
        public Nullable<int> PaymentGatewayTransactionId { get; set; }
        public Nullable<int> ParentRequestId { get; set; }
        public string Notes { get; set; }
    }
}
