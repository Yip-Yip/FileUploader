using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Prototype.Common;

namespace Prototype.Web.Models
{
    public class FileUploadModel
    {
        public int FilesToUpload { get; set; }
        public string CustomerReference { get; set; }
        public IEnumerable<HttpPostedFileBase> FileUploadList { get; set; }
        public IEnumerable<FileUploadResponse> FileUploadResponses { get; set; }
        public Enumumerations.SupportingDocumentDeliveryType DocumentSendMethod { get; set; }

    }

    public class FileUploadResponse
    {
        public int FileID { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public int FileSize { get; set; }
        public Enumumerations.AttachmentType AttachmentType { get; set; }
    }
}