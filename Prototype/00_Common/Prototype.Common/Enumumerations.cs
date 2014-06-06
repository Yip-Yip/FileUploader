using System.ComponentModel;

namespace Prototype.Common
{
    public class Enumumerations
    {
        public enum RequestServiceType : short
        {
            [Description("Resume Email")]
            SendDocumentUploadResumeEmail,
            [Description("Approve Email")]
            SendDocumentUploadApproveEmail,
            [Description("Rejected Email")]
            SendDocumentUploadRejectEmail,
            [Description("Documents to be sent offline")]
            DocumentSendOffline,
            [Description("Documents Uploaded")]
            DocumentsUploaded,
            [Description("Verify Identity")]
            VerifyIdentity
        }
        public enum AttachmentType
        {

            [Description("Official Body Document")]
            OfficialBodyDocument,
            [Description("Drivers Licence")]
            DriversLicence = 100,
            [Description("Passport")]
            Passport = 102,
            [Description("Birth Certificate")]
            BirthCertificate = 103,
            [Description("Proof Of Age Card")]
            ProofOfAgeCard = 104
        }

        public enum SupportingDocumentDeliveryType : short
        {
            Mail,
            Fax,
            Online,
            Unknown
        }
    }
}