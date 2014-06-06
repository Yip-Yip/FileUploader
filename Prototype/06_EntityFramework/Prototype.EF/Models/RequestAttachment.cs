using System;
using System.Collections.Generic;

namespace MessageLog.EF.Models
{
    public partial class RequestAttachment
    {
        public int FileId { get; set; }
        public int RequestId { get; set; }
        public short AttachmentType { get; set; }
        public string ContentType { get; set; }
        public string OriginalFilename { get; set; }
        public System.DateTime LoadedOn { get; set; }
        public Nullable<System.DateTime> ExpiryDate { get; set; }
        public byte[] FileContent { get; set; }
        public virtual Request Request { get; set; }
    }
}
